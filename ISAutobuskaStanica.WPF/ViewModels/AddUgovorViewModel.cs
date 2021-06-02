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
    public class AddUgovorViewModel : BindableBase
    {
        public Window Window { get; set; }
        private UgovorService Service = new UgovorService();
        public MyICommand AddUgovor { get; set; }
        public MyICommand Cancel { get; set; }
        public string IDStanice { get; set; }
        public string IDPrevoznika { get; set; }
        public AddUgovorViewModel() 
        {
            AddUgovor = new MyICommand(OnAddCommand);
            Cancel = new MyICommand(OnCancelCommand);
        }

        private void OnCancelCommand()
        {
            IDStanice = "";
            IDPrevoznika = "";
            Window.Close();
        }

        private void OnAddCommand()
        {
            int stanica=0, prevoznik=0;
            try
            {

                stanica = int.Parse(IDStanice);
                prevoznik = int.Parse(IDPrevoznika);
            }
            catch (Exception e) 
            {
                MessageBox.Show("listen here u little ... this should be number", "WTF U DOIN?");
            }

            if (Service.AddUgovor(new DataModel.Ugovor() { DatumSklapanja = DateTime.Now.ToString("yyyy-MM-dd"), AutobuskaStanicaIDAS = stanica, AutobuskiPrevoznikIDAP = prevoznik }))
            {
                MessageBox.Show("Added", "Success");
            }
            else 
            {
                MessageBox.Show("Error", "Catastrophic failure");
            }

        }
    }
}
