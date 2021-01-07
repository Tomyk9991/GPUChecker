using System;
using System.Collections.Generic;
using System.Linq;

public class GPU
{
    public bool Available { get; private set; }
    public string AvailabilityInformation { get; private set; }
    public string Name { get; private set; }
    public string Brand { get; private set; }
    public string MegaHertz { get; private set; }

    public GPU(bool available, string name, string megaHertz, string brand, string availabilityInformation)
    {
        Available = available;
        Name = name;
        MegaHertz = megaHertz;
        Brand = brand;
        AvailabilityInformation = availabilityInformation;
    }
    
    public static int CalculateHighestStringCount(List<GPU> gpus, Func<GPU, int> func) => gpus.Max(func);
}
