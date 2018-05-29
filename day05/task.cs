using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Day05 {
    public static void task1() {
        var input = new List<int>();
        using (StreamReader sr = new StreamReader("day05\\input.txt")) {
            while (!sr.EndOfStream) {
                input.Add(Int32.Parse(sr.ReadLine()));
            }
        }

        int currentIdx = 0, numSteps = 0;
        while (currentIdx < input.Count && currentIdx >= 0) {
            int jumpDist = input[currentIdx];
            input[currentIdx]++;

            currentIdx += jumpDist;
            numSteps++;
        }
        
        Console.WriteLine($"# of steps taken: {numSteps}");
    }
}