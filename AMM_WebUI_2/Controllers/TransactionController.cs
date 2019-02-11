using AMM_Domain_2;
using AMM_Domain_2.Model;
using AMM_WebUI_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AMM_WebUI_2.Controllers
{
    public class TransactionController : ApiController
    {
        private IRepository mRepository;

        public TransactionController(IRepository _repository)
        {
            mRepository = _repository;
        }

        [Route("api/transactions/get-today")]
        public Object Get()
        {
            string login = HttpContext.Current.Session["user_login"].ToString();
            try
            {
                return new ApiResponse<Object>()
                {
                    data = mRepository.TransactionAMM.GetTransactionsForToday(login),
                    error = ""
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<Object>()
                {
                    error = ex.Message
                };
            }
            
        }

        [Route("api/transactions/add")]
        public ApiResponse<Transaction> Post([FromBody]TransactionForm _transactionForm)
        {
            string login = HttpContext.Current.Session["user_login"].ToString();

            Transaction transaction = new Transaction()
            {
                Date = _transactionForm.Date,
                Comment = _transactionForm.Comment,
                User = mRepository.UserAMM.GetUserByLogin(login),
                From = mRepository.SourceAMM.GetSourceById(login, _transactionForm.From),
                To = mRepository.SourceAMM.GetSourceById(login, _transactionForm.To)
            };

            if (transaction.From.Type == TypeOfSource.Wallet || transaction.From.Type == TypeOfSource.Card)
            {
                transaction.Credit = _transactionForm.Summ;
            }
            else
            {
                transaction.Credit = 0;
            }
            if (transaction.To.Type == TypeOfSource.Wallet || transaction.To.Type == TypeOfSource.Card)
            {
                transaction.Debet = _transactionForm.Summ;
            }
            else
            {
                transaction.Debet = 0;
            }

            transaction.From.Money -= transaction.Credit;
            transaction.To.Money += transaction.Debet;

            if (transaction.From.Money < 0)
            {
                return new ApiResponse<Transaction>() { error = "Недостаточно средств для выполнения транзакции!" };
            }
            else
            {
                try
                {
                    mRepository.SourceAMM.SaveSource(transaction.From);
                    mRepository.SourceAMM.SaveSource(transaction.To);
                    mRepository.TransactionAMM.SaveTransaction(transaction);
                    return new ApiResponse<Transaction>() { data = transaction, error = "" };
                }
                catch (Exception ex)
                {
                    return new ApiResponse<Transaction>() { error = ex.Message };
                }
            }                       
        }
    }
}
