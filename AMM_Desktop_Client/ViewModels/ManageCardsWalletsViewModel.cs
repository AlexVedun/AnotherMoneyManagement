using AMM_Desktop_Client.Model;
using AMM_Desktop_Client.Models;
using AMM_Desktop_Client.WebAPIClientWPF;
using Catel.Data;
using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Desktop_Client.ViewModels
{
    class ManageCardsWalletsViewModel : ViewModelBase
    {
        public ManageCardsWalletsViewModel()
        {
            Sources = new ObservableCollection<Source>();

            LoadSourcesCommand = new Command(OnLoadSourcesCommandExecuteAsync);
            ReadyCommand = new Command(OnReadyCommandExecute);
            AddWalletCardCommand = new Command(OnAddWalletCardCommandExecuteAsync);
            DeleteWalletCardCommand = new Command(OnDeleteWalletCardCommandExecuteAsync);
        }

        #region Properties

        public ObservableCollection<Source> Sources
        {
            get { return GetValue<ObservableCollection<Source>>(SourcesProperty); }
            set { SetValue(SourcesProperty, value); }
        }

        public static readonly PropertyData SourcesProperty = RegisterProperty(nameof(Sources), typeof(ObservableCollection<Source>), null);

        public bool PreloaderVisibility
        {
            get { return GetValue<bool>(PreloaderVisibilityProperty); }
            set { SetValue(PreloaderVisibilityProperty, value); }
        }

        public static readonly PropertyData PreloaderVisibilityProperty = RegisterProperty(nameof(PreloaderVisibility), typeof(bool), null);

        public Command ShowGeneralView
        {
            get { return GetValue<Command>(ShowGeneralViewProperty); }
            set { SetValue(ShowGeneralViewProperty, value); }
        }

        public static readonly PropertyData ShowGeneralViewProperty = RegisterProperty(nameof(ShowGeneralView), typeof(Command), null);

        public Source SelectedItem
        {
            get { return GetValue<Source>(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly PropertyData SelectedItemProperty = RegisterProperty(nameof(SelectedItem), typeof(Source), null);

        public bool IsWalletChecked
        {
            get { return GetValue<bool>(IsWalletCheckedProperty); }
            set { SetValue(IsWalletCheckedProperty, value); }
        }

        public static readonly PropertyData IsWalletCheckedProperty = RegisterProperty(nameof(IsWalletChecked), typeof(bool), null);

        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string), null);

        public string Description
        {
            get { return GetValue<string>(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly PropertyData DescriptionProperty = RegisterProperty(nameof(Description), typeof(string), null);

        public string Summ
        {
            get { return GetValue<string>(SummProperty); }
            set { SetValue(SummProperty, value); }
        }

        public static readonly PropertyData SummProperty = RegisterProperty(nameof(Summ), typeof(string), null);
        #endregion

        #region Methods

        public Command LoadSourcesCommand { get; private set; }

        private async void OnLoadSourcesCommandExecuteAsync()
        {
            PreloaderVisibility = true;
            ApiResponse<List<Source>> response = await GetSourcesAsync();
            if (response != null)
            {
                if (response.data != null)
                {
                    Sources.Clear();
                    foreach (var item in response.data)
                    {
                        if (item.Type == TypeOfSource.Wallet || item.Type == TypeOfSource.Card)
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
            }
            else
            {
                System.Windows.MessageBox.Show("Ошибка получения данных с сервера!");
            }
            PreloaderVisibility = false;
            SelectedItem = null;
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

        public Command ReadyCommand { get; private set; }

        private void OnReadyCommandExecute()
        {
            ShowGeneralView.Execute();
        }

        public Command AddWalletCardCommand { get; private set; }

        private async void OnAddWalletCardCommandExecuteAsync()
        {
            PreloaderVisibility = true;
            if (Name != "")
            {
                if (Decimal.TryParse(Summ, out decimal money))
                {
                    AddSourceForm addSourceForm = new AddSourceForm()
                    {
                        Name = Name,
                        Description = Description,
                        Money = money,
                    TypeOfSource = (int)(IsWalletChecked ? TypeOfSource.Wallet : TypeOfSource.Card)
                    };
                    ApiResponse<Source> response = await AddSourceAsync(addSourceForm);
                    if (response.data != null)
                    {
                        LoadSourcesCommand.Execute();
                        Name = "";
                        Description = "";
                    }
                    else
                    {
                        System.Windows.MessageBox.Show(response.error);
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Введенное значение суммы не является числом!");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Название категории не может быть пустым!");
            }
            PreloaderVisibility = false;
        }

        private async Task<ApiResponse<Source>> AddSourceAsync(AddSourceForm _addSourceForm)
        {
            HttpResponseMessage response = await WebAPIClient.Client.PostAsJsonAsync("api/sources/add", _addSourceForm);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ApiResponse<Source>>();
        }

        public Command DeleteWalletCardCommand { get; private set; }

        private async void OnDeleteWalletCardCommandExecuteAsync()
        {
            PreloaderVisibility = true;
            if (SelectedItem != null)
            {
                ApiResponse<Source> response = await DeleteSourceAsync(SelectedItem.Id.ToString());
                if (response.data != null)
                {
                    LoadSourcesCommand.Execute();
                }
                else
                {
                    System.Windows.MessageBox.Show(response.error);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Необходимо выбрать кошелек/карту для удаления!");
            }
            PreloaderVisibility = false;
        }

        public async Task<ApiResponse<Source>> DeleteSourceAsync(string _id)
        {
            HttpResponseMessage response = await WebAPIClient.Client.DeleteAsync($"api/sources/delete/{_id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ApiResponse<Source>>();
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
