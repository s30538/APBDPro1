namespace APBDPro1;

public class GasCon : Container, IHazardNotifier
{
    public double pressure;
    
    public GasCon(double weight, double mass, double height, double depth, double max, double pressure) : base(weight, mass, height, depth, max, "G")
    {
        this.pressure = pressure;
    }

    public override void Unload()
    {
        weight = weight > max * 0.05 ? max * 0.05 : weight;
    }

    public void Notify(string message)
    {
        Console.WriteLine(base.serialNumber + " " + message);
    }
}