using Yaqeen.App.Models;
using Yaqeen.App.PageModels;

namespace Yaqeen.App.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}