using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Day11
{
    public static void task1()
    {
        List<string> steps;
        using (var sr = new StreamReader("day11\\input.txt"))
            steps = sr.ReadLine().Split(",").ToList();

        int x = 0, y = 0;
        foreach (var step in steps)
        {
            switch (step) 
            {
                case "nw": --x; ++y; break;
                case "n" :      ++y; break;
                case "ne": ++x;    ; break;
                case "sw": --x;    ; break;
                case "s" :      --y; break;
                case "se": ++x; --y; break;
            }
        }

        int numSteps = (Math.Abs(x) + Math.Abs(y) + Math.Abs(x+y)) / 2;

        Console.WriteLine($"# steps: {numSteps}");
    }

        public static void task2()
    {
        List<string> steps;
        using (var sr = new StreamReader("day11\\input.txt"))
            steps = sr.ReadLine().Split(",").ToList();

        int x = 0, y = 0;

        var dists = new List<int>();
        foreach (var step in steps)
        {
            switch (step) 
            {
                case "nw": --x; ++y; break;
                case "n" :      ++y; break;
                case "ne": ++x;    ; break;
                case "sw": --x;    ; break;
                case "s" :      --y; break;
                case "se": ++x; --y; break;
            }
            int numSteps = (Math.Abs(x) + Math.Abs(y) + Math.Abs(x+y)) / 2;
            dists.Add(numSteps);
        }

        Console.WriteLine($"max distance: {dists.Max()}");
    }
}