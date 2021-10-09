using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Leaf : ElectricCar
{
    public Leaf(int vinNumber, int yearBuilt) : base(vinNumber, "Nissan", "Leaf", yearBuilt, 0.3f)
    {
    }
}
