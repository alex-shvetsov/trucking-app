using Newtonsoft.Json;
using System;
using System.Windows;

namespace trucking_app
{
    public partial class z_info_price : Window
    {
        private string price;

        public z_info_price(string price)
        {
            InitializeComponent();
            this.price = price;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                PriceList priceList = JsonConvert.DeserializeObject<PriceList>(price);
                serviceTB.Text = priceList.Service.ToString();
                loadUnloadTB.Text = priceList.LoadUnload.ToString();
                loadTB.Text = priceList.OverTLoad.ToString();
                unloadTB.Text = priceList.OverTUnload.ToString();
                urgeTB.Text = priceList.Urge.ToString();
                specTranTB.Text = priceList.SpecTran.ToString();
                otherTB.Text = priceList.Other.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
