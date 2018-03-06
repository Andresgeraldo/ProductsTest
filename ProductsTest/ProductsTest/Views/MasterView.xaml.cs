namespace ProductsTest.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterView : MasterDetailPage
    {
        public MasterView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Navigator = Navigator;
            App.Master = this;
        }
    }
    //public partial class MasterView : MasterDetailPage
    //{
    //    public MasterView()
    //    {
    //        InitializeComponent();
    //    }
    //}
}