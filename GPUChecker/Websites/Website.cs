using System;
using System.Collections.Generic;
using System.Net;

public abstract class Website
{
    string URL { get; }
    int ArrayOffset { get; }

    protected string[] GetData(string link, int arrOffset)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(this.GetType().Name);
        Console.ForegroundColor = ConsoleColor.Gray;

        string[] result = null;
        
        using (WebClient client = new WebClient())
        {
            Uri uri = new Uri(link);
            
            string temp = client.DownloadString(uri);
            result = WebMethods.ReadDataFrom(temp, arrOffset);
        }

        return result;
    }

    public abstract void PrintGPUToConsole(GPU gpu, int maxStringBrandCount, int maxStringNameCount, int maxStringHertzCount);
    public abstract void CheckAndPrint();
    public abstract List<GPU> ParseResult(string[] input);
}
