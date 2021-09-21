public class Engine
{
    private bool running;
    private int speed;
    private int oilLevel;
    private fuelTypes fuelType;
    private int fuelLevel;

    public Engine(fuelTypes fuelType)
    {
        this.running = false;
        this.speed = 0;
        this.oilLevel = 100;
        this.fuelType = fuelType;
        fuelLevel = 100;
    }
    public int getFuelLevel() => fuelLevel;
    public int increaseFuel(int delta) => ((fuelLevel += delta) > 100) ? fuelLevel += delta : fuelLevel = 100;

    public int speedUp(int delta) => speed += delta;
    public int speedDown(int delta) => speed -= delta;

    public oilStatus getOilStatus()
    {
        if (oilLevel > 90)
        {
            return oilStatus.Optimum;
        }
        else if (oilLevel > 70)
        {
            return oilStatus.Sufficient;
        }
        else
        {
            return oilStatus.Insufficient;
        }

    }

    public enum oilStatus
    {
        Optimum,
        Sufficient,
        Insufficient
    }

    public enum fuelTypes
    {
        Gasoline,
        Diesel,
        Electric,
        Hybrid,
        HouseholdWaste
    }
}

