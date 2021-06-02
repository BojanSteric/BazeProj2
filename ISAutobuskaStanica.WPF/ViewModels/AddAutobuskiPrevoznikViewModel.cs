using ISAutobuskaStanica.DataModel;
using ISAutobuskaStanica.DataModel.Services;
using ISAutobuskaStanica.WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ISAutobuskaStanica.WPF.ViewModels
{
    public class AddAutobuskiPrevoznikViewModel : BindableBase
    {
        private bool change = false;
        public Window Window { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand Cancel { get; set; }
        public string Ime { get; set; }
        public AutobuskiPrevoznik AutobuskiPrevoznik { get; set; }

        private AutobuskiPrevoznikService Service = new AutobuskiPrevoznikService();

        public AddAutobuskiPrevoznikViewModel() {
            AddCommand = new MyICommand(OnAddCommand);
            Cancel = new MyICommand(OnCancel);
        }
        public AddAutobuskiPrevoznikViewModel(AutobuskiPrevoznik ap)
        {
            AddCommand = new MyICommand(OnAddCommand);
            Cancel = new MyICommand(OnCancel);
            Ime = ap.NazivPrevoznika;
            AutobuskiPrevoznik = ap;
            change = true;
        }

        private void OnCancel()
        {
            Ime = "";
            Window.Close();
        }

        private void OnAddCommand()
        {
            if (change)
            {
                AutobuskiPrevoznik.NazivPrevoznika = Ime;
                if (Service.ChangeAutobuskiPrevoznik(AutobuskiPrevoznik))
                {
                    MessageBox.Show("yay", "yay");
                    Window.Close();
                }
                else
                {
                    MessageBox.Show("nay", "nay");
                }
            }
            else 
            {
                if (Service.AddAutobuskiPrevoznik(new AutobuskiPrevoznik() { NazivPrevoznika = Ime }))
                {
                    MessageBox.Show("yay", "yay");
                    Window.Close();
                }
                else
                {
                    MessageBox.Show("nay", "nay");
                }
            }
        }
    }
}
