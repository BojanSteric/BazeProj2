using ISAutobuskaStanica.DataModel.DAO;
using ISAutobuskaStanica.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Services
{
    public class PregledLinijaService : IPregledLinija
    {
        private static PregledLinijaDAO dao = new PregledLinijaDAO();
        public bool AddPregledLinija(PregledLinija pregledLinija)
        {
            return dao.Insert(pregledLinija);
        }

        public bool ChangePregledLinija(PregledLinija pregledLinija)
        {
            PregledLinija pl = dao.FindById(pregledLinija.IDPregleda);
            pl.Linija = pregledLinija.Linija;
            return dao.Update(pl);

        }

        public bool DeletePregledLinija(int id)
        {
            return dao.Delete(id);
        }

        public List<PregledLinija> GetAllPregledLinija()
        {
            return dao.GetAll();
        }

        public bool ValidateLinijaExistance(int id)
        {
            throw new NotImplementedException();
        }

        public bool ValidateRedVoznjeExistance(int id)
        {
            throw new NotImplementedException();
        }
    }
}
