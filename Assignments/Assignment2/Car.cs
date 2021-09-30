using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Car
    {
        private Dashboard dashboard;
        private Engine engine;
        private Registration registration;

        public Car() { }
        public Car(int vinNumber, string brand, string model, int yearBuilt)
        {
            registration = new Assignment2.Registration(vinNumber, brand, model, yearBuilt);
            this.engine = new Assignment2.Engine(model);

            this.dashboard = new Assignment2.Dashboard(this.engine.getFuelLevel(), (this.engine.getOilStatus() != Engine.oilStatus.Insufficient));
        }

        public void speedUp(int delta)
        {
            dashboard.currSpeed = engine.speedUp(delta);
        }
        public void speedDown(int delta)
        {
            dashboard.currSpeed = engine.speedDown(delta);
        }

        public void print()
        {
            Console.WriteLine("\nthe cars info is as follows:");
            Console.WriteLine("brand: " + this.registration.brand);
            Console.WriteLine("model: " + this.registration.model);
            Console.WriteLine("year: " + this.registration.yearBuilt);
            Console.WriteLine("vin Number: " + this.registration.vinNumber);
        }

        public static void test()
        {
            var car1 = new Car(CarConfig1.vin, CarConfig1.brand, CarConfig1.model, CarConfig1.yearBuilt);
            car1.print();

            car1.dashboard.print();
            car1.speedUp(15);
            car1.dashboard.print();

            var car2 = new Car(CarConfig2.vin, CarConfig2.brand, CarConfig2.model, CarConfig2.yearBuilt);
            car2.print();

            car2.dashboard.print();
            car2.speedUp(15);
            car2.dashboard.print();

        }
    }




}
