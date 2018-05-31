using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Day06 {
    public static void task1() {
        List<int> input;
        using (StreamReader sr = new StreamReader("day06\\input.txt")) {
            input = sr.ReadLine().Split().Select(i => int.Parse(i)).ToList();
        }

        int cycles = 0;
        var encountered = new List<string>();
        while (true) {
            int maxIdx = 0;
            for (int idx = 0; idx < input.Count; idx++) {
                if (input[idx] > input[maxIdx]) 
                    maxIdx = idx;
            }

            int stack = input[maxIdx], i = (maxIdx + 1) % input.Count;
            input[maxIdx] = 0;
            while (stack > 0) {
                input[i]++;
                i = (i + 1) % input.Count;
                stack--;
            }

            cycles++;

            var cycleStr = string.Join(" ", input);

            if (encountered.Contains(cycleStr))
                break;
            else
                encountered.Add(cycleStr);

        }

        Console.WriteLine($"number of cycles: {cycles}");
    }

    public static void task2() {
        List<int> input;
        using (StreamReader sr = new StreamReader("day06\\input.txt")) {
            input = sr.ReadLine().Split().Select(i => int.Parse(i)).ToList();
        }

        int cycles = 0;
        var encountered = new List<string>();
        while (true) {
            int maxIdx = 0;
            for (int idx = 0; idx < input.Count; idx++) {
                if (input[idx] > input[maxIdx]) 
                    maxIdx = idx;
            }

            int stack = input[maxIdx], i = (maxIdx + 1) % input.Count;
            input[maxIdx] = 0;
            while (stack > 0) {
                input[i]++;
                i = (i + 1) % input.Count;
                stack--;
            }

            var cycleStr = string.Join(" ", input);

            if (encountered.Contains(cycleStr)) 
                cycles++;
            encountered.Add(cycleStr);

            int timesSeen = 0;
            foreach (var s in encountered) {
                if (s.Equals(cycleStr)) timesSeen++;
            }
            if (timesSeen == 3) { 
                break; 
            }
        }

        Console.WriteLine($"number of cycles: {cycles-1}");
    }
}