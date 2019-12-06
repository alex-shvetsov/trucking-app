using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows;

namespace trucking_app
{
    public partial class w_search_branch : Window
    {
        public DataTable Table { get; private set; }

        public w_search_branch()
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
                        $"name as Наименование," +
                        $"address as Адрес," +
                        $"phone as Телефон," +
                        $"ST_AsText(location) as Местоположение " +
                        $"from branch where name like '%{branchNameTextBox.Text}%';";

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void okButton_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
