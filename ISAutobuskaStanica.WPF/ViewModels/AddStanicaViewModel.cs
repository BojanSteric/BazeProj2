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
    public class AddStanicaViewModel : BindableBase
    {
        private bool change = false;
        public MyICommand AddStanica { get; set; }
        public MyICommand CloseWin { get; set; }
        public AutobuskaStanicaService Servis = new AutobuskaStanicaService();
        public AutobuskaStanica Stanica { get; set; }
        
        public Window Window { get; set; }
        public AddStanicaViewModel() 
        {
            AddStanica = new MyICommand(OnAddStanica);
            CloseWin = new MyICommand(OnClose);
        }
        public AddStanicaViewModel(AutobuskaStanica stanica) 
        {
            AddStanica = new MyICommand(OnAddStanica);
            CloseWin = new MyICommand(OnClose);
            change = true;
            Naziv = stanica.NazivAS;
            Stanica = stanica;
            
        }
        private void OnClose()
        {
            Naziv = "";
            Window.Close();
        }
        public string Naziv { get; set; }
        private void OnAddStanica()
        {
            if (change)
            {
                Stanica.NazivAS = Naziv;
                if (Servis.ChangeAutobuskaStanica(Stanica))
                {
                    MessageBox.Show("yas", "yaas");
                    Window.Close();
                }
                else
                {
                    MessageBox.Show("nah", "nah");
                }
            }
            else 
            {
                if (Servis.AddAutobuskaStanica(new AutobuskaStanica() { NazivAS = Naziv }))
                {
                    MessageBox.Show("yas", "yaas");
                    Window.Close();
                }
                else
                {
                    MessageBox.Show("nah", "nah");
                }
            }
        }

    }
}
