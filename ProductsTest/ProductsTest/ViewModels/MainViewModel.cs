namespace ProductsTest.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProductsTest.Models;
    using ProductsTest.Services;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MainViewModel
    {
        #region Services
        NavigationService navigationService;
        #endregion

        #region Properties
        public ObservableCollection<Menu> MyMenu
        {
            get;
            set;
        }

        public LoginViewModel Login
        {
            get;
            set;
        }

        public CategoriesViewModel Categories
        {
            get;
            set;
        }

        public TokenResponse Token
        {
            get;
            set;

        }

        public ProductsViewModel Products
        {
            get;
            set;
        }

        public NewCategoryViewModel NewCategory
        {
            get;
            set;
        }

        public EditCategoryViewModel EditCategory
        {
            get;
            set;
        }

        public NewProductViewModel NewProduct
        {
            get;
            set;
        }

        public Category Category
        {
            get;
            set;
        }

        public EditProductViewModel EditProduct
        {
            get;
            set;
        }

        public NewCustomerViewModel NewCustomer
        {
            get;
            set;
        }

        public UbicationsViewModel Ubications
        {
            get;
            set;
        }

        public SyncViewModel Sync
        {
            get;
            set;
        }

        public MyProfileViewModel MyProfile
        {
            get;
            set;
        }

        public PasswordRecoveryViewModel PasswordRecovery
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;

            navigationService = new NavigationService();

            Login = new LoginViewModel();
            LoadMenu();
        }
        #endregion

        #region Sigleton
        static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion

        #region Methods
        public void RegisterDevice()
        {
            var register = DependencyService.Get<IRegisterDevice>();
            register.RegisterDevice();
        }

        void LoadMenu()
        {
            MyMenu = new ObservableCollection<Menu>();

            MyMenu.Add(new Menu
            {
                Icon = "ic_settings",
                PageName = "MyProfileView",
                Title = "My Profile",
            });

            MyMenu.Add(new Menu
            {
                Icon = "ic_map",
                PageName = "UbicationsView",
                Title = "Ubications",
            });

            MyMenu.Add(new Menu
            {
                Icon = "ic_sync",
                PageName = "SyncView",
                Title = "Sync Offline Operations",
            });

            MyMenu.Add(new Menu
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginView",
                Title = "Close sesion",
            });

        }
        #endregion

        #region Commands
        public ICommand NewProductCommand
        {
            get {
                return new RelayCommand(GoNewProduct);
            }
        }

        async void GoNewProduct()
        {
            NewProduct = new NewProductViewModel();
            await navigationService.NavigateOnMaster("NewProductView");
        }

        public ICommand NewCategoryCommand
        {
            get {
                return new RelayCommand(GoNewCategory);
            }
        }

        async void GoNewCategory()
        {
            NewCategory = new NewCategoryViewModel();
            await navigationService.NavigateOnMaster("NewCategoryView");
        }
        #endregion
    }
    //#region Servicios
    //NavigationService navigationService;
    //#endregion

    //#region Propiedades

    //public LoginViewModel Login { get; set; }
    //public CategoriesViewModel Categories { get; set; }
    //public ProductsViewModel Products { get; set; }
    //public TokenResponse Token { get; set; }
    //public ObservableCollection<Menu> MyMenu { get; set; }
    //public NewCategoryViewModel NewCategory { get; set; }
    //public EditCategoryViewModel EditCategory { get; set; }
    //public NewProductViewModel NewProduct { get; set; }
    //public Category Category { get; set; }
    //public EditProductViewModel EditProduct { get; set; }
    //public NewCustomerViewModel NewCustomer { get; set; }
    //public UbicationsViewModel Ubications { get; set; }
    //public SyncViewModel Sync { get; set; }
    //public MyProfileViewModel MyProfile { get; set; }
    //public PasswordRecoveryViewModel PasswordRecovery { get; set; }

    //#endregion

    //#region Constructor
    //public MainViewModel()
    //{
    //    //normalmente no se instancias todas las viewmodels en constructor, sin embargo la viewmodel 
    //    //por donde arranca el programa se debe inicializar aqui
    //    instance = this;
    //    navigationService = new NavigationService();
    //    Login = new LoginViewModel();
    //    LoadMenu();
    //}
    //#endregion

    //#region Singleton
    //static MainViewModel instance;

    //public static MainViewModel GetInstance()
    //{
    //    if (instance == null)
    //    { return new MainViewModel(); }
    //    return instance;
    //}
    //#endregion

    //#region Comandos
    //public ICommand NewProductCommand
    //{
    //    get {
    //        return new RelayCommand(GoNewProduct);
    //    }
    //}

    //async void GoNewProduct()
    //{
    //    NewProduct = new NewProductViewModel();
    //    await navigationService.NavigateOnMaster("NewProductView");
    //}

    //public ICommand NewCategoryCommand
    //{
    //    get {
    //        return new RelayCommand(GoNewCategory);
    //    }
    //}
    ////porque ya tengo una porpiedad del mismo nombre le pongo el Go
    //async void GoNewCategory()
    //{
    //    NewCategory = new NewCategoryViewModel();
    //    await navigationService.NavigateOnMaster("NewCategoryView");
    //}

    //#endregion

    //#region Metodos
    //void LoadMenu()
    //{
    //    MyMenu = new ObservableCollection<Menu>();

    //    MyMenu.Add(new Menu
    //    {
    //        Icon = "ic_settings",
    //        PageName = "MyProfileView",
    //        Title = "My Profile",
    //    });

    //    MyMenu.Add(new Menu
    //    {
    //        Icon = "ic_map",
    //        PageName = "UbicationsView",
    //        Title = "Ubications",
    //    });

    //    MyMenu.Add(new Menu
    //    {
    //        Icon = "ic_sync",
    //        PageName = "SyncView",
    //        Title = "Sync Offline Operations",
    //    });

    //    MyMenu.Add(new Menu
    //    {
    //        Icon = "ic_exit_to_app",
    //        PageName = "LoginView",
    //        Title = "Close sesion",
    //    });

    //}
    //#endregion
}
 
