using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace trucking_app
{
    public partial class w_search_techservice : Window
    {
        public DataTable Table { get; private set; }

        public w_search_techservice()
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
                        "concat_ws(', ', equipment.make, equipment.model) as Название_техники, " +
                        "(select concat_ws(', ', name, passport) from employee where id = tech_service.mech1) as Механик1, " +
                        "(select concat_ws(', ', name, passport) from employee where id = tech_service.mech2) as Механик2, " +
                        "(select concat_ws(', ', name, passport) from employee where id = tech_service.mech3) as Механик3, " +
                        "(select concat_ws(', ', name, passport) from employee where id = tech_service.mech4) as Механик4, " +
                        "start_dt as Дата_начала_проверки, " +
                        "finish_dt as Дата_окончания_проверки," +
                        "report as Отчет " +
                        "from tech_service join equipment on equipment_unit = equipment.id " +
                        $"where code like '%{codeTextBox.Text}%' and " +
                        $"equipment.number like '%{equipUnitTextBox.Text}%';";

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
    }
}
