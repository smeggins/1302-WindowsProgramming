using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Model3 :ElectricCar
{
    public Model3(int vinNumber, int yearBuilt) : base(vinNumber, "Tesla", "Model3", yearBuilt, 0.31f)
    {
    }
}
