public class Dashboard
{
    public int mileage { get; set; }
    public int currSpeed { get; set; }
    public int fuel { get; set; }
    public bool checkOil { get; set; }

    public Dashboard()
    {
        mileage = 0;
        currSpeed = 0;
        fuel = 0;
        checkOil = false;
    }
}

