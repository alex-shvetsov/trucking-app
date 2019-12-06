using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows;

namespace trucking_app
{
    public partial class w_search_loadunloadop : Window
    {
        public DataTable Table { get; private set; }

        public w_search_loadunloadop()
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
                        "select " +
                        "code as Код, " +
                        "type as Тип, " +
                        "ST_AsText(location) as Местоположение, " +
                        "executor as Исполнитель, " +
                        "resp_person as Ответственное_лицо, " +
                        "(select concat_ws(', ', make, model) from equipment where equipment.id = mechanism) as Механизм, " +
                        "mechanism_owner as Владелец_механизма, " +
                        "method as Способ, " +
                        "exp_arr_time as Ожид._время_прибытия, " +
                        "exp_dep_time as Ожид._время_убытия, " +
                        "act_arr_time as Факт._время_прибытия, " +
                        "act_dep_time as Факт._время_убытия, " +
                        "extra_time as Время_доп._операций " +
                        "from load_unload " +
                        $"where type like '%{typeComboBox.Text}%' and " +
                        $"method like '%{methodTextBox.Text}%' and " +
                        $"executor like '%{executorTextBox.Text}%' and " +
                        $"resp_person like '%{respPersonTextBox.Text}%' and " +
                        $"mechanism_owner like '%{mechOwnerTextBox.Text}%' and " +
                        $"code like '%{codeTextBox.Text}%';";

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
