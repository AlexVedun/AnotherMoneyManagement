using AMM_Desktop_Client.Models;
using AMM_Desktop_Client.WebAPIClientWPF;
using AMM_Domain_2;
using AMM_Domain_2.Model;
using Catel.Data;
using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AMM_Desktop_Client.ViewModels
{
    class LoginViewModel: ViewModelBase
    {
        //private IRepository repository;
        public LoginViewModel()
        {
            //repository = new SqlServerRepository();
            PreloaderVisibility = false;

            LoginCommand = new Command<object>(OnLoginCommandExecute);
            RegistrationCommand = new Command(OnRegistrationCommandExecute);
        }

        #region Properties

        public string UserLogin
        {
            get { return GetValue<string>(UserLoginProperty); }
            set { SetValue(UserLoginProperty, value); }
        }

        public static readonly PropertyData UserLoginProperty = RegisterProperty(nameof(UserLogin), typeof(string), null);

        public Command ShowRegistrationView
        {
            get { return GetValue<Command>(ShowRegistrationViewProperty); }
            set { SetValue(ShowRegistrationViewProperty, value); }
        }

        public static readonly PropertyData ShowRegistrationViewProperty = RegisterProperty(nameof(ShowRegistrationView), typeof(Command), null);

        public Command ShowGeneralView
        {
            get { return GetValue<Command>(ShowGeneralViewProperty); }
            set { SetValue(ShowGeneralViewProperty, value); }
        }

        public static readonly PropertyData ShowGeneralViewProperty = RegisterProperty(nameof(ShowGeneralView), typeof(Command), null);

        public bool PreloaderVisibility
        {
            get { return GetValue<bool>(PreloaderVisibilityProperty); }
            set { SetValue(PreloaderVisibilityProperty, value); }
        }

        public static readonly PropertyData PreloaderVisibilityProperty = RegisterProperty(nameof(PreloaderVisibility), typeof(bool), null);
        #endregion

        #region Methods

        public Command<object> LoginCommand { get; private set; }

        private async void OnLoginCommandExecute(object _param)
        {
            LoginRequestForm loginRequestForm = new LoginRequestForm();
            PreloaderVisibility = true;
            var passwordBox = _param as PasswordBox;
            loginRequestForm.Login = UserLogin;
            loginRequestForm.Password = passwordBox.Password;
            //string password = passwordBox.Password;
            //User user = repository.UserAMM.GetUserByLogin(UserLogin);
            ApiResponse<User> response = await LoginAsync(loginRequestForm);
            PreloaderVisibility = false;
            if (response.data != null)
            {
                UserLogin = "";
                ShowGeneralView.Execute();
            }
            else
            {
                System.Windows.MessageBox.Show(response.error);
            }
            //PreloaderVisibility = false;
            //if (user == null)
            //{
            //    System.Windows.MessageBox.Show("Неверный логин или пароль");
            //}
            //else if (user.Password != password)
            //{
            //    System.Windows.MessageBox.Show("Неверный логин или пароль");
            //}
            //else
            //{
            //    UserLogin = "";
            //    ShowGeneralView.Execute();
            //}

        }

        private async Task<ApiResponse<User>> LoginAsync(LoginRequestForm loginRequestForm)
        {
            HttpResponseMessage response = await WebAPIClient.Client.PostAsJsonAsync("api/login", loginRequestForm);
            response.EnsureSuccessStatusCode();            
            return await response.Content.ReadAsAsync<ApiResponse<User>>();
        }

        public Command RegistrationCommand { get; private set; }

        private void OnRegistrationCommandExecute()
        {
            UserLogin = "";
            ShowRegistrationView.Execute();
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
