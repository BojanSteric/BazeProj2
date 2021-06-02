using ISAutobuskaStanica.DataModel.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.DAO
{
    public class AutobusDAO : Repository<Autobus>
    {
        public Autobus FindByKey(int bus, int prevoznik)
        {
            using (var db = new AutobuskaStanicaModelContainer())
            {
                Autobus a= db.Autobus.Find(bus, prevoznik);
                return a;
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

        public bool Delete(int id, int ida)
        {
            try
            {
                using (var db = new AutobuskaStanicaModelContainer())
                {
                    Autobus o = db.Autobus.SingleOrDefault(x => x.IDA == ida && x.AutobuskiPrevoznikIDAP == id);

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
