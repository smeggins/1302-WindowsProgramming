using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GTR : GasCar
{
    bool IntelligentKeyClose;
    public GTR(int vinNumber, int yearBuilt) : base(vinNumber, "Nissan", "GT-R", yearBuilt, 13, gasType.premium)
    {
        IntelligentKeyClose = false;
    }
}
