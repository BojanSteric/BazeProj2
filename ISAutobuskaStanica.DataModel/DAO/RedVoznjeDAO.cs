using ISAutobuskaStanica.DataModel.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.DAO
{
    public class RedVoznjeDAO : Repository<RedVoznje>
    {
        public RedVoznje FindByKey(int stanica, int sezona)
        {
            using (var db = new AutobuskaStanicaModelContainer())
            {
                RedVoznje rv = db.RedVoznjes.Find(stanica, sezona);
                return rv;
            }

        }
        public bool DeleteRED(int stanica, int sezona)
        {
            try
            {
                using (var db = new AutobuskaStanicaModelContainer())
                {
                    RedVoznje o = db.RedVoznjes.SingleOrDefault(x => x.AutobuskaStanicaIDAS == stanica && x.VoznaSezonaIdSezone == sezona);

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
        public bool ValidateAutobuskaStanicaExistance(int id)
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

        public bool ValidateVoznaSezonaExistance(int id)
        {
            using (var db = new AutobuskaStanicaModelContainer())
            {
                VoznaSezona o = db.VoznaSezonas.Find(id);
                if (o != null)
                    return true;
                else
                    return false;
            }
        }

    }
}
