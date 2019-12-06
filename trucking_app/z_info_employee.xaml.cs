using Npgsql;
using System;
using System.Configuration;
using System.Windows;

namespace trucking_app
{
    public partial class z_info_employee : Window
    {
        private string query;

        public z_info_employee(string query)
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
                            passportTB.Text = reader[0].ToString();
                            nameTB.Text = reader[1].ToString();
                            sexTB.Text = reader[2].ToString() == true.ToString() ? "Мужчина": "Женщина";
                            ageTB.Text = reader[3].ToString();
                            phoneTB.Text = reader[4].ToString();
                            positionTB.Text = reader[5].ToString();
                            branchTB.Text = reader[6].ToString();
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
