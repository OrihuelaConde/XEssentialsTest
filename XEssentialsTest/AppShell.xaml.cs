using System;
using System.Collections.Generic;
using XEssentialsTest.ViewModels;
using XEssentialsTest.Views;
using Xamarin.Forms;

namespace XEssentialsTest
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
