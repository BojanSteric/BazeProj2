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

        private void OnAdd()
        {
            int id = 0;
            try
            {
                id = int.Parse(IdPrevoznika);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ne postoji ili niste ispravno uneli id prevoznika", "error");
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
                    MessageBox.Show("Error with database", "Error");
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
                    MessageBox.Show("Error with database", "Error");
                }
            }

        }
    }
}
