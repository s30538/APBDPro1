using System.Text;

namespace APBDPro1;

public class Ship
{
    public List<Container> containers { get; set; }
    public double maxSpeed { get; set; }
    public int conCount { get; set; }
    public double maxWeight { get; set; }
    public double actaullWeight {get; set; }

    public Ship(double maxSpeed, int conCount, double maxWeight)
    {
        containers = new List<Container>();
        this.maxSpeed = maxSpeed;
        this.conCount = conCount;
        this.maxWeight = maxWeight;
        actaullWeight = 0;
    }

    public void Load(Container container)
    {
        if (containers.Count + 1 > conCount)
            throw new Exception("Za dużo kontenerow");
        if (actaullWeight + container.weight > maxWeight)
            throw new Exception("Za duza masa kontenerow");
        containers.Add(container);
        actaullWeight += container.weight;
    }
    
    public void Load(List<Container> containersToAdd)
    {
        if (containers.Count + containersToAdd.Count > conCount)
            throw new Exception("Za dużo kontenerow");

        double weightToAdd = 0;
        
        foreach (Container container in containersToAdd)
            weightToAdd += container.weight;

        if (actaullWeight + weightToAdd > maxWeight)
            throw new Exception("Za duza masa kontenerow");
        containers.AddRange(containers);
        actaullWeight += weightToAdd;
    }

    public void Remove(Container container)
    {
        if (!containers.Contains(container))
            throw new Exception("Nie ma takiego kontenera na statku");
        actaullWeight -= container.weight;
        containers.Remove(container);
    }

    public void Unload(Container container)
    {
        if (!containers.Contains(container))
            throw new Exception("Nie ma takiego kontenera na statku");
        actaullWeight -= container.weight;
        containers[containers.IndexOf(container)].Unload();
        actaullWeight += container.weight;
    }

    public void Replace(string number, Container container)
    {
        Remove(containers[containers.FindIndex(c => c.serialNumber == number)]);
        Load(container);
    }

    public void Swap(Container container, Ship ship)
    {
        Remove(container);
        ship.Load(container);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Ship: maxSpeed: {maxSpeed}, conCount: {conCount}, maxWeight: {maxWeight}");
        sb.AppendLine("Ladunek: ");
        foreach (Container container in containers)
        {
            sb.AppendLine(container.ToString());
        }
        return sb.ToString();
    }

}