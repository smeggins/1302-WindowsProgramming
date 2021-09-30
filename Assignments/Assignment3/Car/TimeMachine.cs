using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class TimeMachine : CarV2
{
    protected int plutoniumOutputLevel;
    protected int fluxCapacitorReading;

    public TimeMachine(int vinNumber, string brand, string model, int yearBuilt, float milePer) : base(vinNumber, brand, model, yearBuilt, milePer)
    {
        this.engine = new Engine(Engine.fuelTypes.HouseholdWaste);
    }

    public override int distanceOnFuel() => (int)(plutoniumOutputLevel / milePer);
}
