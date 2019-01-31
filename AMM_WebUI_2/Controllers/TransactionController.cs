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

        [Route("api/add-transaction")]
        public ApiResponse<TransactionLog> Post([FromBody]TransactionForm _transactionForm)
        {
            string login = HttpContext.Current.Session["user_login"].ToString();

            Transaction transaction1 = new Transaction();
            Transaction transaction2 = new Transaction();
            TransactionLog transactionLog = new TransactionLog()
            {
                Date = _transactionForm.Date,
                Comment = _transactionForm.Comment,
                User = mRepository.UserAMM.GetUserByLogin(login),
                From = mRepository.SourceAMM.GetSourceById(login, _transactionForm.From),
                To = mRepository.SourceAMM.GetSourceById(login, _transactionForm.To)
            };

            transaction1.Source = transactionLog.From;
            //transaction1.TransactionLog = transactionLog;
            if (transactionLog.From.Type == TypeOfSource.Wallet || transactionLog.From.Type == TypeOfSource.Card)
            {
                transaction1.Credit = _transactionForm.Summ;
            }
            else
            {
                transaction1.Credit = 0;
            }

            transaction2.Source = transactionLog.To;
            //transaction2.TransactionLog = transactionLog;
            if (transactionLog.To.Type == TypeOfSource.Wallet || transactionLog.To.Type == TypeOfSource.Card)
            {
                transaction2.Debet = _transactionForm.Summ;
            }
            else
            {
                transaction2.Debet = 0;
            }
            
            try
            {
                transactionLog.From.Money -= transaction1.Credit;
                transactionLog.To.Money += transaction2.Debet;
                transactionLog.Transactions.Add(transaction1);
                transactionLog.Transactions.Add(transaction2);
                transactionLog.Status = TransStatus.Success;
                mRepository.TransactionAMM.SaveTransaction(transactionLog);
                return new ApiResponse<TransactionLog>() { data = transactionLog, error = "" };                
            }
            catch (Exception ex)
            {
                return new ApiResponse<TransactionLog>() { error = ex.Message };
            }
        }
    }
}
