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
    /// Interaction logic for AddAutobuskiPrevoznikWindow.xaml
    /// </summary>
    public partial class AddAutobuskiPrevoznikWindow : Window
    {
        public AddAutobuskiPrevoznikWindow(AutobuskiPrevoznik ap = null)
        {
            InitializeComponent();
            if (ap != null)
            {
                DataContext = new AddAutobuskiPrevoznikViewModel(ap) { Window = this };
            }
            else 
            {
                DataContext = new AddAutobuskiPrevoznikViewModel() { Window = this };
            }
        }
    }
}
