using ProductsTest.Models;

namespace ProductsTest.ViewModels
{
    public class MainViewModel
    {
        #region Propiedades
        public LoginViewModel Login { get; set; }
        public CategoriesViewModel Categories { get; set; }
        public TokenResponse Token { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            //normalmente no se instancias todas las viewmodels en constructor, sin embargo la viewmodel 
            //por donde arranca el programa se debe inicializar aqui
            instance = this;

            Login = new LoginViewModel();
        }
        #endregion

        #region Singleton
        static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            { return new MainViewModel(); }
            return instance;
        }
        #endregion
    }
}
