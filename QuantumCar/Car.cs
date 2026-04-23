namespace QuantumCar;

public class Car
{
    // each step should be 20.
    public const int SpeedStep = 20;

    // up to 200 speed so we capped at 200.
    public const int MaxSpeed = 200;

    private Engine engine;
    private int speed;
    private bool running;

    public Car(Engine engine)
    {
        this.engine = engine;
    }

    public int Speed => speed;

    public Engine Engine => engine;

    public bool IsRunning => running;

    public void InstallEngine(Engine newEngine)
    {
        if (running)
        {
            Stop();
        }
        engine = newEngine;
        Console.WriteLine($"engine replaced with {engine.Name}.");
    }

    // condition:
    // 1. the engine speed should be 0
    public void Start()
    {
        speed = 0;
        running = true;
        engine.OnCarSpeedChanged(speed);
        Console.WriteLine($"car started. Engine: {engine.Name}, speed: {speed} km/h.");
    }

    // condition:
    // 1. the engine speed should be 0
    public void Stop()
    {
        while (speed > 0) Brake();
        running = false;
        Console.WriteLine("car stopped.");
    }

    // increasing the speed of the car
    // conditions:
    // 1. the car should be running
    // 2. the speed shouldn't be above the max speed of the engine which is capped to 200
    // 3. each step is speed =+ 20
    public void Accelerate()
    {
        if (!running)
        {
            Console.WriteLine("cannot accelerate because the car is not running.");
            return;
        }

        if (speed >= MaxSpeed)
        {
            Console.WriteLine("already at maximum speed.");
            return;
        }

        speed = Math.Min(speed + SpeedStep, MaxSpeed);
        engine.OnCarSpeedChanged(speed);
        Report("accelerate");
    }

    public void Brake()
    {
        if (!running)
        {
            Console.WriteLine("cannot brake becaise the car is not running.");
            return;
        }

        if (speed <= 0)
        {
            Console.WriteLine("car is already at 0 speed.");
            return;
        }

        speed = Math.Max(speed - SpeedStep, 0);
        engine.OnCarSpeedChanged(speed);
        Report("brake");
    }

    // we can use this method to report the speed after each accelerate or brake.
    // it will take the action as param so it might be brake or accelerate.
    private void Report(string action)
    {
        Console.WriteLine(
            $"  [{action}] car: {speed} km/h | engine: {engine.Name} @ {engine.Speed} km/h");
    }
}
