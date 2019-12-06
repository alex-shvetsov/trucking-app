using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace trucking_app
{
    public partial class w_cargo_content : Window
    {
        private ObservableCollection<Good> Goods;

        public w_cargo_content()
        {
            InitializeComponent();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mainLB.Items.Count != 0 && mainLB.SelectedIndex != -1)
                {
                    Goods.RemoveAt(mainLB.SelectedIndex);
                }
                else
                {
                    throw new Exception("Выберите хотя бы один товар для удаления.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(nameTextBox.Text) ||
                    string.IsNullOrEmpty(quanTextBox.Text) ||
                    string.IsNullOrEmpty(umassTextBox.Text) ||
                    string.IsNullOrEmpty(wrapperTextBox.Text) ||
                    string.IsNullOrEmpty(wrapMassTextBox.Text))
                {
                    throw new Exception("Все поля должны быть заполнены.");
                }

                Good good = new Good();

                if (int.TryParse(quanTextBox.Text, out int q) && q > 0)
                {
                    good.Quantity = q;
                }
                else
                {
                    throw new Exception("Невозможно преобразовать количество в число или это число меньше 1.");
                }

                if (double.TryParse(umassTextBox.Text, out double um) && um > 0)
                {
                    good.UnitWeight = um;
                }
                else
                {
                    throw new Exception("Невозможно преобразовать массу единицы в число или это число меньше 1.");
                }

                if (double.TryParse(wrapMassTextBox.Text, out double wm) && wm > 0)
                {
                    good.WrapperWeight = wm;
                }
                else
                {
                    throw new Exception("Невозможно преобразовать массу упаковки в число или это число меньше 1.");
                }

                good.Name = nameTextBox.Text;
                good.Wrapper = wrapperTextBox.Text;

                Goods.Add(good);

                Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Goods == null)
            {
                Goods = new ObservableCollection<Good>();
                mainLB.ItemsSource = Goods;
            }
        }

        private void Clear()
        {
            foreach (UIElement e in grid.Children)
            {
                if (e is TextBox)
                {
                    ((TextBox)e).Clear();
                }
            }
        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(Goods);
        }
    }
}
