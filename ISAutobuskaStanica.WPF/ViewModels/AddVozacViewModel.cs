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
    public class AddVozacViewModel : BindableBase
    {
        private bool change = false;
        public Vozac Vozac { get; set; }
        public Window Window { get; set; }
        public MyICommand AddVozac { get; set; }
        public MyICommand Cancel { get; set; }
        public string ImeV { get; set; }
        public string PrezimeV { get; set; }
        public string IdPrevoznika { get; set; }

        private VozacService Service = new VozacService();
        public AddVozacViewModel()
        {
            AddVozac = new MyICommand(OnAdd);
            Cancel = new MyICommand(OnCancel);
            ImeV = "";
            PrezimeV = "";
            IdPrevoznika = "";
        }

        public AddVozacViewModel(Vozac v)
        {
            AddVozac = new MyICommand(OnAdd);
            Cancel = new MyICommand(OnCancel);
            Vozac = v;
            ImeV = v.Ime;
            PrezimeV = v.Prezime;
            IdPrevoznika = v.AutobuskiPrevoznikIDAP.ToString();
            change = true;
        }
        private void OnCancel()
        {
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
        private void OnAdd()
        {
            int id = 0;
            try
            {
                id = int.Parse(IdPrevoznika);
            }
            catch (Exception e)
            {
                Error = "greska pri unosu";
            }
            if (id <= 0) {
                Error = "greska pri Proveri id";
            }
            if (ImeV.Trim().Equals("") || PrezimeV.Trim().Equals(""))
            {
                Error = "greska pri Proveri ime i prezime";
            }
            if (change)
            {
                Vozac.Ime = ImeV;
                Vozac.Prezime = PrezimeV;
                if (Service.ChangeVozac(Vozac))
                {
                    MessageBox.Show("Successfully updated", "Nice");
                }
                else
                {
                    Error = "greska pri unosu u bazu";
                }
            }
            else 
            {
                if (Service.AddVozac(new DataModel.Vozac() { Ime = ImeV, Prezime = PrezimeV, AutobuskiPrevoznikIDAP = id }))
                {
                    MessageBox.Show("Successfully added", "Nice");
                }
                else
                {
                    Error = "greska pri unosu u bazu";
                }
            }

        }
    }
}
