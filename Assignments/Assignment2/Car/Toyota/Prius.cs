using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Prius : HybridCar
{
    public Prius(int vinNumber, int yearBuilt) : base(vinNumber, "Toyota", "Prius", yearBuilt, 54, GasCar.gasType.regular)
    {
    }
}
