using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace trucking_app
{
    public partial class w_info_routes : Window
    {
        public w_info_routes()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(
                        ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connection.Open();

                    string query = "select " +
                        "(select cargo_id from shipping where id = shipping) as Код_маршрута, " +
                        "ST_AsText(location) as Местоположение, " +
                        "tmstp as Время, " +
                        "dist_from_deppnt as Расстояние_ТочкаТочка " +
                        "from routes;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        grid.ItemsSource = table.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            w_search_route wsr = new w_search_route();

            if (wsr.ShowDialog() == true)
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(
                            ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                    {
                        connection.Open();

                        string query = "select " +
                            "cargo_id as Код_маршрута, " +
                            "ST_AsText(location) as Местоположение, " +
                            "tmstp as Время, " +
                            "dist_from_deppnt as Расстояние_ТочкаТочка " +
                            "from routes join shipping on routes.shipping = shipping.id " +
                            $"where cargo_id = '{wsr.Data}';";

                        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            grid.ItemsSource = table.DefaultView;
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
}
