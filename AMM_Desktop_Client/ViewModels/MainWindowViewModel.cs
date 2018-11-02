namespace AMM_Desktop_Client.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using System.Threading.Tasks;

    public class MainWindowViewModel : ViewModelBase
    {
        private IViewModel loginView = new LoginViewModel();
        private IViewModel registrationView = new RegistrationViewModel();
        private IViewModel mainView = new MainViewModel();

        public MainWindowViewModel()
        {
            CurrentView = loginView;
            MainViewShowCommand = new Command(OnMainViewShowCommandExecute);
            ((LoginViewModel)loginView).MainViewShow = MainViewShowCommand;

            
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

        public Command MainViewShowCommand { get; private set; }

        private void OnMainViewShowCommandExecute()
        {
            CurrentView = mainView;
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
