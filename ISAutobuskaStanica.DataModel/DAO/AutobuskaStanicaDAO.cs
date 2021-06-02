using ISAutobuskaStanica.DataModel.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace ISAutobuskaStanica.DataModel.DAO
{
    public class AutobuskaStanicaDAO : Repository<AutobuskaStanica>
    {
        public AutobuskaStanica FindById(int id)
        {
            using (var db = new AutobuskaStanicaModelContainer())
            {
                return db.AutobuskaStanicas.Include(a => a.RedVoznjes).SingleOrDefault(o => o.IDAS == id);
            }
        }

        public override List<AutobuskaStanica> GetAll()
        {
            using (var db = new AutobuskaStanicaModelContainer())
            {
                return db.AutobuskaStanicas.Include(u => u.RedVoznjes).ToList();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var db = new AutobuskaStanicaModelContainer())
                {
                    AutobuskaStanica o = db.AutobuskaStanicas.Include(n => n.RedVoznjes).Include(u => u.Ugovors).SingleOrDefault(x => x.IDAS == id);

                    List<RedVoznje> redoviVoznje = new List<RedVoznje>(o.RedVoznjes.ToList());
                    foreach (var item in redoviVoznje)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

                    List<Ugovor> ugovori = new List<Ugovor>(o.Ugovors.ToList());
                    for (int i = 0; i < ugovori.Count; i++)
                    {
                        db.Entry(ugovori[i]).State = EntityState.Deleted;
                    }

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
