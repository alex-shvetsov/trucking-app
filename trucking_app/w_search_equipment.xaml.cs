using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace trucking_app
{
    public partial class w_search_equipment : Window
    {
        public DataTable Table { get; private set; }

        public w_search_equipment()
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
                        $"number as Номер," +
                        $"make as Марка, " +
                        $"model as Модель, " +
                        $"type as Тип, " +
                        $"trailer_type as \"Тип прицепа\", " +
                        $"dims as Габариты, " +
                        $"weight_capacity as Грузоподъемность, " +
                        $"volume_capacity as Вместимость, " +
                        $"engine_type as \"Тип двигателя\", " +
                        $"mass as Масса, " +
                        $"price as Стоимость " +
                        $"from equipment where make like '%{makeTextBox.Text}%' and " +
                        $"model like '%{modeltextBox.Text}%' and " +
                        $"type like '%{typeComboBox.Text}%' and " +
                        $"trailer_type like '%{trailerTypeTextBox.Text}%' and " +
                        $"number like '%{numberTextBox.Text}%' and " +
                        $"engine_type like '%{engineTypeTextBox.Text}%';";

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
    }
}
