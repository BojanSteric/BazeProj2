using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Interfaces
{
    public interface IUgovor
    {
        bool AddUgovor(Ugovor ugovor);
        List<Ugovor> GetAllUgovor();
        bool ChangeUgovor(Ugovor ugovor);
        bool DeleteUgovor(int stanica, int prevoznik);
        bool ValidateStanicaExistance(int id);
        bool ValidatePrevoznikExistance(int id);
    }
}
