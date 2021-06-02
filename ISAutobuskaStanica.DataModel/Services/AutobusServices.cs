using ISAutobuskaStanica.DataModel.DAO;
using ISAutobuskaStanica.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Services
{
    public class AutobusServices : IAutobus
    {
        private static AutobusDAO dao = new AutobusDAO();

        public bool AddAutobus(Autobus autobus)
        {
            if (ValidatePrevoznikExistance(autobus.AutobuskiPrevoznikIDAP))
            {
                return dao.Insert(autobus);
            }
            else return false;
        }

        public bool ChangeAutobus(Autobus autobus)
        {
            Autobus a = dao.FindByKey(autobus.IDA, autobus.AutobuskiPrevoznikIDAP);
            a.AutobuskiPrevoznikIDAP = autobus.AutobuskiPrevoznikIDAP;
            return dao.Update(a);
        }

        public bool DeleteAutobus(int id, int ida)
        {
            return dao.Delete(id, ida);
        }

        public List<Autobus> GetAllAutobus()
        {
            return dao.GetAll();
        }

        public bool ValidatePrevoznikExistance(int id)
        {
            return dao.ValidatePrevoznikExistance(id);
        }
    }
}
