namespace AMM_Desktop_Client.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using System.Threading.Tasks;

    public class MainWindowViewModel : ViewModelBase
    {
        private IViewModel loginView = new LoginViewModel();
        private IViewModel registrationView = new RegistrationViewModel();
        private IViewModel generalView = new GeneralViewModel();
        private IViewModel addTransactionView = new AddTransactionViewModel();
        private IViewModel manageCategoriesView = new ManageCategoriesViewModel();

        public MainWindowViewModel()
        {
            ShowRegistrationViewCommand = new Command(OnShowRegistrationViewCommandExecute);
            ShowLoginViewCommand = new Command(OnShowLoginViewCommandExecute);
            ShowGeneralViewCommand = new Command(OnShowGeneralViewCommandExecute);
            ShowAddTransactionViewCommand = new Command(OnShowAddTransactionViewCommandExecute);
            LogoutCommand = new Command(OnLogoutCommandExecute);
            ShowManageCategoriesViewCommand = new Command(OnShowManageCategoriesViewCommandExecute);

            ((LoginViewModel)loginView).ShowRegistrationView = ShowRegistrationViewCommand;
            ((LoginViewModel)loginView).ShowGeneralView = ShowGeneralViewCommand;
            ((RegistrationViewModel)registrationView).ShowLoginView = ShowLoginViewCommand;
            //((GeneralViewModel)generalView).ShowLoginView = ShowLoginViewCommand;
            ((GeneralViewModel)generalView).Logout = LogoutCommand;
            ((GeneralViewModel)generalView).ShowAddTransactionView = ShowAddTransactionViewCommand;
            ((GeneralViewModel)generalView).ShowManageCategoriesView = ShowManageCategoriesViewCommand;
            ((AddTransactionViewModel)addTransactionView).ShowGeneralView = ShowGeneralViewCommand;
            

            CurrentView = loginView;
        }

        #region Properties

        public IViewModel CurrentView
        {
            get { return GetValue<IViewModel>(CurrentViewProperty); }
            set { SetValue(CurrentViewProperty, value); }
        }

        public static readonly PropertyData CurrentViewProperty = RegisterProperty(nameof(CurrentView), typeof(IViewModel), null);
        #endregion

        #region Methods

        public Command ShowRegistrationViewCommand { get; private set; }

        private void OnShowRegistrationViewCommandExecute()
        {       
            CurrentView = registrationView;
        }

        public Command ShowLoginViewCommand { get; private set; }

        private void OnShowLoginViewCommandExecute()
        {
            CurrentView = loginView;
        }

        public Command ShowGeneralViewCommand { get; private set; }

        private void OnShowGeneralViewCommandExecute()
        {
            ((GeneralViewModel)generalView).LoadSourcesTransactionsCommand.Execute();
            CurrentView = generalView;
        }

        public Command ShowAddTransactionViewCommand { get; private set; }

        private void OnShowAddTransactionViewCommandExecute()
        {
            ((AddTransactionViewModel)addTransactionView).LoadSourcesCommand.Execute();
            CurrentView = addTransactionView;
        }

        public Command LogoutCommand { get; private set; }

        private void OnLogoutCommandExecute()
        {
            ((AddTransactionViewModel)addTransactionView).LogoutCommand.Execute(); // ?????????????
            CurrentView = loginView;
        }

        public Command ShowManageCategoriesViewCommand { get; private set; }

        private void OnShowManageCategoriesViewCommandExecute()
        {
            CurrentView = manageCategoriesView;
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
