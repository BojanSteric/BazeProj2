using ISAutobuskaStanica.DataModel.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ISAutobuskaStanica.DataModel.DAO
{
    public class VoznaSezonaDAO : Repository<VoznaSezona>
    {
        public bool Delete(int id) 
        {
            try
            {
                using (var db = new AutobuskaStanicaModelContainer())
                {
                    VoznaSezona o = db.VoznaSezonas.Include(l => l.RedVoznjes).SingleOrDefault(x => x.IdSezone == id);
                    
                    List<RedVoznje> redoviVoznje = new List<RedVoznje>(o.RedVoznjes.ToList());
                    foreach (var item in redoviVoznje)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

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
