using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Interfaces
{
    public interface IVoznaSezona
    {
        bool AddVoznaSezona(VoznaSezona voznaSezona);
        List<VoznaSezona> GetAllVoznaSezona();
        bool ChangeVoznaSezona(VoznaSezona voznaSezona);
        bool DeleteVoznaSezona(int id);
    }
}
