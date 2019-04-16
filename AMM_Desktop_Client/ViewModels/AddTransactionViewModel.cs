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
    class AddTransactionViewModel : ViewModelBase
    {
        public AddTransactionViewModel()
        {
            FromList = new List<Source>();
            ToList = new List<Source>();
            PreloaderVisibility = false;

            CancelCommand = new Command(OnCancelCommandExecute);
            AddTransactionCommand = new Command(OnAddTransactionCommandExecute);
            LoadSourcesCommand = new Command(OnLoadSourcesCommandExecute);
        }

        #region Properties

        public bool PreloaderVisibility
        {
            get { return GetValue<bool>(PreloaderVisibilityProperty); }
            set { SetValue(PreloaderVisibilityProperty, value); }
        }

        public static readonly PropertyData PreloaderVisibilityProperty = RegisterProperty(nameof(PreloaderVisibility), typeof(bool), null);

        public List<Source> FromList
        {
            get { return GetValue<List<Source>>(FromListProperty); }
            set { SetValue(FromListProperty, value); }
        }

        public static readonly PropertyData FromListProperty = RegisterProperty(nameof(FromList), typeof(List<Source>), null);

        public List<Source> ToList
        {
            get { return GetValue<List<Source>>(ToListProperty); }
            set { SetValue(ToListProperty, value); }
        }

        public static readonly PropertyData ToListProperty = RegisterProperty(nameof(ToList), typeof(List<Source>), null);

        public Source FromListSelection
        {
            get { return GetValue<Source>(FromListSelectionProperty); }
            set { SetValue(FromListSelectionProperty, value); }
        }

        public static readonly PropertyData FromListSelectionProperty = RegisterProperty(nameof(FromListSelection), typeof(Source), null);

        public Source ToListSelection
        {
            get { return GetValue<Source>(ToListSelectionProperty); }
            set { SetValue(ToListSelectionProperty, value); }
        }

        public static readonly PropertyData ToListSelectionProperty = RegisterProperty(nameof(ToListSelection), typeof(Source), null);

        public Command ShowGeneralView
        {
            get { return GetValue<Command>(ShowGeneralViewProperty); }
            set { SetValue(ShowGeneralViewProperty, value); }
        }

        public static readonly PropertyData ShowGeneralViewProperty = RegisterProperty(nameof(ShowGeneralView), typeof(Command), null);

        public string Summ
        {
            get { return GetValue<string>(SummProperty); }
            set { SetValue(SummProperty, value); }
        }

        public static readonly PropertyData SummProperty = RegisterProperty(nameof(Summ), typeof(string), null);

        public string Comment
        {
            get { return GetValue<string>(CommentProperty); }
            set { SetValue(CommentProperty, value); }
        }

        public static readonly PropertyData CommentProperty = RegisterProperty(nameof(Comment), typeof(string), null);
        #endregion

        #region Methods

        public Command CancelCommand { get; private set; }
        
        private void OnCancelCommandExecute()
        {
            ShowGeneralView.Execute();
        }

        public Command AddTransactionCommand { get; private set; }

        private async void OnAddTransactionCommandExecute()
        {
            PreloaderVisibility = true;
            TransactionForm transactionForm = new TransactionForm();
            transactionForm.Comment = Comment;
            if (decimal.TryParse(Summ, out decimal summ))
            {
                transactionForm.Summ = summ;
                transactionForm.From = FromListSelection.Id;
                transactionForm.To = ToListSelection.Id;
                DateTime localTime = DateTime.Now;
                DateTimeOffset localTimeAndOffset = new DateTimeOffset(localTime, TimeZoneInfo.Local.GetUtcOffset(localTime));
                transactionForm.Date = localTimeAndOffset.ToString("o");
                ApiResponse<Transaction> response = await AddTransactionAsync(transactionForm);
                if (response.data != null)
                {
                    ShowGeneralView.Execute();
                }
                else
                {
                    System.Windows.MessageBox.Show(response.error);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Данные, введенные в поле 'Сумма' не являются числом!");
            }
            PreloaderVisibility = false;
        }

        private async Task<ApiResponse<Transaction>> AddTransactionAsync(TransactionForm transactionForm)
        {
            HttpResponseMessage response = await WebAPIClient.Client.PostAsJsonAsync("api/transactions/add", transactionForm);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ApiResponse<Transaction>>();
        }

        public Command LoadSourcesCommand { get; private set; }

        private async void OnLoadSourcesCommandExecute()
        {
            PreloaderVisibility = true;
            if (FromList.Count == 0)
            {
                ApiResponse<List<Source>> response = await GetSourcesAsync();

                if (response.data != null)
                {
                    foreach (var item in response.data)
                    {
                        switch (item.Type)
                        {
                            case TypeOfSource.Income:
                                FromList.Add(item);
                                break;
                            case TypeOfSource.Waste:
                                ToList.Add(item);
                                break;
                            case TypeOfSource.Wallet:                                
                            case TypeOfSource.Card:
                                FromList.Add(item);
                                ToList.Add(item);
                                break;
                            default:
                                break;
                        }
                        //if (item.Type == TypeOfSource.Card || item.Type == TypeOfSource.Wallet || item.Type == TypeOfSource.Income)
                        //{
                        //    switch (item.Type)
                        //    {
                        //        case TypeOfSource.Wallet:
                        //            item.Icon = "Wallet";
                        //            break;
                        //        case TypeOfSource.Card:
                        //            item.Icon = "CreditCardMultiple";
                        //            break;
                        //        default:
                        //            break;
                        //    }
                        //    Sources.Add(item);
                        //}
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show(response.error);
                }                
            }
            PreloaderVisibility = false;
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
