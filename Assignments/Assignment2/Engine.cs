namespace Assignment2
{
    public class Engine
    {
        private bool running;
        private int speed;
        private int oilLevel;
        private fuelTypes fuelType;
        private int fuelLevel;

        public Engine(string model)
        {
            this.running = false;
            this.speed = 0;
            this.oilLevel = 100;
            this.fuelLevel = 100;
            this.fuelType = selectFuelType(model);
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

        public fuelTypes selectFuelType(string model)
        {
            if (model == "DMC-12")
            {
                return fuelTypes.HouseholdWaste;
            }
            else
            {
                return fuelTypes.Gasoline;
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


}
