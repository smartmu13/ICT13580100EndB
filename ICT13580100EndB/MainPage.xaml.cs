using System;
using System.Collections.Generic;
using ICT13580100EndB.Models;
using Xamarin.Forms;

namespace ICT13580100EndB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            newButton.Clicked += NewButton_Clicked;
        }
        protected override void OnAppearing()
        {
            LoadData();
        }

		void LoadData()
		{
            productListView.ItemsSource = App.DbHelper.GetProdcut();

		}
        void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ProductCarPage());
        }


        void Edit_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as ProductCar;
            Navigation.PushModalAsync(new ProductCarPage(product));
        }

        void Delete_Clicked(object sender, System.EventArgs e)
        {
            
        }
    }
}
