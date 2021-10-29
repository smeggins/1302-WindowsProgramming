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

    public CarV2 buildElectricCar(int configNumber, CarBuilder builder)
    {
        var car = builder.addBrand(CarConfigs.Instance.getConfigs()[configNumber].brand)
            .addmilePer(CarConfigs.Instance.getConfigs()[configNumber].mileper)
            .addmodel(CarConfigs.Instance.getConfigs()[configNumber].model)
            .addvinNumber(CarConfigs.Instance.getConfigs()[configNumber].vin)
            .addyearBuilt(CarConfigs.Instance.getConfigs()[configNumber].yearBuilt)
            .build(CarBuilder.carTypes.Electric);

        return car;
    }

    public CarV2 buildGasCar(int configNumber, CarBuilder builder)
    {
        var car = builder.addBrand(CarConfigs.Instance.getConfigs()[configNumber].brand)
            .addmilePer(CarConfigs.Instance.getConfigs()[configNumber].mileper)
            .addmodel(CarConfigs.Instance.getConfigs()[configNumber].model)
            .addvinNumber(CarConfigs.Instance.getConfigs()[configNumber].vin)
            .addyearBuilt(CarConfigs.Instance.getConfigs()[configNumber].yearBuilt)
            .build(CarBuilder.carTypes.Gas);

        return car;
    }

    public CarV2 buildHybridCar(int configNumber, CarBuilder builder)
    {
        var car = builder.addBrand(CarConfigs.Instance.getConfigs()[configNumber].brand)
            .addmilePer(CarConfigs.Instance.getConfigs()[configNumber].mileper)
            .addmodel(CarConfigs.Instance.getConfigs()[configNumber].model)
            .addvinNumber(CarConfigs.Instance.getConfigs()[configNumber].vin)
            .addyearBuilt(CarConfigs.Instance.getConfigs()[configNumber].yearBuilt)
            .build(CarBuilder.carTypes.Hybrid);

        return car;
    }

    public CarV2 buildTimeMachine(int configNumber, CarBuilder builder)
    {
        var car = builder.addBrand(CarConfigs.Instance.getConfigs()[configNumber].brand)
                        .addmilePer(CarConfigs.Instance.getConfigs()[configNumber].mileper)
                        .addmodel(CarConfigs.Instance.getConfigs()[configNumber].model)
                        .addvinNumber(CarConfigs.Instance.getConfigs()[configNumber].vin)
                        .addyearBuilt(CarConfigs.Instance.getConfigs()[configNumber].yearBuilt)
                        .build(CarBuilder.carTypes.TimeMachine);

        return car;
    }

    public CarV2 BuildCarsFromConfig(int configNumber)
    {
        var builder = new CarBuilder(logger);
        CarV2 car;

        switch (CarConfigs.Instance.getConfigs()[configNumber].carType)
        {
            case (CarBuilder.carTypes.Electric):
            
                car = buildElectricCar(configNumber, builder);
                break;
            
            case (CarBuilder.carTypes.Gas):
                car = buildGasCar(configNumber, builder);
                break;

            case (CarBuilder.carTypes.Hybrid):
                car = buildHybridCar(configNumber, builder);
                break;

            case (CarBuilder.carTypes.TimeMachine):
                car = buildTimeMachine(configNumber, builder);
                break;
            default:
                throw new ArgumentException("no valid cartype given on factory build.");

        }
        return car;
    }
}
