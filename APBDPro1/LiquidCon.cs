namespace APBDPro1;

public class LiquidCon : Container, IHazardNotifier
{
    private double loaded = 0;
    private bool isDengerous;
    public LiquidCon(double weight, double mass, double height, double depth, double max, bool isDengerous) : base(weight, mass, height, depth, max, "L")
    {
        this.isDengerous = isDengerous;
        this.IsCorrect(0);
    }

    public bool IsCorrect( float value)
    {
        if ((weight + value) > max)
        {
            Notify("Przepelniony");
            throw new OverfillException(serialNumber + " Przepelniony");
        }

        if (isDengerous && (weight + value) > max / 2)
        {
            Notify("Za duza ilosc niebezpiecznego ladunku");
            throw new OverfillException(serialNumber + " za duza ilosc dla niebezpiecznego ladunku");
        }

        if (!isDengerous && (weight + value) > max * 0.9)
        {
            Notify("Za duza ilosc dla bezpiecznego ladunku");
            throw new OverfillException(serialNumber + " za duza ilosc dla bezpiecznego ladunku");
        }

        return true; 
    }

    public override void Loading(float value)
    {
        if (IsCorrect(value))
        {
            weight += value;
        }
    }
    public void Notify(string message)
    {
        Console.WriteLine(this.serialNumber + " " + message);
    }
}