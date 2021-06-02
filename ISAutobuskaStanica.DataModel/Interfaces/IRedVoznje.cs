using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Interfaces
{
    public interface IRedVoznje
    {
        bool AddRedVoznje(RedVoznje redVoznje);
        List<RedVoznje> GetAllRedVoznje();
        bool ChangeRedVoznje(RedVoznje redVoznje);
        bool DeleteRedVoznje(int stanica, int sezona);
        bool ValidateStanicaExistance(int id);
        bool ValidateSezonaExistance(int id);
    }
}
