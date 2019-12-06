using Npgsql;
using System;
using System.Configuration;
using System.Windows;

namespace trucking_app
{
    public partial class z_info_shipping : Window
    {
        private string query;
        private string content;
        private string price;
        private string penalty;

        public z_info_shipping(string query)
        {
            InitializeComponent();
            this.query = query;
        }

        private void cargoContentButton_Click(object sender, RoutedEventArgs e)
        {
            z_info_cargo_content zicc = new z_info_cargo_content(content);
            zicc.ShowDialog();
        }

        private void penaltyButton_Click(object sender, RoutedEventArgs e)
        {
            z_info_penalties zip = new z_info_penalties(penalty);
            zip.ShowDialog();
        }

        private void priceButton_Click(object sender, RoutedEventArgs e)
        {
            z_info_price zis = new z_info_price(price);
            zis.ShowDialog();
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
                            cargoidTB.Text = reader[0].ToString();
                            content = reader[1].ToString();
                            cargoClassTB.Text = reader[2].ToString();
                            autoTB.Text = reader[3].ToString();
                            trailerTB.Text = reader[4].ToString();
                            containerTB.Text = reader[5].ToString();
                            contWeightTB.Text = reader[6].ToString();
                            grossWeightTB.Text = reader[7].ToString();
                            senderTB.Text = reader[8].ToString();
                            receiverTB.Text = reader[9].ToString();
                            driverTB.Text = reader[10].ToString();
                            loadTB.Text = reader[11].ToString();
                            unloadTB.Text = reader[12].ToString();
                            urgeTB.Text = reader[13].ToString() == true.ToString() ? "Да" : "Нет";
                            price = reader[14].ToString();
                            penalty = reader[15].ToString();
                            totalTB.Text = reader[16].ToString();
                            locTB.Text = reader[17].ToString();
                            deliveredTB.Text = reader[18].ToString() == true.ToString() ? "Да" : "Нет";
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
