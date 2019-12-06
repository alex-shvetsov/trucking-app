using Newtonsoft.Json;
using System;
using System.Windows;

namespace trucking_app
{
    public partial class z_info_penalties : Window
    {
        private string penalties;

        public z_info_penalties(string penalties)
        {
            InitializeComponent();
            this.penalties = penalties;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Penalties penList = JsonConvert.DeserializeObject<Penalties>(penalties);
                fineTB.Text = penList.Fines.ToString();
                accidTB.Text = penList.Accidents.ToString();
                cargoLostTB.Text = penList.CargoLost.ToString();
                cargoBrokenTB.Text = penList.CargoBroken.ToString();
                otherTB.Text = penList.Other.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
