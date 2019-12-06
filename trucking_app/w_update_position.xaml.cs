using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;

namespace trucking_app
{
    public partial class w_update_position : Window
    {
        private List<string> values;

        public w_update_position(List<string> values)
        {
            InitializeComponent();
            this.values = values;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal sal;

                if (!decimal.TryParse(salaryTextBox.Text, out sal))
                {
                    throw new Exception("Невозможно преобразовать зарплату в число.");
                }

                List<string> array = new List<string>();

                if (nameCB.IsChecked.Value)
                {
                    array.Add($"name = {nameTextBox.Text}");
                }

                if (salaryCB.IsChecked.Value)
                {
                    array.Add($"salary = {salaryTextBox.Text}");
                }

                if (dutiesCB.IsChecked.Value)
                {
                    array.Add($"duties = {dutiesTextBox.Text}");
                }

                string set = string.Join(", ", array.ToArray());

                
                string query = $"update position set {set} where name = {new ArrayString(values).ToString()};";

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
    }
}
