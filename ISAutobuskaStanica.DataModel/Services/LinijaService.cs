using ISAutobuskaStanica.DataModel.DAO;
using ISAutobuskaStanica.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Services
{
    public class LinijaService : ILinija
    {
        private static LinijaDAO dao = new LinijaDAO();

        public bool AddLinija(Linija linija)
        {
            if (ValidatePrevoznikExistance(linija.AutobuskiPrevoznikIDAP))
            {
                return dao.Insert(linija);
            }
            else return false;
        }

        public bool ChangeLinija(Linija linija)
        {
            Linija l = dao.FindByKey(linija.NazivLinije, linija.AutobuskiPrevoznikIDAP);
            l.NazivLinije = linija.NazivLinije;
            return dao.Update(l);
        }

        public bool DeleteLinija(int id, string naziv)
        {
            return dao.Delete(id, naziv);
        }

        public List<Linija> GetAllLinija()
        {
            return dao.GetAll();
        }

        public bool ValidatePrevoznikExistance(int id)
        {
            return dao.ValidatePrevoznikExistance(id);
        }
    }
}
