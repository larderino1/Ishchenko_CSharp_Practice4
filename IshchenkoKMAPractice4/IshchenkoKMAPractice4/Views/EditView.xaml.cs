using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IshchenkoKMAPractice4.Tools.Navigation;
using IshchenkoKMAPractice4.ViewModels;

namespace IshchenkoKMAPractice4.Views
{
    /// <summary>
    /// Логика взаимодействия для RemoveView.xaml
    /// </summary>
    public partial class EditView : UserControl, INavigatable
    {
        public EditView()
        {
            DataContext = new EditViewModel();
            InitializeComponent();
        }
    }
}
