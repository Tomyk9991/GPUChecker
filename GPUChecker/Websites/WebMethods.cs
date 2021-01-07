using System;

public static class WebMethods
{
    public static string[] ReadDataFrom(string rawInput, int row)
    {
        return rawInput.Split('\n').SubArray(row);
    }
    
}

public static class Extensions
{
    public static T[] SubArray<T>(this T[] array, int offset, int length = -1)
    {
        if (length == -1)
            length = array.Length - offset;
        
        T[] result = new T[length];

        Array.Copy(array, offset, result, 0, length);

        return result;
    }
}
