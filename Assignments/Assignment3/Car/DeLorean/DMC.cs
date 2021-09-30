using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DMC : TimeMachine
{
    private bool isGoing88MPH;

    public DMC(int vinNumber, int yearBuilt) : base(vinNumber, "DeLorean", "DMC", yearBuilt, 20)
    {
        isGoing88MPH = false;
    }
}
