namespace QuantumCar;

// we can make abstract class and use it as contract for elec and gasoline engines and the hybrid as a base.
public abstract class Engine
{
    protected int speed;

    // we need to make sure it's virtual so we can override it in the mixed engine depending on the active engine.
    public virtual int Speed => speed;

    public abstract string Name { get; }

    public virtual void Increase()
    {
        speed++;
    }

    public virtual void Decrease()
    {
        if (speed > 0) speed--;
    }

    public virtual void OnCarSpeedChanged(int carSpeed)
    {
        while (speed < carSpeed) Increase();
        while (speed > carSpeed) Decrease();
    }
}
