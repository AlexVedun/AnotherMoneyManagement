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
    class UserViewModel : ViewModelBase
    {
        public UserViewModel()
        {
            SaveCommand = new Command(OnSaveCommandExecuteAsync);
            CancelCommand = new Command(OnCancelCommandExecute);
            DeleteUserCommand = new Command(OnDeleteUserCommandExecuteAsync);
            GetUserInfoCommand = new Command(OnGetUserInfoCommandExecuteAsync);
        }

        #region Properties

        public string UserLogin
        {
            get { return GetValue<string>(UserLoginProperty); }
            set { SetValue(UserLoginProperty, value); }
        }

        public static readonly PropertyData UserLoginProperty = RegisterProperty(nameof(UserLogin), typeof(string), null);

        public string UserPassword
        {
            get { return GetValue<string>(UserPasswordProperty); }
            set { SetValue(UserPasswordProperty, value); }
        }

        public static readonly PropertyData UserPasswordProperty = RegisterProperty(nameof(UserPassword), typeof(string), null);

        public string UserSurname
        {
            get { return GetValue<string>(UserSurnameProperty); }
            set { SetValue(UserSurnameProperty, value); }
        }

        public static readonly PropertyData UserSurnameProperty = RegisterProperty(nameof(UserSurname), typeof(string), null);

        public string UserName
        {
            get { return GetValue<string>(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        public static readonly PropertyData UserNameProperty = RegisterProperty(nameof(UserName), typeof(string), null);

        public bool PreloaderVisibility
        {
            get { return GetValue<bool>(PreloaderVisibilityProperty); }
            set { SetValue(PreloaderVisibilityProperty, value); }
        }

        public static readonly PropertyData PreloaderVisibilityProperty = RegisterProperty(nameof(PreloaderVisibility), typeof(bool), null);

        public string UserPatronymic
        {
            get { return GetValue<string>(UserPatronymicProperty); }
            set { SetValue(UserPatronymicProperty, value); }
        }

        public static readonly PropertyData UserPatronymicProperty = RegisterProperty(nameof(UserPatronymic), typeof(string), null);

        public Command ShowGeneralView
        {
            get { return GetValue<Command>(ShowGeneralViewProperty); }
            set { SetValue(ShowGeneralViewProperty, value); }
        }

        public static readonly PropertyData ShowGeneralViewProperty = RegisterProperty(nameof(ShowGeneralView), typeof(Command), null);

        public Command ShowLoginView
        {
            get { return GetValue<Command>(ShowLoginViewProperty); }
            set { SetValue(ShowLoginViewProperty, value); }
        }

        public static readonly PropertyData ShowLoginViewProperty = RegisterProperty(nameof(ShowLoginView), typeof(Command), null);
        #endregion

        #region Methods

        public Command SaveCommand { get; private set; }

        private async void OnSaveCommandExecuteAsync()
        {
            PreloaderVisibility = true;
            UserRequestForm userRequestForm = new UserRequestForm()
            {
                Login = UserLogin,
                Password = UserPassword,
                Surname = UserSurname,
                Name = UserName,
                Patronymic = UserPatronymic
            };            
            ApiResponse<User> response = await SaveUserAsync(userRequestForm);
            PreloaderVisibility = false;
            if (response.data != null)
            {
                ShowGeneralView.Execute();
            }
            else
            {
                System.Windows.MessageBox.Show(response.error);
            }
        }

        private async Task<ApiResponse<User>> SaveUserAsync(UserRequestForm _userRequestForm)
        {
            HttpResponseMessage response = await WebAPIClient.Client.PostAsJsonAsync("api/user/save", _userRequestForm);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ApiResponse<User>>();
        }

        public Command CancelCommand { get; private set; }

        private void OnCancelCommandExecute()
        {
            ShowGeneralView.Execute();
        }

        public Command DeleteUserCommand { get; private set; }

        private async void OnDeleteUserCommandExecuteAsync()
        {
            PreloaderVisibility = true;            
            ApiResponse<Object> response = await DeleteUserAsync();
            PreloaderVisibility = false;
            if (response.error == "")
            {
                ShowLoginView.Execute();
            }
            else
            {
                System.Windows.MessageBox.Show(response.error);
            }
        }

        private async Task<ApiResponse<Object>> DeleteUserAsync()
        {
            HttpResponseMessage response = await WebAPIClient.Client.DeleteAsync("api/user/delete");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ApiResponse<Object>>();
        }

        public Command GetUserInfoCommand { get; private set; }

        private async void OnGetUserInfoCommandExecuteAsync()
        {
            PreloaderVisibility = true;
            ApiResponse<User> response = await GetUserInfoAsync();
            if (response.data != null)
            {
                UserLogin = response.data.Login;
                UserPassword = response.data.Password;
                UserSurname = response.data.Surname;
                UserName = response.data.Name;
                UserPatronymic = response.data.Patronymic;
            }
            else
            {
                System.Windows.MessageBox.Show(response.error);
            }
            PreloaderVisibility = false;
        }

        private async Task<ApiResponse<User>> GetUserInfoAsync()
        {
            HttpResponseMessage response = await WebAPIClient.Client.GetAsync("api/user/get");
            ApiResponse<User> result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<ApiResponse<User>>();
            }
            return result;
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
