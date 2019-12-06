using System;
using System.Windows;
using Npgsql;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Windows.Controls;

namespace trucking_app
{
    public partial class wDG : Window
    {
        private string constr;
        private string tableName;
        private string selectAllQuery;

        public wDG(string tableName, string select)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.selectAllQuery = select;
            constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        }

        private void Select()
        {
            try
            { 
                using (NpgsqlConnection connection = new NpgsqlConnection(constr))
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(selectAllQuery, connection))
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dg.ItemsSource = dt.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            switch (tableName)
            {
                case "branch":
                    w_add_branch wab = new w_add_branch();
                    if (wab.ShowDialog() == true)
                    {
                        MessageBox.Show("Запись успешно добавлена.");
                    }
                    break;

                case "position":
                    w_add_position wap = new w_add_position();
                    if (wap.ShowDialog() == true)
                    {
                        MessageBox.Show("Запись успешно добавлена.");
                    }
                    break;

                case "employee":
                    w_add_employee wae1 = new w_add_employee();
                    if (wae1.ShowDialog() == true)
                    {
                        MessageBox.Show("Запись успешно добавлена.");
                    }
                    break;

                case "load_unload":
                    w_add_loadunloadop wal = new w_add_loadunloadop();
                    if (wal.ShowDialog() == true)
                    {
                        MessageBox.Show("Запись успешно добавлена.");
                    }
                    break;

                case "shipping":
                    w_add_shipping was = new w_add_shipping();
                    if (was.ShowDialog() == true)
                    {
                        MessageBox.Show("Запись успешно добавлена.");
                    }
                    break;

                case "equipment":
                    w_add_equipment wae2 = new w_add_equipment();
                    if (wae2.ShowDialog() == true)
                    {
                        MessageBox.Show("Запись успешно добавлена.");
                    }
                    break;

                case "tech_service":
                    w_add_techservice wat = new w_add_techservice();
                    if (wat.ShowDialog() == true)
                    {
                        MessageBox.Show("Запись успешно добавлена.");
                    }
                    break;
            }

            Select();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dg.SelectedIndex != -1)
                {
                    List<string> values = new List<string>();

                    foreach (var selected in dg.SelectedCells)
                    {
                        if (selected.Column.DisplayIndex == 0)
                        {
                            TextBlock tbl = selected.Column.GetCellContent(selected.Item) as TextBlock;
                            values.Add(tbl.Text);
                        }
                    }

                    string array = (new ArrayString(values)).ToString();

                    switch (tableName)
                    {
                        case "branch":
                            using (NpgsqlConnection connection = new NpgsqlConnection(
                                ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                            {
                                connection.Open();

                                string query = $"delete from branch where name in {array};";

                                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                            break;

                        case "position":
                            using (NpgsqlConnection connection = new NpgsqlConnection(
                                ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                            {
                                connection.Open();

                                string query = $"delete from position where name in {array};";

                                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                            break;

                        case "employee":
                            using (NpgsqlConnection connection = new NpgsqlConnection(
                                ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                            {
                                connection.Open();

                                string query = $"delete from employee where passport in {array};";

                                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                            break;

                        case "load_unload":
                            using (NpgsqlConnection connection = new NpgsqlConnection(
                                ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                            {
                                connection.Open();

                                string query = $"delete from load_unload where code in {array};";

                                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                            break;

                        case "shipping":
                            using (NpgsqlConnection connection = new NpgsqlConnection(
                                ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                            {
                                connection.Open();

                                string query = $"delete from {tableName} where cargo_id in {array};";

                                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                            break;

                        case "equipment":
                            using (NpgsqlConnection connection = new NpgsqlConnection(
                                ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                            {
                                connection.Open();

                                string query = $"delete from {tableName} where number in {array};";

                                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                            break;

                        case "tech_service":
                            using (NpgsqlConnection connection = new NpgsqlConnection(
                                ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                            {
                                connection.Open();

                                string query = $"delete from {tableName} where code in {array};";

                                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                            break;
                    }

                    Select();
                }
                else
                {
                    throw new Exception("Выделение пусто.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            switch (tableName)
            {
                case "branch":
                    w_search_branch wsb = new w_search_branch();
                    if (wsb.ShowDialog() == true)
                    {
                        dg.ItemsSource = wsb.Table.DefaultView;
                    }
                    break;

                case "position":
                    w_search_position wsp = new w_search_position();
                    if (wsp.ShowDialog() == true)
                    {
                        dg.ItemsSource = wsp.Table.DefaultView;
                    }
                    break;

                case "employee":
                    w_search_employee wse = new w_search_employee();
                    if (wse.ShowDialog() == true)
                    {
                        dg.ItemsSource = wse.Table.DefaultView;
                    }
                    break;

                case "load_unload":
                    w_search_loadunloadop wsl = new w_search_loadunloadop();
                    if (wsl.ShowDialog() == true)
                    {
                        dg.ItemsSource = wsl.Table.DefaultView;
                    }
                    break;

                case "shipping":
                    w_search_shipping wss = new w_search_shipping();
                    if (wss.ShowDialog() == true)
                    {
                        dg.ItemsSource = wss.Table.DefaultView;
                    }
                    break;

                case "equipment":
                    w_search_equipment wse1 = new w_search_equipment();
                    if (wse1.ShowDialog() == true)
                    {
                        dg.ItemsSource = wse1.Table.DefaultView;
                    }
                    break;

                case "tech_service":
                    w_search_techservice wst = new w_search_techservice();
                    if (wst.ShowDialog() == true)
                    {
                        dg.ItemsSource = wst.Table.DefaultView;
                    }
                    break;
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedIndex != -1)
            {
                List<string> values = new List<string>();

                foreach (var selected in dg.SelectedCells)
                {
                    if (selected.Column.DisplayIndex == 0)
                    {
                        TextBlock tbl = selected.Column.GetCellContent(selected.Item) as TextBlock;
                        values.Add(tbl.Text);
                    }
                }

                switch (tableName)
                {
                    case "branch":
                        w_update_branch wub = new w_update_branch(values);
                        if (wub.ShowDialog() == true)
                        {
                            MessageBox.Show("Успешно обновлено.");
                        }
                        break;

                    case "position":
                        w_update_position wup = new w_update_position(values);
                        if (wup.ShowDialog() == true)
                        {
                            MessageBox.Show("Успешно обновлено.");
                        }
                        break;

                    case "employee":
                        w_update_employee wue1 = new w_update_employee(values);
                        if (wue1.ShowDialog() == true)
                        {
                            MessageBox.Show("Успешно обновлено.");
                        }
                        break;

                    case "equipment":
                        w_update_equipment wue2 = new w_update_equipment(values);
                        if (wue2.ShowDialog() == true)
                        {
                            MessageBox.Show("Успешно обновлено.");
                        }
                        break;

                    default: break;
                }

                Select();
            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            DataGridRow row = sender as DataGridRow;

            if (row != null)
            {
                TextBlock tbl = dg.Columns[0].GetCellContent(row) as TextBlock;
                string query;

                if (!string.IsNullOrEmpty(tbl.Text))
                { 
                    switch (tableName)
                    {
                        case "branch":
                            query =
                                $"select " +
                                $"name as Наименование," +
                                $"address as Адрес," +
                                $"phone as Телефон," +
                                $"ST_AsText(location) as Местоположение " +
                                $"from branch where name = '{tbl.Text}'";

                            z_info_branch zib = new z_info_branch(query);
                            zib.ShowDialog();
                            break;

                        case "position":
                            query =
                                $"select " +
                                $"name as Наименование," +
                                $"salary as Зарплата," +
                                $"duties as Обязанности " +
                                $"from position where name = '{tbl.Text}';";

                            z_info_position zip = new z_info_position(query);
                            zip.ShowDialog();
                            break;

                        case "employee":
                            query =
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
                                $"where passport = '{tbl.Text}';";

                            z_info_employee zie = new z_info_employee(query);
                            zie.ShowDialog();
                            break;

                        case "equipment":
                            query =
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
                                $"from equipment where number = '{tbl.Text}';";

                            z_info_equipment zieq = new z_info_equipment(query);
                            zieq.ShowDialog();
                            break;

                        case "tech_service":
                            query =
                                "select " +
                                "code as Код, " +
                                "concat_ws(', ', equipment.make, equipment.model) as Название_техники, " +
                                "(select concat_ws(', ', name, passport) from employee where id = tech_service.mech1) as Механик1, " +
                                "(select concat_ws(', ', name, passport) from employee where id = tech_service.mech2) as Механик2, " +
                                "(select concat_ws(', ', name, passport) from employee where id = tech_service.mech3) as Механик3, " +
                                "(select concat_ws(', ', name, passport) from employee where id = tech_service.mech4) as Механик4, " +
                                "start_dt as Дата_начала_проверки, " +
                                "finish_dt as Дата_окончания_проверки," +
                                "report as Отчет " +
                                "from tech_service join equipment on equipment_unit = equipment.id " +
                               $"where code = '{tbl.Text}';";

                            z_info_tech_service zits = new z_info_tech_service(query);
                            zits.ShowDialog();
                            break;

                        case "load_unload":
                            query =
                                "select " +
                                "code as Код, " +
                                "type as Тип, " +
                                "ST_AsText(location) as Местоположение, " +
                                "executor as Исполнитель, " +
                                "resp_person as Ответственное_лицо, " +
                                "(select concat_ws(', ', make, model) from equipment where equipment.id = mechanism) as Механизм, " +
                                "mechanism_owner as Владелец_механизма, " +
                                "method as Способ, " +
                                "exp_arr_time as Ожид_время_прибытия, " +
                                "exp_dep_time as Ожид_время_убытия, " +
                                "act_arr_time as Факт_время_прибытия, " +
                                "act_dep_time as Факт_время_убытия, " +
                                "extra_time as Время_доп_операций " +
                               $"from load_unload where code = '{tbl.Text}';";

                            z_info_load_unload zilu = new z_info_load_unload(query);
                            zilu.ShowDialog();
                            break;

                        case "shipping":
                            query =
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
                               $"from shipping where cargo_id = '{tbl.Text}';";

                            z_info_shipping zis = new z_info_shipping(query);
                            zis.ShowDialog();
                            break;
                    }
                }
            }
        }
    }
}
