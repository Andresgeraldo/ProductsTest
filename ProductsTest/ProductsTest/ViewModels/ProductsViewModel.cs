
namespace ProductsTest.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using ProductsTest.Models;
    using ProductsTest.Services;

    public class ProductsViewModel : INotifyPropertyChanged
    {
        #region Atributos
        List<Product> products;
        public ObservableCollection<Product> _products;
        #endregion

        #region Servicios
        ApiService apiService;
        DialogService dialogService;
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public ProductsViewModel(List<Product> products)
        {
            this.products = products;
            Products = new ObservableCollection<Product>(products.OrderBy(p => p.Description));
        }


        #endregion

        #region Propiedades
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set {
                if (_products != value)
                {
                    _products = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Products)));

                }
            }
        }
        #endregion

    }
}
