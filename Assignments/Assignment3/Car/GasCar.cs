using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class GasCar : CarV2
{
    int gas;
    int tankSizeGallons;
    gasType requiredFuelType;

    public GasCar(int vinNumber, string brand, string model, int yearBuilt, float milePer, gasType requiredFuelType) : base(vinNumber, brand, model, yearBuilt, milePer)
    {
        this.engine = new Engine(Engine.fuelTypes.Gasoline);
        this.requiredFuelType = requiredFuelType;
    }

    public override int distanceOnFuel() => (int)(gas / milePer);

    public enum gasType
    {
        regular,
        premium,
        diesel
    }
}
