using Npgsql;
using System;
using System.Configuration;
using System.Windows;

namespace trucking_app
{
    public partial class w_add_position : Window
    {
        public w_add_position()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(nameTextBox.Text) ||
                    string.IsNullOrEmpty(salaryTextBox.Text))
                {
                    throw new Exception("Все поля должны быть заполнены.");
                }

                Position position = new Position();

                if (decimal.TryParse(salaryTextBox.Text, out decimal dsal))
                {
                    position.Salary = dsal;
                }
                else
                {
                    throw new Exception("Невозможно преобразовать з/п в число.");
                }

                position.Name = nameTextBox.Text;
                position.Duties = dutiesTextBox.Text;

                using (NpgsqlConnection connection = new NpgsqlConnection(
                    ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connection.Open();

                    string query =
                        $"insert into position (id, name, salary, duties) " +
                        $"values ('{position.ID.ToString()}', '{position.Name}', '{position.Salary}', '{position.Duties}');";

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
