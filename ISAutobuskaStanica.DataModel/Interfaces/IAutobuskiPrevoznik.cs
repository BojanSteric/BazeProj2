using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Interfaces
{
    public interface IAutobuskiPrevoznik
    {
        bool AddAutobuskiPrevoznik(AutobuskiPrevoznik autobuskiPrevoznik);
        List<AutobuskiPrevoznik> GetAllAutobuskiPrevoznik();
        bool ChangeAutobuskiPrevoznik(AutobuskiPrevoznik autobuskiPrevoznik);
        bool DeleteAutobuskiPrevoznik(int id);
    }
}
