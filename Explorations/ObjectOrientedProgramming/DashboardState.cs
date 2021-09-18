using System;

public class DashboardState
{
    public int mileage { get; set; }
    public int currSpeed { get; set; }
    public int fuel { get; set; }
    public bool checkOil { get; set; }

    public void print()
    {
        Console.WriteLine("\ndashboard info:");
        Console.WriteLine("mileage: " + this.mileage);
        Console.WriteLine("currSpeed: " + this.currSpeed);
        Console.WriteLine("fuel: " + this.fuel);
        Console.WriteLine("checkOil: " + this.checkOil);
    }
}

