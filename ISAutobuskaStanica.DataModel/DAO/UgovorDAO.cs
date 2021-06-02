using ISAutobuskaStanica.DataModel.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.DAO
{
    public class UgovorDAO : Repository<Ugovor>
    {
        public Ugovor FindByKey(int stanica, int prevoznik)
        {
            using (var db = new AutobuskaStanicaModelContainer())
            {
                Ugovor u = db.Ugovors.Find(stanica, prevoznik);
                return u;
            }
        }
        public bool ValidateStanicaExistance(int id)
        {
            using (var db = new AutobuskaStanicaModelContainer())
            {
                AutobuskaStanica o = db.AutobuskaStanicas.Find(id);
                if (o != null)
                    return true;
                else
                    return false;
            }
        }
        public bool Delete(int stanica, int prevoznik) 
        {
            try
            {
                using (var db = new AutobuskaStanicaModelContainer())
                {
                    Ugovor o = db.Ugovors.SingleOrDefault(x => x.AutobuskaStanicaIDAS == stanica && x.AutobuskiPrevoznikIDAP == prevoznik);

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
    }
}
