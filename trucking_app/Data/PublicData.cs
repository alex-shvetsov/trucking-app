using System.Collections.ObjectModel;

namespace trucking_app
{
    static class PublicData
    {
        public static ObservableCollection<Branch> Branches = new ObservableCollection<Branch>();
        public static ObservableCollection<Position> Positions = new ObservableCollection<Position>();
        public static ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();
        public static ObservableCollection<Route> Routes = new ObservableCollection<Route>();
        public static ObservableCollection<Equipment> Equipment = new ObservableCollection<Equipment>();
    }
}
