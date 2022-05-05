using ChatBotMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ChatBotMobile.Views
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