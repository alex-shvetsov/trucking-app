using Npgsql;
using System;
using System.Configuration;
using System.Windows;
using System.Windows.Input;

namespace trucking_app
{
    public partial class w_add_employee : Window
    {
        public w_add_employee()
        {
            InitializeComponent();
        }

        private void positionTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string query =
                $"select " +
                $"name as Наименование," +
                $"salary as Зарплата," +
                $"duties as Обязанности " +
                $"from position;";

            w_selection_grid wsg = new w_selection_grid(query);

            if (wsg.ShowDialog() == true)
            {
                positionTextBox.Text = wsg.Data;
            }
        }

        private void branchTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string query =
                $"select " +
                $"name as Наименование," +
                $"address as Адрес," +
                $"phone as Телефон," +
                $"ST_AsText(location) as Местоположение " +
                $"from branch;";

            w_selection_grid wsg = new w_selection_grid(query);

            if (wsg.ShowDialog() == true)
            {
                branchTextBox.Text = wsg.Data;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(nameTextBox.Text) ||
                    string.IsNullOrEmpty(ageTextBox.Text) ||
                    string.IsNullOrEmpty(phoneTextBox.Text) ||
                    string.IsNullOrEmpty(passportTextBox.Text) ||
                    string.IsNullOrEmpty(positionTextBox.Text) ||
                    string.IsNullOrEmpty(branchTextBox.Text))
                {
                    throw new Exception("Поля не должны оставаться пустыми.");
                }

                Employee employee = new Employee();

                if (int.TryParse(ageTextBox.Text, out int age) && age > 0 && age < 100)
                {
                    employee.Age = age;
                }
                else
                {
                    throw new Exception("Невозможно преобразовать возраст в число или возраст не попадает в диапазон (0;100).");
                }

                employee.Name = nameTextBox.Text;
                employee.Sex = sexComboBox.SelectedValue.ToString();
                employee.Phone = phoneTextBox.Text;
                employee.Passport = passportTextBox.Text;
                employee.Position = positionTextBox.Text;
                employee.Branch = branchTextBox.Text;

                using (NpgsqlConnection connection = new NpgsqlConnection(
                    ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connection.Open();

                    string query =
                        $"insert into employee (id, name, sex, age, phone, passport, position, branch) " +
                        $"values ('{employee.ID.ToString()}', '{employee.Name}', '{employee.Sex.Contains("Мужской")}', '{employee.Age}', " +
                        $"'{employee.Phone}', '{employee.Passport}', " +
                        $"(select id from position where name = '{employee.Position}'), " +
                        $"(select id from branch where name = '{employee.Branch}'));";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                DialogResult = true;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
