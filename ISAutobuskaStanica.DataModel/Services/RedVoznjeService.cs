using ISAutobuskaStanica.DataModel.DAO;
using ISAutobuskaStanica.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Services
{
    public class RedVoznjeService : IRedVoznje
    {
        private static RedVoznjeDAO dao = new RedVoznjeDAO();
        private static AutobuskaStanicaDAO daoAS = new AutobuskaStanicaDAO();
        private static VoznaSezonaDAO daoVS= new VoznaSezonaDAO();

        public bool AddRedVoznje(RedVoznje redVoznje)
        {
            if (ValidateStanicaExistance(redVoznje.AutobuskaStanicaIDAS) && ValidateSezonaExistance(redVoznje.VoznaSezonaIdSezone))
            {
                return dao.Insert(redVoznje);
            }
            else return false;
        }

        public bool ChangeRedVoznje(RedVoznje redVoznje)
        {
            RedVoznje rv = dao.FindByKey(redVoznje.AutobuskaStanicaIDAS, redVoznje.VoznaSezonaIdSezone);
            rv.DatumReda = redVoznje.DatumReda;
            return dao.Update(rv);
        }

        public bool DeleteRedVoznje(int stanica, int sezona)
        {
            return dao.DeleteRED(stanica, sezona);
        }

        public List<RedVoznje> GetAllRedVoznje()
        {
            return dao.GetAll();
        }

        public bool ValidateSezonaExistance(int id)
        {
            return dao.ValidateVoznaSezonaExistance(id);
        }

        public bool ValidateStanicaExistance(int id)
        {
            return dao.ValidateAutobuskaStanicaExistance(id);
        }
    }
}
