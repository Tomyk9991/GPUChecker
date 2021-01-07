using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

public class Caseking : Website
{
    public string URL =>
        @"https://www.caseking.de/pc-komponenten/grafikkarten/nvidia?ckFilters=13915&ckTab=0&sSort=103";

    public int ArrayOffset => 3000;

    public override void CheckAndPrint()
    {
        string[] result = base.GetData(this.URL, this.ArrayOffset);
        List<GPU> gpus = ParseResult(result);
            
        int maxStringBrandCount = GPU.CalculateHighestStringCount(gpus, gpu => gpu.Brand.Length);
        int maxStringNameCount = GPU.CalculateHighestStringCount(gpus, gpu => gpu.Name.Length);
        int maxStringHertzCount = GPU.CalculateHighestStringCount(gpus, gpu => gpu.MegaHertz.Length);
        
        gpus = gpus.OrderBy(gpu => gpu.Available).ThenByDescending(gpu => gpu.MegaHertz)
            .ThenBy(gpu => gpu.Brand).ToList();
        
        foreach (var gpu in gpus)
            this.PrintGPUToConsole(gpu, maxStringBrandCount, maxStringNameCount, maxStringHertzCount);
    }

    public override void PrintGPUToConsole(GPU gpu, int maxStringBrandCount, int maxStringNameCount, int maxStringHertzCount)
    {
        int width = 0;
        int height = Console.CursorTop;
        
        Console.Write("Marke:\t" + gpu.Brand);
        
        width = Console.CursorLeft;
        Console.SetCursorPosition(width + (maxStringBrandCount + 4) - gpu.Brand.Length, height);

        Console.Write("Name:\t" + gpu.Name);

        width = Console.CursorLeft;
        Console.SetCursorPosition(width + (maxStringNameCount + 4) - gpu.Name.Length, height);

        Console.Write("Hertz:\t" + gpu.MegaHertz);
        
        width = Console.CursorLeft;
        Console.SetCursorPosition(width + (maxStringHertzCount + 4) - gpu.MegaHertz.Length, height);
        
        Console.ForegroundColor = gpu.Available ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine("Verfügbarkeit: \t\t" + gpu.AvailabilityInformation);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public override List<GPU> ParseResult(string[] input)
    {
        List<string> brandNames = new List<string>(48);
        List<string> productNames = new List<string>(48);
        List<string> megaHertzes = new List<string>(48);
        List<bool> available = new List<bool>(48);
        List<string> availablilityInformation = new List<string>(48);

        for (int i = 0; i < input.Length; i++)
        {
            string ith = input[i];
            if (ith.Contains("<span class=\"ProductSubTitle\">"))
            {
                string brand = input[i + 1].Replace("\r", "");
                string productName = input[i + 4].Replace("\r", "");
                string megaHertz = input[i + 9].Split(',')[1];

                brandNames.Add(brand);
                productNames.Add(productName);
                megaHertzes.Add(megaHertz);

                string availabilityInformation = input[i + 36].Split('>')[1].Split('<')[0];

                available.Add(input[i + 36].Contains("lagernd"));
                availablilityInformation.Add(availabilityInformation);
            }
        }

        List<GPU> gpus = new List<GPU>(brandNames.Count);

        for (int i = 0; i < brandNames.Count; i++)
        {
            gpus.Add(new GPU(available[i], productNames[i], megaHertzes[i], brandNames[i],
                availablilityInformation[i]));
        }

        return gpus;
    }
}
