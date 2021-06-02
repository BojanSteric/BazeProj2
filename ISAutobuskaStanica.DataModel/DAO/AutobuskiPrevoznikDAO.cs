using ISAutobuskaStanica.DataModel.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ISAutobuskaStanica.DataModel.DAO
{
    public class AutobuskiPrevoznikDAO : Repository<AutobuskiPrevoznik>
    {
        public bool Delete(int id) 
        {
            try
            {
                using (var db = new AutobuskaStanicaModelContainer())
                {
                    AutobuskiPrevoznik o = db.AutobuskiPrevozniks.Include(n => n.Ugovors).Include(m=>m.Linijas).Include(a=>a.Vozacs).Include(s => s.Autobus).SingleOrDefault(x => x.IDAP == id);

                    List<Autobus> autobusi = new List<Autobus>(o.Autobus.ToList());
                    foreach (var item in autobusi)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

                    List<Vozac> vozaci = new List<Vozac>(o.Vozacs.ToList());
                    foreach (var item in vozaci)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

                    List<Linija> linija = new List<Linija>(o.Linijas.ToList());
                    foreach (var item in linija)
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
