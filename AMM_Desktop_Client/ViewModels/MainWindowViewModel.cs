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

        public MainWindowViewModel()
        {
            ShowRegistrationViewCommand = new Command(OnShowRegistrationViewCommandExecute);
            ShowLoginViewCommand = new Command(OnShowLoginViewCommandExecute);
            ShowGeneralViewCommand = new Command(OnShowGeneralViewCommandExecute);

            ((LoginViewModel)loginView).ShowRegistrationView = ShowRegistrationViewCommand;
            ((LoginViewModel)loginView).ShowGeneralView = ShowGeneralViewCommand;
            ((RegistrationViewModel)registrationView).ShowLoginView = ShowLoginViewCommand;

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
            CurrentView = generalView;
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
