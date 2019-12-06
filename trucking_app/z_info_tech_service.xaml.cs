using Npgsql;
using System;
using System.Configuration;
using System.Windows;

namespace trucking_app
{
    public partial class z_info_tech_service : Window
    {
        private string query;

        public z_info_tech_service(string query)
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
                            equipmentTB.Text = reader[1].ToString();
                            mech1TB.Text = reader[2].ToString();
                            mech2TB.Text = reader[3].ToString();
                            mech3TB.Text = reader[4].ToString();
                            mech4TB.Text = reader[5].ToString();
                            startTB.Text = reader[6].ToString();
                            finishTB.Text = reader[7].ToString();
                            reportTB.Text = reader[8].ToString();
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
