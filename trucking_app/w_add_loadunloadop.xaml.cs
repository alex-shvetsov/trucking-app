using Npgsql;
using System;
using System.Configuration;
using System.Windows;
using System.Windows.Input;

namespace trucking_app
{
    public partial class w_add_loadunloadop : Window
    {
        public w_add_loadunloadop()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(longitudeTextBox.Text) ||
                    string.IsNullOrEmpty(latitudeTextBox.Text) ||
                    string.IsNullOrEmpty(executorTextBox.Text) ||
                    string.IsNullOrEmpty(respPersonTextBox.Text) ||
                    string.IsNullOrEmpty(codeTextBox.Text) ||
                    string.IsNullOrEmpty(methodTextBox.Text) ||
                    string.IsNullOrEmpty(expArrTimeTextBox.Text) ||
                    string.IsNullOrEmpty(expDepTimeTextBox.Text) ||
                    string.IsNullOrEmpty(extraOpTimeTextBox.Text))
                {
                    throw new Exception("Поля не должны оставаться пустыми.");
                }

                LoadUnload lu = new LoadUnload();

                if (latitudeTextBox.Text.Contains(".")) latitudeTextBox.Text = latitudeTextBox.Text.Replace(".", ",");
                if (longitudeTextBox.Text.Contains(".")) longitudeTextBox.Text = longitudeTextBox.Text.Replace(".", ",");

                double lat, lon;
                int time;

                if (!double.TryParse(latitudeTextBox.Text, out lat))
                {
                    throw new Exception("Невозможно преобразовать широту в число.");
                }

                if (!double.TryParse(longitudeTextBox.Text, out lon))
                {
                    throw new Exception("Невозможно преобразовать долготу в число.");
                }

                if (DateTime.TryParse(expArrTimeTextBox.Text, out DateTime eat))
                {
                    lu.ExpArrTime = eat;
                }
                else
                {
                    throw new Exception("Ошибка преобразования даты (ожид, приб).");
                }

                if (DateTime.TryParse(expDepTimeTextBox.Text, out DateTime edt))
                {
                    lu.ExpDepTime = edt;
                }
                else
                {
                    throw new Exception("Ошибка преобразования даты (ожид, убыт).");
                }

                if (DateTime.TryParse(actArrTimeTextBox.Text, out DateTime aat))
                {
                    lu.ActArrTime = aat;
                }
                else
                {
                    throw new Exception("Ошибка преобразования даты (факт, приб).");
                }

                if (DateTime.TryParse(actDepTimeTextBox.Text, out DateTime adt))
                {
                    lu.ActDepTime = adt;
                }
                else
                {
                    throw new Exception("Ошибка преобразования даты (факт, убыт).");
                }

                if (!int.TryParse(extraOpTimeTextBox.Text, out time) && time >= 0)
                {
                    throw new Exception("Невозможно преобразовать минуты на доп. операции в число или это число меньше 0.");
                }

                lu.ExtraTime = time;
                lu.Code = codeTextBox.Text;
                lu.Type = typeComboBox.SelectedValue.ToString().Split(' ')[1];
                lu.Latitude = lat;
                lu.Longitude = lon;
                lu.Executor = executorTextBox.Text;
                lu.RespPerson = respPersonTextBox.Text;
                lu.Mechanism = mechanismTextBox.Text;
                lu.MechanismOwner = mechOwnerTextBox.Text;
                lu.Method = methodTextBox.Text;

                using (NpgsqlConnection connection = new NpgsqlConnection(
                    ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connection.Open();

                    string query =
                        $"insert into load_unload (id, type, location, executor, resp_person, mechanism, mechanism_owner," +
                        $"method, exp_arr_time, exp_dep_time, act_arr_time, act_dep_time, extra_time, code) " +
                        $"values ('{lu.ID.ToString()}', '{lu.Type}', " +
                        $"ST_SetSRID(ST_MakePoint({lu.Longitude.ToString().Replace(",", ".")}, {lu.Latitude.ToString().Replace(",", ".")}), 4326), " +
                        $"'{lu.Executor}', '{lu.RespPerson}', " +
                        $"(select id from equipment where number = '{lu.Mechanism}'), " +
                        $"'{lu.MechanismOwner}', '{lu.Method}', '{lu.ExpArrTime.ToString()}', '{lu.ExpDepTime.ToString()}', " +
                        $"'{lu.ActArrTime.ToString()}', '{lu.ActDepTime.ToString()}', '{lu.ExtraTime}', '{lu.Code}');";

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

        private void mechanismTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
                $"from equipment " +
                $"where type = 'Механизм';";

            w_selection_grid wsg = new w_selection_grid(query);

            if (wsg.ShowDialog() == true)
            {
                mechanismTextBox.Text = wsg.Data;
            }
        }
    }
}
