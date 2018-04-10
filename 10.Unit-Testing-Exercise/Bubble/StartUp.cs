using System;

public class StartUp
{
    static void Main()
    {
        var arr = new int[] { 34, 3, -2, 341, 123, 49 };
        BubbleSorter.Sort(arr);
        Console.WriteLine(string.Join(" ", arr));
    }
}