using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Interfaces
{
    public interface IAutobus
    {
        bool AddAutobus(Autobus autobus);
        List<Autobus> GetAllAutobus();
        bool ChangeAutobus(Autobus autobus);
        bool DeleteAutobus(int id, int ida);
        bool ValidatePrevoznikExistance(int id);
    }
}
