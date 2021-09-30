using System;

namespace Assignment2
{
    public class Dashboard
    {
        public int mileage { get; set; }
        public int currSpeed { get; set; }
        public int fuel { get; set; }
        public bool indicatorCheckOil { get; set; }
        public bool indicatorLowFuel { get; set; }

        public Dashboard(int fuel, bool checkOil)
        {
            mileage = 0;
            currSpeed = 0;
            this.fuel = fuel;
            this.indicatorCheckOil = checkOil;
        }

        public void print()
        {
            Console.WriteLine("\ndashboard info:");
            Console.WriteLine("mileage: " + this.mileage);
            Console.WriteLine("currSpeed: " + this.currSpeed);
            Console.WriteLine("fuel: " + this.fuel);
            Console.WriteLine("checkOil: " + this.indicatorCheckOil);
            Console.WriteLine("lowFuel: " + this.indicatorLowFuel);
        }
    }


}
