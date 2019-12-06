using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.Windows.Input;

namespace trucking_app
{
    public partial class w_update_employee : Window
    {
        private List<string> values;

        public w_update_employee(List<string> values)
        {
            InitializeComponent();
            this.values = values;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int age;

                if (!int.TryParse(ageTextBox.Text, out age) && age > 0 && age < 100)
                {
                    throw new Exception("Невозможно преобразовать возраст в число или возраст не попадает в диапазон (0;100).");
                }

                List<string> array = new List<string>();

                if (nameCB.IsChecked.Value)
                {
                    array.Add($"name = '{nameTextBox.Text}'");
                }

                if (sexCB.IsChecked.Value)
                {
                    array.Add($"sex = {sexComboBox.Text == "Мужской"}");
                }

                if (ageCB.IsChecked.Value)
                {
                    array.Add($"age = {age}");
                }

                if (phoneCB.IsChecked.Value)
                {
                    array.Add($"phone = '{phoneTextBox.Text}'");
                }

                if (passportCB.IsChecked.Value)
                {
                    array.Add($"passport = '{passportTextBox.Text}'");
                }

                if (positionCB.IsChecked.Value)
                {
                    array.Add($"position = (select id from position where name = '{positionTextBox.Text}')");
                }

                if (branchCB.IsChecked.Value)
                {
                    array.Add($"branch = (select id from branch where name = '{branchTextBox.Text}')");
                }

                string set = string.Join(", ", array.ToArray());

                string query = $"update employee set {set} where passport in {new ArrayString(values).ToString()};";

                using (NpgsqlConnection connection = new NpgsqlConnection(
                    ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connection.Open();

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

        private void positionTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string query =
               $"select " +
               $"name as Наименование," +
               $"salary as \"З/п\"," +
               $"duties as Обязанности " +
               $"from position;";

            w_selection_grid wsg = new w_selection_grid(query);

            if (wsg.ShowDialog() == true)
            {
                positionTextBox.Text = wsg.Data;
            }
        }
    }
}
