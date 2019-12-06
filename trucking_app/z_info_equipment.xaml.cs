using Npgsql;
using System;
using System.Configuration;
using System.Windows;

namespace trucking_app
{
    public partial class z_info_equipment : Window
    {
        private string query;

        public z_info_equipment(string query)
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
                            numberTB.Text = reader[0].ToString();
                            makeTB.Text = reader[1].ToString();
                            modelTB.Text = reader[2].ToString();
                            typeTB.Text = reader[3].ToString();
                            trailerTypeTB.Text = reader[4].ToString();
                            dimTB.Text = reader[5].ToString();
                            wcapTB.Text = reader[6].ToString();
                            vcapTB.Text = reader[7].ToString();
                            engineTypeTB.Text = reader[8].ToString();
                            massTB.Text = reader[9].ToString();
                            priceTB.Text = reader[10].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
