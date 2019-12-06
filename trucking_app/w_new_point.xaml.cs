using Npgsql;
using System;
using System.Configuration;
using System.Windows;
using System.Windows.Input;

namespace trucking_app
{
    public partial class w_new_point : Window
    {
        public w_new_point()
        {
            InitializeComponent();
        }

        private void shippingTB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string query =
                "select " +
                "cargo_id as Код_груза, " +
                "cargo_content as Содержимое_груза, " +
                "cargo_class as Класс_груза, " +
                "(select concat_ws(', ', make, model) from equipment where equipment.id = shipping.auto) as Кузов_авто, " +
                "(select concat_ws(', ', make, model) from equipment where equipment.id = shipping.trailer) as Прицеп, " +
                "container as Контейнер," +
                "container_mass as Масса_контейнера, " +
                "gross_weight as Масса_брутто, " +
                "sender as Отправитель, " +
                "receiver as Получатель, " +
                "(select concat_ws(', ', employee.name, employee.passport) from employee where employee.id = shipping.driver) as Водитель, " +
                "(select code from load_unload where load_unload.id = shipping.load_op) as Код_погрузки, " +
                "(select code from load_unload where load_unload.id = shipping.unload_op) as Код_разгрузки, " +
                "urgent as Срочно, " +
                "price as Стоимость, " +
                "penalty as Неустойка, " +
                "total as Итого, " +
                "ST_AsText(curr_location) as Местоположение_груза, " +
                "delivered as Доставлен " +
                "from shipping;";

            w_selection_grid wsg = new w_selection_grid(query);

            if (wsg.ShowDialog() == true)
            {
                shippingTB.Text = wsg.Data;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(shippingTB.Text) ||
                    string.IsNullOrEmpty(xTB.Text) ||
                    string.IsNullOrEmpty(yTB.Text))
                {
                    throw new Exception("Все поля должны быть заполнены.");
                }

                if (xTB.Text.Contains(".")) xTB.Text = xTB.Text.Replace(".", ",");
                if (yTB.Text.Contains(".")) yTB.Text = yTB.Text.Replace(".", ",");

                double lat, lon;

                if (!double.TryParse(xTB.Text, out lat))
                {
                    throw new Exception("Невозможно преобразовать широту в число.");
                }

                if (!double.TryParse(yTB.Text, out lon))
                {
                    throw new Exception("Невозможно преобразовать долготу в число.");
                }

                using (NpgsqlConnection connection = new NpgsqlConnection(
                    ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connection.Open();

                    string currentPoint = $"ST_SetSRID(ST_MakePoint({lon.ToString().Replace(",", ".")}, {lat.ToString().Replace(",", ".")}), 4326)";
                    string lastPoint = 
                        $"(select location from routes where shipping = " +
                        $"(select id from shipping where cargo_id = '{shippingTB.Text}') " +
                        $"order by tmstp desc limit 1)";

                    string query1 = $"insert into routes (shipping, location, dist_from_deppnt) values (" +
                        $"(select id from shipping where cargo_id = '{shippingTB.Text}'), " +
                        $"{currentPoint}," +
                        $"(select coalesce(st_distance_sphere({currentPoint}, {lastPoint}), 0)));";
                    string query2 = $"update shipping set curr_location = {currentPoint};";

                    using (NpgsqlCommand command1 = new NpgsqlCommand(query1, connection))
                    using (NpgsqlCommand command2 = new NpgsqlCommand(query2, connection))
                    {
                        command1.ExecuteNonQuery();
                        command2.ExecuteNonQuery();
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
