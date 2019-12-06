using System;
using System.Windows;

namespace trucking_app
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void branchesButton_Click(object sender, RoutedEventArgs e)
        {
            string query =
                        $"select " +
                        $"name as Наименование," +
                        $"address as Адрес," +
                        $"phone as Телефон," +
                        $"ST_AsText(location) as Местоположение " +
                        $"from branch;";

            w_add_branch wab = new w_add_branch();
            wDG wdg = new wDG("branch", query);
            wdg.ShowDialog();
        }

        private void positionsButton_Click(object sender, RoutedEventArgs e)
        {
            string query =
                $"select " +
                $"name as Наименование," +
                $"salary as Зарплата," +
                $"duties as Обязанности " +
                $"from position;";

            w_add_position wap = new w_add_position();
            wDG wdg = new wDG("position", query);
            wdg.ShowDialog();
        }

        private void employeesButton_Click(object sender, RoutedEventArgs e)
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
                $"join branch on employee.branch = branch.id;";

            wDG wdg = new wDG("employee", query);
            wdg.ShowDialog();
        }

        private void equipmentButton_Click(object sender, RoutedEventArgs e)
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
                $"from equipment;";

            wDG wdg = new wDG("equipment", query);
            wdg.ShowDialog();
        }

        private void techserviceButton_Click(object sender, RoutedEventArgs e)
        {
            string query =
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
                "from tech_service join equipment on equipment_unit = equipment.id;";

            wDG wdg = new wDG("tech_service", query);
            wdg.ShowDialog();
        }

        private void loadunloadButton_Click(object sender, RoutedEventArgs e)
        {
            string query =
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
                "from load_unload;";

            wDG wdg = new wDG("load_unload", query);
            wdg.ShowDialog();
        }

        private void shippingButton_Click(object sender, RoutedEventArgs e)
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

            wDG wdg = new wDG("shipping", query);
            wdg.ShowDialog();
        }

        private void newPointButton_Click(object sender, RoutedEventArgs e)
        {
            w_new_point wnp = new w_new_point();

            if (wnp.ShowDialog() == true)
            {
                MessageBox.Show("Точка добавлена.");
            }
        }

        private void distancesButton_Click(object sender, RoutedEventArgs e)
        {
            w_distances wd = new w_distances();
            wd.ShowDialog();
        }

        private void routesButton_Click(object sender, RoutedEventArgs e)
        {
            w_info_routes wir = new w_info_routes();
            wir.ShowDialog();
        }
    }
}
