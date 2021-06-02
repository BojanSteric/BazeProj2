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
    /// Interaction logic for AddAStanicaWindow.xaml
    /// </summary>
    public partial class AddAStanicaWindow : Window
    {
        public AddAStanicaWindow(AutobuskaStanica stanica = null)
        {
            InitializeComponent();
            if (stanica != null)
            {
                DataContext = new AddStanicaViewModel(stanica) { Window = this };
            }
            else
            {
                DataContext = new AddStanicaViewModel() { Window = this };
            }
        }
    }
}
