namespace Assignment2
{
    public class Registration
    {
        public int vinNumber { get; }
        public string brand { get; }
        public string model { get; }
        public int yearBuilt { get; }

        public Registration(int vinNumber, string brand, string model, int yearBuilt)
        {
            this.vinNumber = vinNumber;
            this.brand = brand;
            this.model = model;
            this.yearBuilt = yearBuilt;
        }
    }



}
