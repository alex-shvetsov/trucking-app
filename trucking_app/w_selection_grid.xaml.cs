using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace trucking_app
{
    public partial class w_selection_grid : Window
    {
        private string selectQuery;

        public string Data { get; private set; }

        public w_selection_grid(string selectQuery)
        {
            InitializeComponent();

            this.selectQuery = selectQuery;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(
                    ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
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

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;

            if (row != null)
            {
                TextBlock tbl = dg.Columns[0].GetCellContent(row) as TextBlock;
                Data = tbl.Text;

                DialogResult = true;
                Close();
            }
        }
    }
}
