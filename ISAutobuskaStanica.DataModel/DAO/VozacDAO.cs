using ISAutobuskaStanica.DataModel.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.DAO
{
    public class VozacDAO : Repository<Vozac>
    {
        public Vozac FindByKey(int vozac, int prevoznik)
        {
            using (var db = new AutobuskaStanicaModelContainer())
            {
                Vozac v = db.Vozacs.Find(vozac, prevoznik);
                return v;
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
        public bool Delete(int prevoznik, int id)
        {
            try
            {
                using (var db = new AutobuskaStanicaModelContainer())
                {
                    Vozac o = db.Vozacs.SingleOrDefault(x => x.IDV == id && x.AutobuskiPrevoznikIDAP == prevoznik);

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
