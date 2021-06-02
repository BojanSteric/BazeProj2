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

        private void OnAdd()
        {
            int sezona=0, stanica=0;
            try
            {
                sezona = int.Parse(IdSezone);
                stanica = int.Parse(IdStanice);
            } catch (Exception e)
            {
                MessageBox.Show("Error:" + e.Message, "Error");
            }
            if (Service.AddRedVoznje(new DataModel.RedVoznje() { AutobuskaStanicaIDAS = stanica, VoznaSezonaIdSezone = sezona, DatumReda = DateTime.Now.ToString("yyyy-MM-dd") }))
            {
                MessageBox.Show("Great success", "Success");
            }
            else 
            {
                MessageBox.Show("Error with adding to database", "Error");
            }
        }

        private void OnCancel()
        {
            Window.Close();
        }
    }
}
