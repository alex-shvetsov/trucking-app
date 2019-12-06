using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace trucking_app
{
    public partial class w_search_shipping : Window
    {
        public DataTable Table { get; private set; }

        public w_search_shipping()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(
                    ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connection.Open();

                    string query =
                        "select " +
                        "cargo_id as Код_груза, " +
                        "cargo_content as Содержимое_груза, " +
                        "cargo_class as Класс_груза, " +
                        "(select concat_ws(', ', make, model) from equipment where equipment.id = shipping.auto) as Кузов_авто, " +
                        "(select concat_ws(', ', make, model) from equipment where equipment.id = shipping.trailer) as Прицеп, " +
                        "container as Контейнер," +
                        "container_mass as Масса_контейнера, " +
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
                        "from shipping " +
                        $"where (select number from equipment where equipment.id = auto) like '%{autoTextBox.Text}%' and " +
                        $"(select number from equipment where equipment.id = trailer) like '%{trailerTextBox.Text}%' and " +
                        $"cargo_id like '%{cargoCodeTextBox.Text}%' and " +
                        $"cargo_class like '%{cargoClassTextBox.Text}%' and " +
                        $"container like '%{containerTextBox.Text}%' and " +
                        $"sender like '%{senderTextBox.Text}%' and " +
                        $"receiver like '%{receiverTextBox.Text}%' and " +
                        $"(select code from load_unload where id = load_op) like '%{loadTextBox.Text}%' and " +
                        $"(select code from load_unload where id = unload_op) like '%{unloadTextBox.Text}%' and " +
                        $"urgent = '{urgentCheckBox.IsChecked}' and " +
                        $"(select passport from employee where id = driver) like '%{driverTextBox.Text}%';";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        Table = new DataTable();
                        adapter.Fill(Table);
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
    }
}
