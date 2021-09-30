using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ModelX : ElectricCar
{
    public ModelX(int vinNumber, int yearBuilt) : base(vinNumber, "Tesla", "ModelX", yearBuilt, 0.39f)
    {
    }
}
