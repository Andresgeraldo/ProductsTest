namespace ProductsTest.Models
{
    using GalaSoft.MvvmLight.Command;
    using ProductsTest.ViewModels;
    //using ProductsTest.Views;
    using System.Collections.Generic;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Services;

    public class Category
    {
        #region Servicios
        NavigationService navigationService;
        #endregion

        #region Constructores
        public Category()
        {
            navigationService = new NavigationService();
        }
        #endregion
        #region Propiedades
        public int CategoryId { get; set; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }
        #endregion

        //public override string ToString()
        //{
        //    return   Description; 
        //}
        #region Comandos
        public ICommand SelectCategoryCommand
        {
            get {
                return new RelayCommand(SelectCategory);
            }
        }

        async void SelectCategory()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Products = new ProductsViewModel(Products);//podria mandar los del api, pero como ya los tengo en el constructor se los mando de los seleccionados
                                                                     // await Application.Current.MainPage.Navigation.PushAsync(new ProductsView());
            await navigationService.NavigateOnMaster("ProductsView");
        }
        #endregion
    }
}
