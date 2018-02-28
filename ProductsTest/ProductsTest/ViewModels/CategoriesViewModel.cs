namespace ProductsTest.ViewModels
{
    using ProductsTest.Models;
    using System;
    using System.Collections.ObjectModel;

    public class CategoriesViewModel
    {
        #region Constuctores
        public CategoriesViewModel()
        {
            LoadCategories();
        }
        #endregion

        #region Metodos
        private void LoadCategories()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Propiedades
        public ObservableCollection<Category> Categories { get; set; }
        #endregion
    }
}
