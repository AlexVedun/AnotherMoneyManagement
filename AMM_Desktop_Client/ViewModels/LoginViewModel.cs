using AMM_Domain;
using Catel.Data;
using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AMM_Desktop_Client.ViewModels
{
    class LoginViewModel: ViewModelBase
    {
        private IRepository repository;
        public LoginViewModel()
        {
            repository = new SqlServerRepository();

            LoginCommand = new Command<object>(OnLoginCommandExecute);
        }

        #region Properties

        public string UserLogin
        {
            get { return GetValue<string>(UserLoginProperty); }
            set { SetValue(UserLoginProperty, value); }
        }

        public static readonly PropertyData UserLoginProperty = RegisterProperty(nameof(UserLogin), typeof(string), null);
        #endregion

        #region Methods

        public Command<object> LoginCommand { get; private set; }

        private void OnLoginCommandExecute(object _param)
        {
            var passwordBox = _param as PasswordBox;
            string password = passwordBox.Password;
            User user = repository.UserAMM.GetUserByLogin(UserLogin);
            if (user == null)
            {
                System.Windows.MessageBox.Show("Неверный логин или пароль");
            }
            else if (user.Password != password)
            {
                System.Windows.MessageBox.Show("Неверный логин или пароль");
            }
            else
            {

            }

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
