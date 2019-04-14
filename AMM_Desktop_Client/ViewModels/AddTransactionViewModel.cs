using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Desktop_Client.ViewModels
{
    class AddTransactionViewModel : ViewModelBase
    {
        public AddTransactionViewModel()
        {
            
        }

        #region Properties

        
        #endregion

        #region Methods

        //public Command LoadSourcesTransactionsCommand { get; private set; }

        //private async void OnLoadSourcesTransactionsCommandExecute()
        //{
        //    PreloaderVisibility = true;
        //    if (Sources.Count == 0)
        //    {
        //        ApiResponse<List<Source>> response = await GetSourcesAsync();

        //        if (response.data != null)
        //        {
        //            foreach (var item in response.data)
        //            {
        //                if (item.Type == TypeOfSource.Card || item.Type == TypeOfSource.Wallet)
        //                {
        //                    switch (item.Type)
        //                    {
        //                        case TypeOfSource.Wallet:
        //                            item.Icon = "Wallet";
        //                            break;
        //                        case TypeOfSource.Card:
        //                            item.Icon = "CreditCardMultiple";
        //                            break;
        //                        default:
        //                            break;
        //                    }
        //                    Sources.Add(item);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            System.Windows.MessageBox.Show(response.error);
        //        }
        //        ApiResponse<List<Transaction>> response2 = await GetTransactionsAsync();
        //        PreloaderVisibility = false;
        //        if (response2.data != null)
        //        {
        //            foreach (var item in response2.data)
        //            {
        //                var newItem = item;
        //                newItem.Time = DateTime.Parse(item.Date).TimeOfDay.ToString();
        //                if (item.Debet != 0)
        //                {
        //                    newItem.Summ = item.Debet;
        //                }
        //                else
        //                {
        //                    newItem.Summ = item.Credit;
        //                }
        //                Transactions.Add(newItem);
        //            }
        //        }
        //        else
        //        {
        //            System.Windows.MessageBox.Show(response2.error);
        //        }
        //    }
        //}

        //private async Task<ApiResponse<List<Transaction>>> GetTransactionsAsync()
        //{
        //    HttpResponseMessage response = await WebAPIClient.Client.GetAsync("api/transactions/get-today");
        //    ApiResponse<List<Transaction>> result = null;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        result = await response.Content.ReadAsAsync<ApiResponse<List<Transaction>>>();
        //    }
        //    return result;
        //}

        //private async Task<ApiResponse<List<Source>>> GetSourcesAsync()
        //{
        //    HttpResponseMessage response = await WebAPIClient.Client.GetAsync("api/sources/get");
        //    ApiResponse<List<Source>> result = null;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        result = await response.Content.ReadAsAsync<ApiResponse<List<Source>>>();
        //    }
        //    return result;
        //}

        //public Command LogoutCommand { get; private set; }

        //private async void OnLogoutCommandExecute()
        //{
        //    PreloaderVisibility = true;
        //    HttpResponseMessage response = await WebAPIClient.Client.PutAsJsonAsync("api/logout", new Object { });
        //    response.EnsureSuccessStatusCode();
        //    PreloaderVisibility = false;
        //    ShowLoginView.Execute();
        //}
        #endregion

        #region Other
        public override string Title { get { return "AMM_Desktop_Client"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
        #endregion
    }
}
