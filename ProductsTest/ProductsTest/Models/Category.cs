namespace ProductsTest.Models
{
    using GalaSoft.MvvmLight.Command;
    using ProductsTest.ViewModels;
    //using ProductsTest.Views;
    using System.Collections.Generic;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Services;
    using SQLite.Net.Attributes;
    using SQLiteNetExtensions.Attributes;

    public class Category
    {
        #region Services
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Properties
        [PrimaryKey]
        public int CategoryId { get; set; }

        public string Description { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Product> Products { get; set; }
        #endregion

        #region Constructors
        public Category()
        {
            dialogService = new DialogService();
            navigationService = new NavigationService();
        }
        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return CategoryId;
        }
        #endregion

        #region Commands
        public ICommand DeleteCommand
        {
            get {
                return new RelayCommand(Delete);
            }
        }

        async void Delete()
        {
            var response = await dialogService.ShowConfirm(
                "Confirm",
                "Are you sure to delete this record?");
            if (!response)
            {
                return;
            }

            await CategoriesViewModel.GetInstance().Delete(this);
        }

        public ICommand EditCommand
        {
            get {
                return new RelayCommand(Edit);
            }
        }

        async void Edit()
        {
            MainViewModel.GetInstance().EditCategory =
                new EditCategoryViewModel(this);
            await navigationService.NavigateOnMaster("EditCategoryView");
        }

        public ICommand SelectCategoryCommand
        {
            get {
                return new RelayCommand(SelectCategory);
            }
        }

        async void SelectCategory()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Products = new ProductsViewModel(Products);
            mainViewModel.Category = this;
            await navigationService.NavigateOnMaster("ProductsView");
        }
        #endregion
    }
    //#region Servicios
    //NavigationService navigationService;
    //DialogService dialogService;
    //#endregion

    //#region Constructores
    //public Category()
    //{
    //    navigationService = new NavigationService();
    //    dialogService = new DialogService();
    //}
    //#endregion

    //#region Propiedades
    //public int CategoryId { get; set; }

    //public string Description { get; set; }

    //public List<Product> Products { get; set; }
    //#endregion

    ////public override string ToString()
    ////{
    ////    return   Description; 
    ////}

    //#region Comandos
    //public ICommand SelectCategoryCommand
    //{
    //    get {
    //        return new RelayCommand(SelectCategory);
    //    }
    //}

    //public ICommand EditCommand
    //{
    //    get {
    //        return new RelayCommand(Edit);
    //    }
    //}

    //public ICommand DeleteCommand
    //{
    //    get {
    //        return new RelayCommand(Edit);
    //    }
    //}

    //async void Delete()
    //{
    //    var response = await dialogService.ShowConfirm("Confirm", "Are you sure to delete this record?");

    //    if (!response)
    //    { return; }

    //    CategoriesViewModel.GetInstance().DeleteCategory(this);


    //}

    //async void Edit()
    //{
    //    // var mainViewModel = MainViewModel.GetInstance();
    //    MainViewModel.GetInstance().EditCategory = new EditCategoryViewModel(this);
    //    // mainViewModel.Products = new ProductsViewModel(Products);//podria mandar los del api, pero como ya los tengo en el constructor se los mando de los seleccionados
    //    // await Application.Current.MainPage.Navigation.PushAsync(new ProductsView());
    //    await navigationService.NavigateOnMaster("EditCategoryView");
    //}

    //async void SelectCategory()
    //{
    //    var mainViewModel = MainViewModel.GetInstance();
    //    mainViewModel.Category = this; //para que no se me pierda quien es la categoria seleccionada
    //    mainViewModel.Products = new ProductsViewModel(Products);//podria mandar los del api, pero como ya los tengo en el constructor se los mando de los seleccionados
    //                                                             // await Application.Current.MainPage.Navigation.PushAsync(new ProductsView());
    //    await navigationService.NavigateOnMaster("ProductsView");
    //}
    //#endregion

    ////sobre escribo el gethascode para que el put funcione
    //#region Metodos
    //public override int GetHashCode()
    //{
    //    return CategoryId;
    //}
    //#endregion
//}
}
