using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CryptoCompare;
using System.Net.Http;
using Cryptonite.Models;

namespace Cryptonite
{
	public partial class MainPage : ContentPage
	{
        //List<Coin> items;
        DataService dataService;
        public MainPage()
        {
            InitializeComponent();
            dataService = new DataService();
            RefreshData();

            var cat = dataService.GetCoinsAsync();

            var compareFromLabel = new Label { Text = "Enter the cryptocurrency you want to find the rate of" };
            var compareFrom = new Entry { Placeholder = "e.g. BTC" };
            var compareAgainstLabel = new Label { Text = "What do you want to compare it against?" };
            var compareAgainst = new Entry { Placeholder = "e.g. USD" };

            var price = new Label();
            price.SetValue(Label.TextProperty, cat);

            this.Content = new StackLayout
            {
                Children =
                {
                    compareFromLabel,
                    compareFrom,
                    compareAgainstLabel,
                    compareAgainst,
                    price
                }
            };

        }
        async void RefreshData()
        {
            var items = await dataService.GetCoinsAsync();
        }
    }

}
