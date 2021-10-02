using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class ElectricCar : CarV2
{
    protected int charge;
    protected int maxChargeJoules;

    public ElectricCar(int vinNumber, string brand, string model, int yearBuilt, float milePer) : base(vinNumber, brand, model, yearBuilt, milePer)
    {
        this.engine = new Engine(Engine.fuelTypes.Electric);
    }

    public override int distanceOnFuel() => (int)(charge / milePer);
    public override void fuelUp(int amount) => charge = amount;
}
