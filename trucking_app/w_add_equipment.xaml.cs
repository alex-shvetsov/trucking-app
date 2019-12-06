using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    public partial class w_add_equipment : Window
    {
        public w_add_equipment()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(makeTextBox.Text) ||
                    string.IsNullOrEmpty(modeltextBox.Text) ||
                    string.IsNullOrEmpty(numberTextBox.Text) ||
                    string.IsNullOrEmpty(dimTextBox.Text) ||
                    string.IsNullOrEmpty(wcapTextBox.Text) ||
                    string.IsNullOrEmpty(vcapTextBox.Text) ||
                    string.IsNullOrEmpty(massTextBox.Text) ||
                    string.IsNullOrEmpty(priceTextBox.Text))
                {
                    throw new Exception("Поля не должны оставаться пустыми.");
                }

                Equipment equipment = new Equipment();

                if (double.TryParse(wcapTextBox.Text, out double wcap) && wcap > 0)
                {
                    equipment.WeightCapacity = wcap;
                }
                else
                {
                    throw new Exception("Невозможно преобразовать грузоподъемность в число или грузоподъемность меньше 0.");
                }

                if (double.TryParse(vcapTextBox.Text, out double vcap) && vcap > 0)
                {
                    equipment.VolumeCapacity= vcap;
                }
                else
                {
                    throw new Exception("Невозможно преобразовать вместимость в число или вместимость меньше 0.");
                }

                if (double.TryParse(massTextBox.Text, out double mass) && mass > 0)
                {
                    equipment.Mass = mass;
                }
                else
                {
                    throw new Exception("Невозможно преобразовать массу в число или масса меньше 0.");
                }

                if (decimal.TryParse(priceTextBox.Text, out decimal price) && price > 0)
                {
                    equipment.Price = price;
                }
                else
                {
                    throw new Exception("Невозможно преобразовать стоимость в число или стоимость меньше 0.");
                }

                equipment.Make = makeTextBox.Text;
                equipment.Model = modeltextBox.Text;
                equipment.Type = typeComboBox.SelectedValue.ToString().Split(' ')[1];
                equipment.TrailerType = (string.IsNullOrEmpty(trailerTypeTextBox.Text)) ? null : trailerTypeTextBox.Text;
                equipment.Number = numberTextBox.Text;
                equipment.Dim = dimTextBox.Text;
                equipment.EngineType = (string.IsNullOrEmpty(engineTypeTextBox.Text)) ? null : engineTypeTextBox.Text;

                using (NpgsqlConnection connection = new NpgsqlConnection(
                    ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connection.Open();

                    string query =
                        $"insert into equipment (id, make, model, type, trailer_type, number, dims, weight_capacity, " +
                        $"volume_capacity, engine_type, mass, price) " +
                        $"values ('{equipment.ID.ToString()}', '{equipment.Make}', '{equipment.Model}', '{equipment.Type}', " +
                        $"'{equipment.TrailerType}', '{equipment.Number}', '{equipment.Dim}', '{equipment.WeightCapacity}', " +
                        $"'{equipment.VolumeCapacity}', '{equipment.EngineType}', '{equipment.Mass}', '{equipment.Price}');";

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
