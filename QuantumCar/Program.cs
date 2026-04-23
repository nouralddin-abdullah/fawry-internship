namespace QuantumCar;

internal class Program
{
    static void Main(string[] args)
    {
        var factory = new CarFactory();

        // testing all cars types
        Console.WriteLine("gasoline car");
        var gasCar = factory.BuildCar(EngineType.Gasoline);
        Drive(gasCar);

        Console.WriteLine();
        Console.WriteLine("electric car");
        var electricCar = factory.BuildCar(EngineType.Electronic);
        Drive(electricCar);

        Console.WriteLine();
        Console.WriteLine("eybrid car");
        var hybridCar = factory.BuildCar(EngineType.MixedHybrid);
        Drive(hybridCar);
    }

    static void Drive(Car car)
    {
        car.Start();

        for (int i = 0; i < 12; i++)
        {
            car.Accelerate();
        }

        for (int i = 0; i < 5; i++)
        {
            car.Brake();
        }

        car.Stop();
    }
}
