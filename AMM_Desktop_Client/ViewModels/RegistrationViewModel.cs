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
    class RegistrationViewModel: ViewModelBase
    {
        //private IRepository repository;
        public RegistrationViewModel()
        {
            //repository = new SqlServerRepository();
            PreloaderVisibility = false;
            RegistrationCommand = new Command<object>(OnRegistrationCommandExecute);
            CancelCommand = new Command(OnCancelCommandExecute);
        }

        #region Properties

        public Command ShowLoginView
        {
            get { return GetValue<Command>(ShowLoginViewProperty); }
            set { SetValue(ShowLoginViewProperty, value); }
        }

        public static readonly PropertyData ShowLoginViewProperty = RegisterProperty(nameof(ShowLoginView), typeof(Command), null);

        public string UserLogin
        {
            get { return GetValue<string>(UserLoginProperty); }
            set { SetValue(UserLoginProperty, value); }
        }

        public static readonly PropertyData UserLoginProperty = RegisterProperty(nameof(UserLogin), typeof(string), null);

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

        public string UserPatronymic
        {
            get { return GetValue<string>(UserPatronymicProperty); }
            set { SetValue(UserPatronymicProperty, value); }
        }

        public static readonly PropertyData UserPatronymicProperty = RegisterProperty(nameof(UserPatronymic), typeof(string), null);

        public bool PreloaderVisibility
        {
            get { return GetValue<bool>(PreloaderVisibilityProperty); }
            set { SetValue(PreloaderVisibilityProperty, value); }
        }

        public static readonly PropertyData PreloaderVisibilityProperty = RegisterProperty(nameof(PreloaderVisibility), typeof(bool), null);
        #endregion

        #region Methods

        public Command<object> RegistrationCommand { get; private set; }

        private async void OnRegistrationCommandExecute(object _param)
        {
            PreloaderVisibility = true;
            RegisterRequestForm registerRequestForm = new RegisterRequestForm();
            var passwordBox = _param as PasswordBox;
            //string password = passwordBox.Password;
            registerRequestForm.Login = UserLogin;
            registerRequestForm.Password = passwordBox.Password;
            registerRequestForm.Surname = UserSurname;
            registerRequestForm.Name = UserName;
            registerRequestForm.Patronymic = UserPatronymic;
            ApiResponse<User> response = await RegisterAsync(registerRequestForm);
            PreloaderVisibility = false;
            if (response.data != null)
            {
                //UserLogin = "";
                System.Windows.MessageBox.Show("Пользователь " + UserLogin + " зарегистритован");
                ShowLoginView.Execute();
            }
            else
            {
                System.Windows.MessageBox.Show(response.error);
            }
            //if (repository.UserAMM.GetUserByLogin(UserLogin) != null)
            //{
            //    System.Windows.MessageBox.Show("Пользователь " + UserLogin + " уже зарегистритован. Выберите другой логин.");
            //}
            //else
            //{
            //    User user = new User();
            //    user.Login = UserLogin;
            //    user.Password = password;
            //    user.Surname = UserSurname;
            //    user.Name = UserName;
            //    user.Patronymic = user.Patronymic;
            //    repository.UserAMM.SaveUser(user);
            //    System.Windows.MessageBox.Show("Пользователь " + UserLogin + " зарегистритован");
            //    ShowLoginView.Execute();
            //}
        }

        private async Task<ApiResponse<User>> RegisterAsync(RegisterRequestForm registerRequestForm)
        {
            HttpResponseMessage response = await WebAPIClient.Client.PostAsJsonAsync("api/register", registerRequestForm);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ApiResponse<User>>();
        }

        public Command CancelCommand { get; private set; }

        private void OnCancelCommandExecute()
        {
            UserLogin = "";
            UserName = "";
            UserSurname = "";
            UserPatronymic = "";
            ShowLoginView.Execute();
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
