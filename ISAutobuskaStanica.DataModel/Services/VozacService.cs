using ISAutobuskaStanica.DataModel.DAO;
using ISAutobuskaStanica.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Services
{
    public class VozacService : IVozac
    {
        private static VozacDAO dao = new VozacDAO();
        public bool AddVozac(Vozac vozac)
        {
            if (ValidatePrevoznikExistance(vozac.AutobuskiPrevoznikIDAP))
            {
                return dao.Insert(vozac);
            }
            else return false;
        }

        public bool ChangeVozac(Vozac vozac)
        {
            Vozac v = dao.FindByKey(vozac.IDV, vozac.AutobuskiPrevoznikIDAP);
            v.Ime = vozac.Ime;
            v.Prezime = vozac.Prezime;
            return dao.Update(v);
        }

        public bool DeleteVozac(int prevoznik, int id)
        {
            return dao.Delete(prevoznik, id);
        }

        public List<Vozac> GetAllVozac()
        {
            return dao.GetAll();
        }

        public bool ValidatePrevoznikExistance(int id)
        {
            return dao.ValidatePrevoznikExistance(id);
        }
    }
}
