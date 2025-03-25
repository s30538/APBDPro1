namespace APBDPro1;

public class RefrigeratedCon : Container
{
    public string productType { get; set; }
    public double temperature { get; set; }
    public double productTemperature { get; set; }
    
    public RefrigeratedCon(double weight, double mass, double height, double depth, double max, string productType, double temperature, double productTemperature) : base(weight, mass, height, depth, max, "R")
    {
        this.productType = productType;
        this.temperature = temperature;
        this.productTemperature = productTemperature;

        if (this.temperature > this.productTemperature)
        {
            throw new Exception("Za niska temperatura");
        }
    }
    
}