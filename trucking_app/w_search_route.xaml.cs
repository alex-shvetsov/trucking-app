using System;
using System.Windows;
using System.Windows.Input;

namespace trucking_app
{
    public partial class w_search_route : Window
    {
        public string Data { get; private set; }

        public w_search_route()
        {
            InitializeComponent();
        }

        private void shippingTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string query =
              "select " +
              "cargo_id as Код_груза, " +
              "cargo_content as Содержимое_груза, " +
              "cargo_class as Класс_груза, " +
              "(select concat_ws(', ', make, model) from equipment where equipment.id = shipping.auto) as Кузов_авто, " +
              "(select concat_ws(', ', make, model) from equipment where equipment.id = shipping.trailer) as Прицеп, " +
              "container as Контейнер," +
              "container_mass as Масса_контейнера, " +
              "gross_weight as Масса_брутто, " +
              "sender as Отправитель, " +
              "receiver as Получатель, " +
              "(select concat_ws(', ', employee.name, employee.passport) from employee where employee.id = shipping.driver) as Водитель, " +
              "(select code from load_unload where load_unload.id = shipping.load_op) as Код_погрузки, " +
              "(select code from load_unload where load_unload.id = shipping.unload_op) as Код_разгрузки, " +
              "urgent as Срочно, " +
              "price as Стоимость, " +
              "penalty as Неустойка, " +
              "total as Итого, " +
              "ST_AsText(curr_location) as Местоположение_груза, " +
              "delivered as Доставлен " +
              "from shipping;";

            w_selection_grid wsg = new w_selection_grid(query);

            if (wsg.ShowDialog() == true)
            {
                shippingTextBox.Text = wsg.Data;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(shippingTextBox.Text))
                {
                    throw new Exception("Поле должно быть запоолнено.");
                }

                Data = shippingTextBox.Text;

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
