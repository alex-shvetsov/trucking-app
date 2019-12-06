using Npgsql;
using System;
using System.Configuration;
using System.Windows;

namespace trucking_app
{
    public partial class z_info_load_unload : Window
    {
        private string query;

        public z_info_load_unload(string query)
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
                            codeTB.Text = reader[0].ToString();
                            typeTB.Text = reader[1].ToString();
                            locTB.Text = reader[2].ToString();
                            execTB.Text = reader[3].ToString();
                            respTB.Text = reader[4].ToString();
                            mechTB.Text = reader[5].ToString();
                            mechOwnerTB.Text = reader[6].ToString();
                            methodTB.Text = reader[7].ToString();
                            eatTB.Text = reader[8].ToString();
                            edtTB.Text = reader[9].ToString();
                            aatTB.Text = reader[10].ToString();
                            adtTB.Text = reader[11].ToString();
                            extraTB.Text = reader[12].ToString();
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
