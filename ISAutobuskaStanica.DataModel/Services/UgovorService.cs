using ISAutobuskaStanica.DataModel.DAO;
using ISAutobuskaStanica.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Services
{
    public class UgovorService : IUgovor
    {
        private static UgovorDAO dao = new UgovorDAO();
        public bool AddUgovor(Ugovor ugovor)
        {
            if (dao.ValidateStanicaExistance(ugovor.AutobuskaStanicaIDAS) && dao.ValidatePrevoznikExistance(ugovor.AutobuskiPrevoznikIDAP))
            {
                return dao.Insert(ugovor);
            }
            else return false;
        }

        public bool ChangeUgovor(Ugovor ugovor)
        {
            Ugovor u = dao.FindByKey(ugovor.AutobuskiPrevoznikIDAP, ugovor.AutobuskaStanicaIDAS);
            u.DatumSklapanja = ugovor.DatumSklapanja;
            return dao.Update(u);
        }

        public bool DeleteUgovor(int stanica, int prevoznik)
        {
            return dao.Delete(stanica, prevoznik);
        }

        public List<Ugovor> GetAllUgovor()
        {
            return dao.GetAll();
        }

        public bool ValidatePrevoznikExistance(int id)
        {
            return dao.ValidatePrevoznikExistance(id);
        }

        public bool ValidateStanicaExistance(int id)
        {
            return dao.ValidateStanicaExistance(id);
        }
    }
}
