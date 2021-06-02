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
                Error = e.Message;
            }

            if (id <= 0) {
                Error = "Id prevoznika ne sme biti manji od 0!";
                return;
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
                    Error = "Greska: Entitet postoji ili je nepravilno unet";
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
                    Error = "Greska: Entitet postoji ili je nepravilno unet";
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
                    Error = "Greska: Entitet postoji ili je nepravilno unet";
                }
            }
            else 
            {
                Error = "Greska: Entitet postoji ili je nepravilno unet";
            }
        }

        private void OnCancel()
        {
            Window.Close();
        }
    }
}
