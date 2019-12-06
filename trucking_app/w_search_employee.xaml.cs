using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows;

namespace trucking_app
{
    public partial class w_search_employee : Window
    {
        public DataTable Table { get; private set; }

        public w_search_employee()
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
                        $"where employee.name like '%{nameTextBox.Text}%' and " +
                        $"sex = {sexComboBox.SelectedValue.ToString().Contains("Мужской")} and " +
                        $"passport like '%{passportTextBox.Text}%' and " +
                        $"position.name like '%{positionTextBox.Text}%' and " +
                        $"branch.name like '%{branchTextBox.Text}%';";

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

        private void positionTextBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
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

        private void branchTextBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
    }
}
