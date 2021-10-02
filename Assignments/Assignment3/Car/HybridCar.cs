using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class HybridCar : CarV2
{
    protected int gas;
    protected GasCar.gasType requiredFuelType;

    int charge;
    int maxChargeJoules;

    public HybridCar(int vinNumber, string brand, string model, int yearBuilt, float milePer, GasCar.gasType requiredFuelType) : base(vinNumber, brand, model, yearBuilt, milePer)
    {
        this.engine = new Engine(Engine.fuelTypes.Hybrid);
        this.requiredFuelType = requiredFuelType;
        charge = 200;

    }

    public override int distanceOnFuel() => (int)((gas * milePer) + (charge / .3));
    public override void fuelUp(int amount) => gas = amount;


}
