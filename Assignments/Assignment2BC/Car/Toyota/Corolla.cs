using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Corolla : GasCar
{
    public Corolla(int vinNumber, int yearBuilt) : base(vinNumber, "Toyota", "Corolla", yearBuilt, 33, gasType.regular)
    {
    }
}
