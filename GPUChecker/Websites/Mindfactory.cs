using System;
using System.Collections.Generic;
using System.Linq;

public class Mindfactory : Website
{
    public string URL =>
        @"https://www.mindfactory.de/Hardware/Grafikkarten+(VGA)/GeForce+RTX+fuer+Gaming/RTX+3080.html";

    public int ArrayOffset = 0;

    public override void PrintGPUToConsole(GPU gpu, int maxStringBrandCount, int maxStringNameCount, int maxStringHertzCount) { }
    
    public override void CheckAndPrint()
    {
        string[] result = base.GetData(this.URL, this.ArrayOffset);

        bool found = result.Any(t => t.Contains("Keine Artikel in der Kategorie!"));

        if (found)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Keine Grafikkarten");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GRAAAAAAAFIKKARTEN!!!!!!1111!!111elf!!!121^11");
            Console.WriteLine("GRAAAAAAAFIKKARTEN!!!!!!1111!!111elf!!!121^11");
            Console.WriteLine("GRAAAAAAAFIKKARTEN!!!!!!1111!!111elf!!!121^11");
            Console.WriteLine("GRAAAAAAAFIKKARTEN!!!!!!1111!!111elf!!!121^11");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    public override List<GPU> ParseResult(string[] input)
    {
        throw new System.NotImplementedException();
    }
}
