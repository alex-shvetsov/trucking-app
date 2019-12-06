using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;

namespace trucking_app
{
    public partial class w_update_branch : Window
    {
        private List<string> values;

        public w_update_branch(List<string> values)
        {
            InitializeComponent();
            this.values = values;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double lat = 0, lon = 0;

                if (!string.IsNullOrEmpty(latitudeTextBox.Text) && !string.IsNullOrEmpty(longitudeTextBox.Text))
                {
                    if (!double.TryParse(latitudeTextBox.Text, out lat))
                    {
                        throw new Exception("Невозможно преобразовать широту в число.");
                    }

                    if (!double.TryParse(longitudeTextBox.Text, out lon))
                    {
                        throw new Exception("Невозможно преобразовать долготу в число.");
                    }
                }

                List<string> array = new List<string>();

                if (nameCB.IsChecked.Value)
                {
                    array.Add($"name = '{branchNameTextBox.Text}'");
                }

                if (addressCB.IsChecked.Value)
                {
                    array.Add($"address = '{branchAddressTextBox.Text}'");
                }

                if (phoneCB.IsChecked.Value)
                {
                    array.Add($"phone = '{branchPhoneTextBox.Text}'");
                }

                if (locationCB.IsChecked.Value)
                {
                    array.Add($"location = ST_SetSRID(ST_MakePoint({lon.ToString().Replace(",", ".")}, {lat.ToString().Replace(",", ".")}), 4326)");
                }

                string set = string.Join(", ", array.ToArray());

                string query = $"update branch set {set} where name in {new ArrayString(values).ToString()};";

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }
    }
}
