using AMM_Desktop_Client.Model;
using AMM_Desktop_Client.Models;
using AMM_Desktop_Client.WebAPIClientWPF;
using Catel.Data;
using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Desktop_Client.ViewModels
{
    class GeneralViewModel : ViewModelBase
    {

        public GeneralViewModel()
        {
            Sources = new List<Source>();
            Transactions = new List<Transaction>();

            LoadSourcesTransactionsCommand = new Command(OnLoadSourcesTransactionsCommandExecute);
            LogoutCommand = new Command(OnLogoutCommandExecute);
            ShowAddTransactionViewCommand = new Command(OnShowAddTransactionViewCommandExecute);
        }

        #region Properties

        public List<Source> Sources
        {
            get { return GetValue<List<Source>>(SourcesProperty); }
            set { SetValue(SourcesProperty, value); }
        }

        public static readonly PropertyData SourcesProperty = RegisterProperty(nameof(Sources), typeof(List<Source>), null);

        public List<Transaction> Transactions
        {
            get { return GetValue<List<Transaction>>(TransactionsProperty); }
            set { SetValue(TransactionsProperty, value); }
        }

        public static readonly PropertyData TransactionsProperty = RegisterProperty(nameof(Transactions), typeof(List<Transaction>), null);

        public bool PreloaderVisibility
        {
            get { return GetValue<bool>(PreloaderVisibilityProperty); }
            set { SetValue(PreloaderVisibilityProperty, value); }
        }

        public static readonly PropertyData PreloaderVisibilityProperty = RegisterProperty(nameof(PreloaderVisibility), typeof(bool), null);

        public Command ShowLoginView
        {
            get { return GetValue<Command>(ShowLoginViewProperty); }
            set { SetValue(ShowLoginViewProperty, value); }
        }

        public static readonly PropertyData ShowLoginViewProperty = RegisterProperty(nameof(ShowLoginView), typeof(Command), null);

        public Command ShowAddTransactionView
        {
            get { return GetValue<Command>(ShowAddTransactionViewProperty); }
            set { SetValue(ShowAddTransactionViewProperty, value); }
        }

        public static readonly PropertyData ShowAddTransactionViewProperty = RegisterProperty(nameof(ShowAddTransactionView), typeof(Command), null);

        public Command Logout
        {
            get { return GetValue<Command>(LogOutProperty); }
            set { SetValue(LogOutProperty, value); }
        }

        public static readonly PropertyData LogOutProperty = RegisterProperty(nameof(Logout), typeof(Command), null);
        #endregion

        #region Methods

        public Command LoadSourcesTransactionsCommand { get; private set; }

        private async void OnLoadSourcesTransactionsCommandExecute()
        {
            PreloaderVisibility = true;
            if (Sources.Count == 0)
            {
                ApiResponse<List<Source>> response = await GetSourcesAsync();
                
                if (response.data != null)
                {
                    foreach (var item in response.data)
                    {
                        if (item.Type == TypeOfSource.Card || item.Type == TypeOfSource.Wallet)
                        {
                            switch (item.Type)
                            {
                                case TypeOfSource.Wallet:
                                    item.Icon = "Wallet";
                                    break;
                                case TypeOfSource.Card:
                                    item.Icon = "CreditCardMultiple";
                                    break;
                                default:
                                    break;
                            }
                            Sources.Add(item);
                        }                        
                    }
                }                
                else
                {
                    System.Windows.MessageBox.Show(response.error);
                }
                ApiResponse<List<Transaction>> response2 = await GetTransactionsAsync();
                PreloaderVisibility = false;
                if (response2.data != null)
                {
                    foreach (var item in response2.data)
                    {
                        var newItem = item;
                        newItem.Time = DateTime.Parse(item.Date).TimeOfDay.ToString();                        
                        if (item.Debet != 0)
                        {
                            newItem.Summ = item.Debet;
                        }
                        else
                        {
                            newItem.Summ = item.Credit;
                        }
                        Transactions.Add(newItem);
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show(response2.error);
                }
            } 
        }

        private async Task<ApiResponse<List<Transaction>>> GetTransactionsAsync()
        {
            HttpResponseMessage response = await WebAPIClient.Client.GetAsync("api/transactions/get-today");
            ApiResponse<List<Transaction>> result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<ApiResponse<List<Transaction>>>();
            }
            return result;
        }

        private async Task<ApiResponse<List<Source>>> GetSourcesAsync()
        {
            HttpResponseMessage response = await WebAPIClient.Client.GetAsync("api/sources/get");            
            ApiResponse<List<Source>> result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<ApiResponse<List<Source>>>();
            }
            return result;
        }

        public Command LogoutCommand { get; private set; }

        private async void OnLogoutCommandExecute()
        {
            PreloaderVisibility = true;
            HttpResponseMessage response = await WebAPIClient.Client.PutAsJsonAsync("api/logout", new Object { });
            response.EnsureSuccessStatusCode();            
            Sources.Clear();
            Transactions.Clear();
            PreloaderVisibility = false;
            Logout.Execute();
            //ShowLoginView.Execute();
        }

        public Command ShowAddTransactionViewCommand { get; private set; }

        private void OnShowAddTransactionViewCommandExecute()
        {
            ShowAddTransactionView.Execute();
        }
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
