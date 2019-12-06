using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;

namespace trucking_app
{
    public partial class z_info_cargo_content : Window
    {
        private string content;

        public z_info_cargo_content(string content)
        {
            InitializeComponent();
            this.content = content;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<CargoUnit> values = JsonConvert.DeserializeObject<List<CargoUnit>>(content);
            mainLB.ItemsSource = values;
        }
    }
}
