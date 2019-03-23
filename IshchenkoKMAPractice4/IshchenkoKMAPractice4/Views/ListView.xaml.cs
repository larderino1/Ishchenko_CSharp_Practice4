using System.Windows.Controls;
using IshchenkoKMAPractice4.Tools.Navigation;
using IshchenkoKMAPractice4.ViewModels;

namespace IshchenkoKMAPractice4.Views
{
    /// <summary>
    /// Логика взаимодействия для ListView.xaml
    /// </summary>
    public partial class ListView : UserControl, INavigatable
    {
        public ListView()
        {
            InitializeComponent();
            DataContext = new ListViewModel();
            this.Grid.IsReadOnly = true;
        }
    }
}
