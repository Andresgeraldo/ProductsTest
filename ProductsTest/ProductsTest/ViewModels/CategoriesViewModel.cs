namespace ProductsTest.ViewModels
{
    using ProductsTest.Models;
    using System.Collections.ObjectModel;
    using Services;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using System.Threading.Tasks;

    public class CategoriesViewModel : INotifyPropertyChanged
    {
        #region Atributos
        public ObservableCollection<Category> _categories;
        List<Category> categories;
        bool _isRefreshing;
        #endregion

        #region Servicios
        ApiService apiService;
        DialogService dialogService;
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constuctores
        public CategoriesViewModel()
        {
            instance = this;
            apiService = new ApiService();
            dialogService = new DialogService();
            LoadCategories();
        }
        #endregion

        #region Singleton
        static CategoriesViewModel instance;

        public static CategoriesViewModel GetInstance()
        {
            if (instance == null)
            { return new CategoriesViewModel(); }
            return instance;
        }
        #endregion

        #region Metodos
        async void LoadCategories()
        {
            IsRefreshing = true;
            var connection = await apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            var response = await apiService.GetList<Category>(
                "http://productszuluapi.azurewebsites.net",
                "/api",
                "/Categories",
                mainViewModel.Token.TokenType,
                mainViewModel.Token.AccessToken
                );

            if (!response.IsSuccess)
            {
                await dialogService.ShowMessage("Error", response.Message);
                return;
            }

            categories = (List<Category>)response.Result; //como esto devuelve un objeto lo puedo castear a una lista de lo que desee, en este caso una lista de categoria

            CategoriesList = new ObservableCollection<Category>(categories.OrderBy(c => c.Description)); //como la view recibe una observable colection convertimos la lista que recibimos de categorias en una observable colection de la clase 
            IsRefreshing = false;
        }

        public void AddCategory(Category category)
        {
            IsRefreshing = true;
            //CategoriesList.Add(category);
            categories.Add(category);
            CategoriesList = new ObservableCollection<Category>(categories.OrderBy(c => c.Description)); //como la view recibe una observable colection convertimos la lista que recibimos de categorias en una observable colection de la clase 
            IsRefreshing = false;
        }
        public void UpdateCategory(Category category)
        {
            IsRefreshing = true;
            var oldCategory = categories.Where(
                                         c => c.CategoryId == category.CategoryId).FirstOrDefault();
            oldCategory = category;

            categories.Add(category);
            CategoriesList = new ObservableCollection<Category>(categories.OrderBy(c => c.Description)); //como la view recibe una observable colection convertimos la lista que recibimos de categorias en una observable colection de la clase 
            IsRefreshing = false;
        }
        public async Task DeleteCategory(Category category)
        {
            IsRefreshing = true;

            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRefreshing = false;
                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            var response = await apiService.Delete(
                "http://productzuluapi.azurewebsites.net",
                "/api",
                "/Categories",
                mainViewModel.Token.TokenType,
                mainViewModel.Token.AccessToken,
                category);

            if (!response.IsSuccess)
            {
                IsRefreshing = false;
                await dialogService.ShowMessage("Error",
                    response.Message);
                return;
            }

            categories.Remove(category);
            CategoriesList = new ObservableCollection<Category>(
                             categories.OrderBy(c => c.Description)); //como la view recibe una observable colection convertimos la lista que recibimos de categorias en una observable colection de la clase 

            IsRefreshing = false;
        }
        #endregion

        #region Propiedades
        public ObservableCollection<Category> CategoriesList
        {
            get { return _categories; }
            set {
                if (_categories != value)
                {
                    _categories = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CategoriesList)));

                }
            }
        }
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set {
                if (_isRefreshing != value)
                {
                    _isRefreshing = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRefreshing)));

                }
            }
        }
        #endregion

        #region Comandos
        public ICommand RefreshCommand
        {
            get { return new RelayCommand(LoadCategories); }
        }
        #endregion
    }
}
