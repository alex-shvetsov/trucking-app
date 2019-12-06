using Newtonsoft.Json;
using System;
using System.Windows;

namespace trucking_app
{
    public partial class w_penalties_report : Window
    {
        public string Data { get; private set; }

        public w_penalties_report()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(finesTextBox.Text) ||
                    string.IsNullOrEmpty(accidentTextBox.Text) ||
                    string.IsNullOrEmpty(cargoLostTextBox.Text) ||
                    string.IsNullOrEmpty(cargoBrokenTextBox.Text) ||
                    string.IsNullOrEmpty(otherTextBox.Text))
                {
                    throw new Exception("Поля не должны быть пустыми.");
                }

                double f, a, cl, cb, o;

                if (!double.TryParse(finesTextBox.Text, out f) ||
                    !double.TryParse(accidentTextBox.Text, out a) ||
                    !double.TryParse(cargoLostTextBox.Text, out cl) ||
                    !double.TryParse(cargoBrokenTextBox.Text, out cb) ||
                    !double.TryParse(otherTextBox.Text, out o))
                {
                    throw new Exception("Одно или несколько значений невозможно преобразовать в число.");
                }
                else
                {
                    Data = JsonConvert.SerializeObject(new Penalties
                    {
                        Fines = f,
                        Accidents = a,
                        CargoLost = cl,
                        CargoBroken = cb, 
                        Other = o
                    });
                }

                DialogResult = true;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
