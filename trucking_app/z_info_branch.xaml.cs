using Npgsql;
using System;
using System.Configuration;
using System.Windows;

namespace trucking_app
{
    public partial class z_info_branch : Window
    {
        private string query;

        public z_info_branch(string query)
        {
            InitializeComponent();
            this.query = query;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(
                        ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nameTB.Text = reader[0].ToString();
                            addressTB.Text = reader[1].ToString();
                            phoneTB.Text = reader[2].ToString();
                            locationTB.Text = reader[3].ToString();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
