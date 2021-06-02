using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Interfaces
{
    public interface IVozac
    {
        bool AddVozac(Vozac vozac);
        List<Vozac> GetAllVozac();
        bool ChangeVozac(Vozac vozac);
        bool DeleteVozac(int prevoznik, int id);
        bool ValidatePrevoznikExistance(int id);
    }
}
