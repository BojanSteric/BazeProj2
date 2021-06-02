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
                MessageBox.Show("Proverite da li ste pravilno uneli id prevoznika", "Error");
            }
            if (Service.AddLinija(new DataModel.Linija() { NazivLinije = Naziv, AutobuskiPrevoznikIDAP = id }))
            {
                MessageBox.Show("Uspesno dodata linija", "Success");
            }
            else 
            {
                MessageBox.Show("Error with adding to database", "Error");
            }
        }

    }
}
