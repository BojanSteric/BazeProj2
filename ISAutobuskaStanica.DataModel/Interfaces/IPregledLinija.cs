using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Interfaces
{
    public interface IPregledLinija
    {
        bool AddPregledLinija(PregledLinija pregledLinija);
        List<PregledLinija> GetAllPregledLinija();
        bool ChangePregledLinija(PregledLinija pregledLinija);
        bool DeletePregledLinija(int id);
        bool ValidateRedVoznjeExistance(int id);
        bool ValidateLinijaExistance(int id);
    }
}
