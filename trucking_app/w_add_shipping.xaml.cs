using Npgsql;
using System;
using System.Configuration;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace trucking_app
{
    public partial class w_add_shipping : Window
    {
        private string contentJson;
        private string priceJson;
        private string penaltyJson;

        public w_add_shipping()
        {
            InitializeComponent();
        }

        private void penalty_createButton_Click(object sender, RoutedEventArgs e)
        {
            w_penalties_report wpr = new w_penalties_report();

            if (wpr.ShowDialog() == true)
            {
                penaltyJson = wpr.Data;
                penalty_createButton.Background = Brushes.Linen;
            }
        }

        private void price_createButton_Click(object sender, RoutedEventArgs e)
        {
            w_price_report wpr = new w_price_report();

            if (wpr.ShowDialog() == true)
            {
                priceJson = wpr.Data;
                price_createButton.Background = Brushes.Linen;
            }
        }

        private void content_createButton_Click(object sender, RoutedEventArgs e)
        {
            w_cargo_content wcc = new w_cargo_content();

            if (wcc.ShowDialog() == true)
            {
                contentJson = wcc.GetJson();
                content_createButton.Background = Brushes.Linen;
            }
        }

        private void autoTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string query =
                $"select " +
                $"number as Номер," +
                $"make as Марка, " +
                $"model as Модель, " +
                $"type as Тип, " +
                $"trailer_type as Тип_прицепа, " +
                $"dims as Габариты, " +
                $"weight_capacity as Грузоподъемность, " +
                $"volume_capacity as Вместимость, " +
                $"engine_type as Тип_двигателя, " +
                $"mass as Масса, " +
                $"price as Стоимость " +
                $"from equipment " +
                $"where type = 'Авто' or type = 'Кузов';";

            w_selection_grid wsg = new w_selection_grid(query);

            if (wsg.ShowDialog() == true)
            {
                autoTextBox.Text = wsg.Data;
            }
        }

        private void trailerTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string query =
                $"select " +
                $"number as Номер," +
                $"make as Марка, " +
                $"model as Модель, " +
                $"type as Тип, " +
                $"trailer_type as Тип_прицепа, " +
                $"dims as Габариты, " +
                $"weight_capacity as Грузоподъемность, " +
                $"volume_capacity as Вместимость, " +
                $"engine_type as Тип_двигателя, " +
                $"mass as Масса, " +
                $"price as Стоимость " +
                $"from equipment " +
                $"where type = 'Прицеп';";

            w_selection_grid wsg = new w_selection_grid(query);

            if (wsg.ShowDialog() == true)
            {
                trailerTextBox.Text = wsg.Data;
            }
        }

        private void loadTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string query =
                "select " +
                "code as Код, " +
                "type as Тип, " +
                "ST_AsText(location) as Местоположение, " +
                "executor as Исполнитель, " +
                "resp_person as Ответственное_лицо, " +
                "mechanism as Механизм, " +
                "mechanism_owner as Владелец_механизма, " +
                "method as Способ, " +
                "exp_arr_time as Ожид_время_прибытия, " +
                "exp_dep_time as Ожид_время_убытия, " +
                "act_arr_time as Факт_время_прибытия, " +
                "act_dep_time as Факт_время_убытия, " +
                "extra_time as Время_доп_операций " +
                "from load_unload " +
                "where type = 'Погрузка';";

            w_selection_grid wsg = new w_selection_grid(query);

            if (wsg.ShowDialog() == true)
            {
                loadTextBox.Text = wsg.Data;
            }
        }

        private void unloadTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string query =
                "select " +
                "code as Код, " +
                "type as Тип, " +
                "ST_AsText(location) as Местоположение, " +
                "executor as Исполнитель, " +
                "resp_person as Ответственное_лицо, " +
                "mechanism as Механизм, " +
                "mechanism_owner as Владелец_механизма, " +
                "method as Способ, " +
                "exp_arr_time as Ожид_время_прибытия, " +
                "exp_dep_time as Ожид_время_убытия, " +
                "act_arr_time as Факт_время_прибытия, " +
                "act_dep_time as Факт_время_убытия, " +
                "extra_time as Время_доп_операций " +
                "from load_unload " +
                "where type = 'Разгрузка';";

            w_selection_grid wsg = new w_selection_grid(query);

            if (wsg.ShowDialog() == true)
            {
                unloadTextBox.Text = wsg.Data;
            }
        }

        private void driverTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string query =
                $"select " +
                $"passport as Паспорт, " +
                $"employee.name as ФИО, " +
                $"sex as Пол, " +
                $"age as Возраст, " +
                $"employee.phone as Телефон, " +
                $"position.name as Должность, " +
                $"branch.name as Филиал " +
                $"from employee join position on employee.position = position.id " +
                $"join branch on employee.branch = branch.id " +
                $"where position.name = 'Водитель';";

            w_selection_grid wsg = new w_selection_grid(query);

            if (wsg.ShowDialog() == true)
            {
                driverTextBox.Text = wsg.Data;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(autoTextBox.Text) ||
                    string.IsNullOrEmpty(cargoCodeTextBox.Text) ||
                    string.IsNullOrEmpty(cargoClassTextBox.Text) ||
                    string.IsNullOrEmpty(containerTextBox.Text) || 
                    string.IsNullOrEmpty(containerMassTextBox.Text) || 
                    string.IsNullOrEmpty(senderTextBox.Text) || 
                    string.IsNullOrEmpty(receiverTextBox.Text) || 
                    string.IsNullOrEmpty(loadTextBox.Text) ||
                    string.IsNullOrEmpty(unloadTextBox.Text) || 
                    contentJson == null || priceJson == null || penaltyJson == null)
                {
                    throw new Exception("Все поля должны быть заполнены, а JSON'ы прикреплены.");
                }

                Shipping s = new Shipping();

                if (double.TryParse(containerMassTextBox.Text, out double cw) && cw > 0)
                {
                    s.ContainerWeight = cw;
                }
                else
                {
                    throw new Exception("Невозможно преобразовать значение массы контейнера в число или это число меньше 0.");
                }

                s.Auto = autoTextBox.Text;
                s.Trailer = trailerTextBox.Text;
                s.CargoCode = cargoCodeTextBox.Text;
                s.CargoClass = cargoClassTextBox.Text;
                s.Container = containerTextBox.Text;
                s.Sender = senderTextBox.Text;
                s.Receiver = receiverTextBox.Text;
                s.Driver = driverTextBox.Text;
                s.Load = loadTextBox.Text;
                s.Unload = unloadTextBox.Text;
                s.Urgent = urgentCheckBox.IsChecked.Value;

                s.CargoContent = contentJson;
                s.Price = priceJson;
                s.Penalty = penaltyJson;

                using (NpgsqlConnection connection = new NpgsqlConnection(
                   ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connection.Open();

                    string query =
                        $"insert into shipping (id, auto, trailer, cargo_id, cargo_content, cargo_class, container, " +
                        $"container_mass, sender, receiver, driver, load_op, unload_op, urgent, price, penalty) values (" +
                        $"'{s.ID.ToString()}', " +
                        $"(select id from equipment where number = '{s.Auto}'), " +
                        $"(select id from equipment where number = '{s.Trailer}'), " +
                        $"'{s.CargoCode}', '{s.CargoContent}'::jsonb, '{s.CargoClass}', '{s.Container}', '{s.ContainerWeight}', " +
                        $"'{s.Sender}', '{s.Receiver}', " +
                        $"(select id from employee where passport = '{s.Driver}'), " +
                        $"(select id from load_unload where code = '{s.Load}'), " +
                        $"(select id from load_unload where code = '{s.Unload}'), " +
                        $"'{s.Urgent}', '{s.Price}'::jsonb, '{s.Penalty}'::jsonb);";

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
