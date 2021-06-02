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
    public class AddRedVoznjeViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddRedVoznje { get; set; }
        public MyICommand Cancel { get; set; }
        private RedVoznjeService Service = new RedVoznjeService();
        public string IdStanice { get; set; }
        public string IdSezone { get; set; }
        public AddRedVoznjeViewModel()
        {
            AddRedVoznje = new MyICommand(OnAdd);
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
        private void OnAdd()
        {
            int sezona = 0, stanica = 0;
            try
            {
                sezona = int.Parse(IdSezone);
                stanica = int.Parse(IdStanice);
            } catch (Exception e)
            {
                Error = e.Message;
            }
            if (sezona <= 0 || stanica <= 0) 
            {
                Error = "Greska id ne sme biti manji od 0";
            }
            if (Service.AddRedVoznje(new DataModel.RedVoznje() { AutobuskaStanicaIDAS = stanica, VoznaSezonaIdSezone = sezona, DatumReda = DateTime.Now.ToString("yyyy-MM-dd") }))
            {
                MessageBox.Show("Great success", "Success");
            }
            else 
            {
                Error = "Greska: entitet postoji ili ne postoje potrebni entiteti";
            }
        }

        private void OnCancel()
        {
            Window.Close();
        }
    }
}
