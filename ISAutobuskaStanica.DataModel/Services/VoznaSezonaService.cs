using ISAutobuskaStanica.DataModel.DAO;
using ISAutobuskaStanica.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Services
{
    public class VoznaSezonaService : IVoznaSezona
    {
        private static VoznaSezonaDAO dao = new VoznaSezonaDAO();
        public bool AddVoznaSezona(VoznaSezona voznaSezona)
        {
            return dao.Insert(voznaSezona);
        }

        public bool ChangeVoznaSezona(VoznaSezona voznaSezona)
        {
            VoznaSezona vs = dao.FindById(voznaSezona.IdSezone);
            vs.NazivSezone = voznaSezona.NazivSezone;
            return dao.Update(vs);
        }

        public bool DeleteVoznaSezona(int id)
        {
            return dao.Delete(id);
        }

        public List<VoznaSezona> GetAllVoznaSezona()
        {
            List<VoznaSezona> lista = dao.GetAll();
            return lista;
        }
    }
}
