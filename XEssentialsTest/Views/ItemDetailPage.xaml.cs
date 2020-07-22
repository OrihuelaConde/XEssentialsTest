using System.ComponentModel;
using Xamarin.Forms;
using XEssentialsTest.ViewModels;

namespace XEssentialsTest.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}