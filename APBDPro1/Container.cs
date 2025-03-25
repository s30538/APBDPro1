namespace APBDPro1;

public abstract class Container
{
    public double weight { get; set; }
    public double mass { get; set; }
    public double height{ get; set; } 
    public double depth { get; set; }
    public double max { get; set; }
    public static int index = 0;
    public string serialNumber { get; set; }
    
    public Container(double weight, double mass, double height, double depth, double max, string conType)
    {
        index++;
        this.serialNumber = $"KON-{conType}-{index}";
        this.mass = mass;
        this.height = height;
        this.weight = weight;
        this.depth = depth;
        this.max = max;
    }

    public virtual void Loading(float value)
    {
        if (weight > max)
        {
            throw new OverflowException();
        }
    }
    
    public virtual void Unload()
    {
        weight = 0;
    }
    
}