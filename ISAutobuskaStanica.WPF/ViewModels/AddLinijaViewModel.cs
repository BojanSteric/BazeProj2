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
    public class AddLinijaViewModel:BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddLinija { get; set; }
        public MyICommand Cancel { get; set; }

        private LinijaService Service = new LinijaService();
        public string Naziv { get; set; }
        public string IdPrevoznika { get; set; }
        public AddLinijaViewModel() 
        {
            AddLinija = new MyICommand(OnAdd);
            Cancel = new MyICommand(OnCancel);
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
        private void OnCancel()
        {
            Window.Close();
        }

        private void OnAdd()
        {
            int id = 0;
            try
            {
                id = int.Parse(IdPrevoznika);
            } catch (Exception e)
            {
                Error = e.Message;
            }
            if (id <= 0 )
            {
                Error = "Id ne sme biti manji od 0!";
                return;
            }
            if (Naziv.Trim().Equals("")) 
            {
                Error = "Ime ne sme biti prazno!";
                return;
            }
            if (Service.AddLinija(new DataModel.Linija() { NazivLinije = Naziv, AutobuskiPrevoznikIDAP = id }))
            {
                MessageBox.Show("Uspesno dodata linija", "Success");
                Window.Close();
            }
            else 
            {
                Error = "Greska: Linija postoji ili je nepravilno kreirana";
            }
        }

    }
}
