namespace QuantumCar;

public class MixedHybridEngine : Engine
{
    private const int SwitchSpeed = 50;

    private readonly GasolineEngine gas = new();
    private readonly ElectronicEngine electric = new();
    private Engine active;

    public MixedHybridEngine()
    {
        active = electric;
    }

    public override string Name => $"mixed hybrid (active: {active.Name})";

    public override int Speed => active.Speed;

    public override void Increase()
    {
        active.Increase();
    }

    public override void Decrease()
    {
        active.Decrease();
    }

    // cost optimized so we don't run both engines at the same time as stated
    public override void OnCarSpeedChanged(int carSpeed)
    {
        Engine target = carSpeed < SwitchSpeed ? electric : gas;

        if (target != active)
        {
            Console.WriteLine(
                $"hybrid switching engine: {active.Name} to {target.Name} (car speed {carSpeed} km/h)");
            while (active.Speed > 0) active.Decrease();
            active = target;
        }

        while (active.Speed < carSpeed) active.Increase();
        while (active.Speed > carSpeed) active.Decrease();
    }
}
