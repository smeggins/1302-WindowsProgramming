using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CarFactory
{
    public ILogger logger;

    public CarFactory(ILogger logger)
    {
        this.logger = logger;
    }

    public CarV2 buildElectricCar(CarBuilder builder)
    {
        var car = builder.build(CarBuilder.carTypes.Electric);

        return car;
    }

    public CarV2 buildGasCar(CarBuilder builder)
    {
        var car = builder.build(CarBuilder.carTypes.Gas);

        return car;
    }

    public CarV2 buildHybridCar(CarBuilder builder)
    {
        var car = builder.build(CarBuilder.carTypes.Hybrid);

        return car;
    }

    public CarV2 buildTimeMachine(CarBuilder builder)
    {
        var car = builder.build(CarBuilder.carTypes.TimeMachine);

        return car;
    }

    public CarV2 BuildCarsFromConfig(int configNumber)
    {
        CarV2 car;

        var builder = new CarBuilder(logger);
        builder.addBrand(CarConfigs.Instance.getConfigs()[configNumber].brand)
            .addmilePer(CarConfigs.Instance.getConfigs()[configNumber].mileper)
            .addmodel(CarConfigs.Instance.getConfigs()[configNumber].model)
            .addvinNumber(CarConfigs.Instance.getConfigs()[configNumber].vin)
            .addyearBuilt(CarConfigs.Instance.getConfigs()[configNumber].yearBuilt);

        switch (CarConfigs.Instance.getConfigs()[configNumber].carType)
        {
            case (CarBuilder.carTypes.Electric):
            
                car = buildElectricCar(builder);
                break;
            
            case (CarBuilder.carTypes.Gas):
                car = buildGasCar(builder);
                break;

            case (CarBuilder.carTypes.Hybrid):
                car = buildHybridCar(builder);
                break;

            case (CarBuilder.carTypes.TimeMachine):
                car = buildTimeMachine(builder);
                break;
            default:
                throw new ArgumentException("no valid cartype given on factory build.");

        }
        return car;
    }
}
