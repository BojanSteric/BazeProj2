using ISAutobuskaStanica.DataModel.DAO;
using ISAutobuskaStanica.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Services
{
    public class AutobuskiPrevoznikService : IAutobuskiPrevoznik
    {
        private static AutobuskiPrevoznikDAO dao = new AutobuskiPrevoznikDAO();
        public bool AddAutobuskiPrevoznik(AutobuskiPrevoznik autobuskiPrevoznik)
        {
            return dao.Insert(autobuskiPrevoznik);
        }

        public bool ChangeAutobuskiPrevoznik(AutobuskiPrevoznik autobuskiPrevoznik)
        {
            AutobuskiPrevoznik prevoznik = dao.FindById(autobuskiPrevoznik.IDAP);
            prevoznik.NazivPrevoznika = autobuskiPrevoznik.NazivPrevoznika;
            return dao.Update(prevoznik);
        }

        public bool DeleteAutobuskiPrevoznik(int id)
        {
            return dao.Delete(id);
        }

        public List<AutobuskiPrevoznik> GetAllAutobuskiPrevoznik()
        {
            return dao.GetAll();
        }
    }
}
