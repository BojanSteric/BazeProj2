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
    public class AddSezonaViewModel : BindableBase
    {
        private bool change = false;
        public string Content { get; set; }
        public MyICommand AddSezona { get; set; }
        public MyICommand CloseWin { get; set; }
        
        public VoznaSezonaService Servis = new VoznaSezonaService();
        public VoznaSezona Sezona { get; set; }

        public Window Window { get; set; }
        public AddSezonaViewModel()
        {
            AddSezona = new MyICommand(OnAddSezona);
            CloseWin = new MyICommand(OnClose);
            Content = "Add";
            Naziv = "";
        }
        public AddSezonaViewModel(VoznaSezona vs)
        {
            AddSezona = new MyICommand(OnAddSezona);
            CloseWin = new MyICommand(OnClose);
            Naziv = vs.NazivSezone;
            change = true;
            Sezona = vs;
            Content = "Update";
        }

        private void OnClose()
        {
            Naziv = "";
            Window.Close();
        }
        private string error;
        public string Error
        {
            get
            {
                return error;
            }
            set
            {
                error = value;
                OnPropertyChanged("Error");
            }
        }
        public string Naziv { get; set; }
        private void OnAddSezona()
        {
            if (Naziv.Trim().Equals("")) 
            {
                Error = "Ne sme naziv prazan da bude";
                return;
            }
            if (change)
            {
                Sezona.NazivSezone = Naziv;
                if (Servis.ChangeVoznaSezona(Sezona))
                {
                    MessageBox.Show("yas", "yaas");
                    Window.Close();
                }
                else
                {
                    Error = "Greska pri upisu u bazu";
                }
            }
            else 
            {
                if (Servis.AddVoznaSezona(new VoznaSezona() { NazivSezone = Naziv }))
                {
                    MessageBox.Show("yas", "yaas");
                    Window.Close();
                }
                else
                {
                    Error = "Greska pri upisu u bazu";
                }
            }

        }
    }
}
