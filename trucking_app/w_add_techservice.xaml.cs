using Npgsql;
using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace trucking_app
{
    public partial class w_add_techservice : Window
    {
        public w_add_techservice()
        {
            InitializeComponent();
        }

        private void equipUnitTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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

            w_selection_grid wsg = new w_selection_grid(query);

            if (wsg.ShowDialog() == true)
            {
                equipUnitTextBox.Text = wsg.Data;
            }
        }

        private void mechTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
                $"where position.name = 'Механик';";

            w_selection_grid wsg = new w_selection_grid(query);

            if (wsg.ShowDialog() == true)
            {
                ((TextBox)sender).Text = wsg.Data;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(equipUnitTextBox.Text) ||
                    string.IsNullOrEmpty(codeTextBox.Text) ||
                    string.IsNullOrEmpty(mech1TextBox.Text) ||
                    string.IsNullOrEmpty(startTextBox.Text) ||
                    string.IsNullOrEmpty(finishTextBox.Text) ||
                    string.IsNullOrEmpty(reportTextBox.Text))
                {
                    throw new Exception("Поля не должны оставаться пустыми.");
                }

                TechService ts = new TechService();

                if (DateTime.TryParse(startTextBox.Text, out DateTime sdt))
                {
                    ts.StartTime = sdt.ToString();
                }
                else
                {
                    throw new Exception("Невозможно преобразовать дату начала обслуживания в дату.");
                }

                if (DateTime.TryParse(finishTextBox.Text, out DateTime fdt))
                {
                    ts.FinishTime = fdt.ToString();
                }
                else
                {
                    throw new Exception("Невозможно преобразовать дату завершения обслуживания в дату.");
                }

                ts.Code = codeTextBox.Text;
                ts.EquipmentUnit = equipUnitTextBox.Text;
                ts.Mech1 = mech1TextBox.Text;
                ts.Mech2 = (string.IsNullOrEmpty(mech2TextBox.Text)) ? null : mech2TextBox.Text;
                ts.Mech3 = (string.IsNullOrEmpty(mech3TextBox.Text)) ? null : mech3TextBox.Text;
                ts.Mech4 = (string.IsNullOrEmpty(mech4TextBox.Text)) ? null : mech4TextBox.Text;
                ts.Report = reportTextBox.Text;

                using (NpgsqlConnection connection = new NpgsqlConnection(
                    ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connection.Open();

                    string query =
                        $"insert into tech_service (id, code, equipment_unit, mech1, mech2, mech3, mech4, start_dt, finish_dt, report) " +
                        $"values ('{ts.ID.ToString()}', '{ts.Code}', " +
                        $"(select id from equipment where number = '{ts.EquipmentUnit}'), " +
                        $"(select id from employee where passport = '{ts.Mech1}'), " +
                        $"(select id from employee where passport = '{ts.Mech2}'), " +
                        $"(select id from employee where passport = '{ts.Mech3}'), " +
                        $"(select id from employee where passport = '{ts.Mech4}'), " +
                        $"'{ts.StartTime}', '{ts.FinishTime}', '{ts.Report}');";

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
