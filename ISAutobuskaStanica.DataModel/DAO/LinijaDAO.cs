using ISAutobuskaStanica.DataModel.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.DAO
{
    public class LinijaDAO : Repository<Linija>
    {
        public Linija FindByKey(string linija, int prevoznik)
        {
            using (var db = new AutobuskaStanicaModelContainer())
            {
                Linija line = db.Linijas.Find(linija, prevoznik);
                return line;
            }
        }
        public bool ValidatePrevoznikExistance(int id)
        {
            using (var db = new AutobuskaStanicaModelContainer())
            {
                AutobuskiPrevoznik o = db.AutobuskiPrevozniks.Find(id);
                if (o != null)
                    return true;
                else
                    return false;
            }
        }
        public bool Delete(int id, string naziv) 
        {
            try
            {
                using (var db = new AutobuskaStanicaModelContainer())
                {
                    Linija o = db.Linijas.SingleOrDefault(x => x.AutobuskiPrevoznikIDAP == id && x.NazivLinije.Equals(naziv));

                    db.Entry(o).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Message:\n" + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n" + e.InnerException);
                return false;
            }
        }
    }
}
