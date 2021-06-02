using ISAutobuskaStanica.DataModel.DAO;
using ISAutobuskaStanica.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Services
{
    public class AutobuskaStanicaService : IAutobuskaStanica
    {
        private static AutobuskaStanicaDAO dao = new AutobuskaStanicaDAO();
        public bool AddAutobuskaStanica(AutobuskaStanica autobuskaStanica)
        {
            return dao.Insert(autobuskaStanica);
        }

        public bool ChangeAutobuskaStanica(AutobuskaStanica autobuskaStanica)
        {
            AutobuskaStanica stanica = dao.FindById(autobuskaStanica.IDAS);
            stanica.NazivAS = autobuskaStanica.NazivAS;
            return dao.Update(stanica);
        }

        public bool DeleteAutobuskaStanica(int idStanice)
        {
            return dao.Delete(idStanice);
        }

        public List<AutobuskaStanica> GetAllAutobuskaStanica()
        {
            List<AutobuskaStanica> lista = dao.GetAll();
            return lista;
        }

    }
}
