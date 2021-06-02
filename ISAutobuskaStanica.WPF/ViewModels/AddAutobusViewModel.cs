using ISAutobuskaStanica.DataModel.DAO;
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
    public class AddAutobusViewModel : BindableBase
    {
        public Window Window { get; set; }

        public MyICommand AddAutobus { get; set; }
        public MyICommand Cancel { get; set; }
        public bool Zglobni { get; set; }
        public bool Elektricni { get; set; }
        public bool Drugo { get; set; }
        public string IdPrevoznika { get; set; }

        private AutobusServices Service = new AutobusServices();
        public AddAutobusViewModel()
        {
            AddAutobus = new MyICommand(OnAdd);
            Cancel = new MyICommand(OnCancel);
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
                MessageBox.Show("error: " + e.Message, "Error");
            }
            if (Elektricni)
            {
                ElektricniDAO dao = new ElektricniDAO();
                if (dao.Insert(new DataModel.Elektricni() { AutobuskiPrevoznikIDAP = id }))
                {
                    MessageBox.Show("Success zglobni added");
                    Window.Close();
                }
                else
                {
                    MessageBox.Show("error with database ", "Error");
                }
            }
            else if (Zglobni)
            {
                ZglobniDAO dao = new ZglobniDAO();
                if (dao.Insert(new DataModel.Zglobni() { AutobuskiPrevoznikIDAP = id }))
                {
                    MessageBox.Show("Success zglobni added");
                    Window.Close();
                }
                else 
                {
                    MessageBox.Show("error with database ", "Error");
                }
            }
            else if (Drugo)
            {
                if(Service.AddAutobus(new DataModel.Autobus() { AutobuskiPrevoznikIDAP = id }))
                {
                    MessageBox.Show("Success zglobni added");
                    Window.Close();
                }
                else
                {
                    MessageBox.Show("error with database ", "Error");
                }
            }
            else 
            {
                MessageBox.Show("error with database ", "Error");
            }
        }

        private void OnCancel()
        {
            Window.Close();
        }
    }
}
