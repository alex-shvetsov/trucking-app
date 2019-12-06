using Npgsql;
using System;
using System.Configuration;
using System.Windows;

namespace trucking_app
{
    public partial class w_add_branch : Window
    {
        public w_add_branch()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(branchNameTextBox.Text) ||
                    string.IsNullOrEmpty(branchAddressTextBox.Text) ||
                    string.IsNullOrEmpty(branchPhoneTextBox.Text) ||
                    string.IsNullOrEmpty(latitudeTextBox.Text) ||
                    string.IsNullOrEmpty(longitudeTextBox.Text))
                {
                    throw new Exception("Все поля должны быть заполнены.");
                }

                if (latitudeTextBox.Text.Contains(".")) latitudeTextBox.Text = latitudeTextBox.Text.Replace(".", ",");
                if (longitudeTextBox.Text.Contains(".")) longitudeTextBox.Text = longitudeTextBox.Text.Replace(".", ",");

                double lat, lon;

                if (!double.TryParse(latitudeTextBox.Text, out lat))
                {
                    throw new Exception("Невозможно преобразовать широту в число.");
                }

                if (!double.TryParse(longitudeTextBox.Text, out lon))
                {
                    throw new Exception("Невозможно преобразовать долготу в число.");
                }

                Branch branch = new Branch();

                branch.Name = branchNameTextBox.Text;
                branch.Address = branchAddressTextBox.Text;
                branch.Phone = branchPhoneTextBox.Text;
                branch.Latitude = lat;
                branch.Longitude = lon;

                using (NpgsqlConnection connection = new NpgsqlConnection(
                    ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connection.Open();

                    string query =
                        $"insert into branch (id, name, address, phone, location) " +
                        $"values ('{branch.ID.ToString()}', '{branch.Name}', '{branch.Address}', '{branch.Phone}', " +
                        $"ST_SetSRID(ST_MakePoint({branch.Longitude.ToString().Replace(",", ".")}, " +
                        $"{branch.Latitude.ToString().Replace(",", ".")}), 4326));";

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
