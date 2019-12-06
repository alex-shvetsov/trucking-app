using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;

namespace trucking_app
{
    public partial class w_update_equipment : Window
    {
        private List<string> values;

        public w_update_equipment(List<string> values)
        {
            InitializeComponent();
            this.values = values;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal price;
                double wcap, vcap, weight;

                if (!decimal.TryParse(priceTextBox.Text, out price) && price > 0 )
                {
                    throw new Exception("Невозможно преобразовать возраст в число или возраст не попадает в диапазон (0;100).");
                }

                if (!double.TryParse(wcapTextBox.Text, out wcap) && wcap > 0)
                {
                    throw new Exception("Невозможно преобразовать возраст в число или возраст не попадает в диапазон (0;100).");
                }

                if (!double.TryParse(vcapTextBox.Text, out vcap) && vcap > 0)
                {
                    throw new Exception("Невозможно преобразовать возраст в число или возраст не попадает в диапазон (0;100).");
                }

                if (!double.TryParse(massTextBox.Text, out weight) && weight > 0)
                {
                    throw new Exception("Невозможно преобразовать возраст в число или возраст не попадает в диапазон (0;100).");
                }

                List<string> array = new List<string>();

                if (makeCB.IsChecked.Value)
                {
                    array.Add($"make = {makeTextBox.Text}");
                }

                if (modelCB.IsChecked.Value)
                {
                    array.Add($"model = {modeltextBox.Text}");
                }

                if (typeCB.IsChecked.Value)
                {
                    array.Add($"type = {typeComboBox.Text}");
                }

                if (trailerTypeCB.IsChecked.Value)
                {
                    array.Add($"trailer_type = {trailerTypeTextBox.Text}");
                }

                if (numberCB.IsChecked.Value)
                {
                    array.Add($"number = {numberTextBox.Text}");
                }

                if (dimCB.IsChecked.Value)
                {
                    array.Add($"dims = {dimTextBox.Text}");
                }

                if (wcapCB.IsChecked.Value)
                {
                    array.Add($"weight_capacity = {wcapTextBox.Text}");
                }

                if (vcapCB.IsChecked.Value)
                {
                    array.Add($"volume_capacity = {vcapTextBox.Text}");
                }

                if (engineTypeCB.IsChecked.Value)
                {
                    array.Add($"engine_type = {engineTypeTextBox.Text}");
                }

                if (massCB.IsChecked.Value)
                {
                    array.Add($"mass = {massTextBox.Text}");
                }

                if (priceCB.IsChecked.Value)
                {
                    array.Add($"price = {priceTextBox.Text}");
                }

                string set = string.Join(", ", array.ToArray());

                string query = $"update equipment set {set} where number in {new ArrayString(values).ToString()};";

                using (NpgsqlConnection connection = new NpgsqlConnection(
                    ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
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
