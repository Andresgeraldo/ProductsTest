namespace ProductsTest.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Services;

    public class LoginViewModel : INotifyPropertyChanged
    {

        #region Atributos
        string _email;
        string _password;
        bool _isToggled;
        bool _isRunning; //los boobleanos siempre inicializan en falso
        bool _isEnabled;
        #endregion

        #region Comandos
        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }

        }

        async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await dialogService.ShowMessage(
                    "Error",
                    "You must enter an email");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await dialogService.ShowMessage(
                    "Error",
                    "You must enter a password");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var connection = await apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await dialogService.ShowMessage("Error", connection.Message);
                IsRunning = false;
                IsEnabled = true;
                return;
            }

            var response = await apiService.GetToken("http://productszuluapi.azurewebsites.net", Email, Password);

            if (response == null)
            {
                await dialogService.ShowMessage("Error", "The servise is not available, please try later");
                IsRunning = false;
                IsEnabled = true;
                Password = null;
                return;
            }

            if (string.IsNullOrEmpty(response.AccessToken))
            {
                await dialogService.ShowMessage("Error", response.ErrorDescription);
                IsRunning = false;
                IsEnabled = true;
                Password = null;
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = response;
            mainViewModel.Categories = new CategoriesViewModel();

            //una view model no debe conocer una view ni viceversa, es pecado que una viewmodel vea las views (pages)
            // await Application.Current.MainPage.Navigation.PushAsync(new CategoriesView());
            await navigationService.NavigateOnLogin("CategoriesView");
            Email = null;
            Password = null;
            IsRunning = false;
            IsEnabled = true;

        }
        #endregion

        #region Constructores
        public LoginViewModel()
        {
            IsEnabled = true;
            IsToggled = true;
            dialogService = new DialogService();
            apiService = new ApiService();
            navigationService = new NavigationService();
        }
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Propiedades
        public string Email
        {
            get {
                return _email;
            }
            set {
                if (_email != value)
                {
                    _email = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
                }
            }
        }

        public string Password
        {
            get {
                return _password;
            }
            set {
                if (_password != value)
                {
                    _password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
                }
            }
        }

        public bool IsToggled
        {
            get {
                return _isToggled;
            }
            set {
                if (_isToggled != value)
                {
                    _isToggled = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsToggled)));
                }
            }
        }

        public bool IsRunning
        {
            get {
                return _isRunning;
            }
            set {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }

        public bool IsEnabled
        {
            get {
                return _isEnabled;
            }
            set {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEnabled)));
                }
            }
        }
        #endregion

        #region Services
        DialogService dialogService;
        ApiService apiService;
        NavigationService navigationService;
        #endregion

    }
}
