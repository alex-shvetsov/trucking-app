using Newtonsoft.Json;
using System;
using System.Windows;

namespace trucking_app
{
    public partial class w_price_report : Window
    {
        public string Data { get; private set; }

        public w_price_report()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(serviceTextBox.Text) ||
                    string.IsNullOrEmpty(loadunloadTextBox.Text) ||
                    string.IsNullOrEmpty(overtloadTextBox.Text) ||
                    string.IsNullOrEmpty(overtunloadTextBox.Text) ||
                    string.IsNullOrEmpty(urgeTextBox.Text) ||
                    string.IsNullOrEmpty(specTranTextBox.Text) ||
                    string.IsNullOrEmpty(otherTextBox.Text))
                {
                    throw new Exception("Поля не должны быть пустыми.");
                }

                double s, lu, otl, otul, u, st, o;

                if (!double.TryParse(serviceTextBox.Text, out s) ||
                    !double.TryParse(loadunloadTextBox.Text, out lu) ||
                    !double.TryParse(overtloadTextBox.Text, out otl) ||
                    !double.TryParse(overtunloadTextBox.Text, out otul) ||
                    !double.TryParse(urgeTextBox.Text, out u) ||
                    !double.TryParse(specTranTextBox.Text, out st) ||
                    !double.TryParse(otherTextBox.Text, out o))
                {
                    throw new Exception("Одно или несколько значений невозможно преобразовать в число.");
                }
                else
                {
                    Data = JsonConvert.SerializeObject(new PriceList
                    {
                        Service = s,
                        LoadUnload = lu,
                        OverTLoad = otl,
                        OverTUnload = otul,
                        Urge = u,
                        SpecTran = st,
                        Other = o
                    });
                }

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
