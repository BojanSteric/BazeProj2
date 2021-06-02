using ISAutobuskaStanica.DataModel;
using ISAutobuskaStanica.WPF.ViewModels;
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
using System.Windows.Shapes;

namespace ISAutobuskaStanica.WPF.Views
{
    /// <summary>
    /// Interaction logic for AddVozacWindow.xaml
    /// </summary>
    public partial class AddVozacWindow : Window
    {
        public AddVozacWindow(Vozac v = null)
        {
            InitializeComponent();
            if (v == null)
            {
                DataContext = new AddVozacViewModel() { Window = this };
            }
            else 
            {
                DataContext = new AddVozacViewModel(v) { Window = this };
            }
        }
    }
}
