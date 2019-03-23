using System.Windows.Controls;
using IshchenkoKMAPractice4.Tools.Navigation;
using IshchenkoKMAPractice4.ViewModels;

namespace IshchenkoKMAPractice4.Views
{
    /// <summary>
    /// Логика взаимодействия для InputView.xaml
    /// </summary>
    public partial class InputView : UserControl, INavigatable
    {
        public InputView()
        {
            InitializeComponent();
            DataContext = new InputViewModel();
        }
    }
}
