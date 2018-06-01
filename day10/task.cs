using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Day10 
{
    public static void task1()
    {
        List<int> lengths;
        using (var sr = new StreamReader("day10\\input.txt"))
            lengths = sr.ReadLine().Split(",").Select(i => int.Parse(i)).ToList();
        
        var hash = Enumerable.Range(0, 256).ToList();

        int pos = 0, skip = 0;
        foreach (var length in lengths)
        {
            var sublist = new List<int>(length);
            for (int i = 0; i < length; i++)
                sublist.Add(hash[(pos + i) % hash.Count]);
            
            sublist.Reverse();

            for (int i = 0; i < sublist.Count; i++) 
                hash[(pos + i) % hash.Count] = sublist[i];
            
            pos = (pos + length + skip) % hash.Count;
            skip++;
        }

        Console.WriteLine($"sum of first two numbers: {hash[0] * hash[1]}");
    }
}