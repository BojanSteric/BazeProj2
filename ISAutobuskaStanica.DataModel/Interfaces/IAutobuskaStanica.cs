﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Interfaces
{
    public interface IAutobuskaStanica
    {
        bool AddAutobuskaStanica(AutobuskaStanica autobuskaStanica);
        List<AutobuskaStanica> GetAllAutobuskaStanica();
        bool ChangeAutobuskaStanica(AutobuskaStanica autobuskaStanica);
        bool DeleteAutobuskaStanica(int id);
    }
}
