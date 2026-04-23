namespace QuantumCar;

public class CarFactory
{
    public Car BuildCar(EngineType type)
    {
        return new Car(CreateEngine(type));
    }
    
    // ability to replace engine for cost optimization.
    public void ReplaceEngine(Car car, EngineType type)
    {
        car.InstallEngine(CreateEngine(type));
    }

    // method to create engine based on enum type we get. 
    // we will use switch instead of if statement
    private Engine CreateEngine(EngineType type)
    {
        switch (type)
        {
            case EngineType.Gasoline:
                return new GasolineEngine();
            case EngineType.Electronic:
                return new ElectronicEngine();
            case EngineType.MixedHybrid:
                return new MixedHybridEngine();
            default:
                throw new ArgumentException($"unsupported engine type: {type}");
        }
    }
}
