using System;
using System.IO;

class Day01 {
    public static void task1() {
        // read input
        string input;
        using (StreamReader sr = new StreamReader("day01\\input.txt"))
            input = sr.ReadToEnd().Trim();

        int sum = 0;
        for (int idx = 0; idx < input.Length; ++idx) 
            if (input[idx] == input[(idx + 1) % input.Length]) 
                sum += Int32.Parse(input[idx].ToString());


        Console.WriteLine($"sum: {sum}");
    }

    public static void task2() {
        // read input
        string input;
        using (StreamReader sr = new StreamReader("day01\\input.txt")) {
            input = sr.ReadToEnd().Trim();
        }

        int sum = 0, half = input.Length/2;
        for (int idx = 0; idx < (input.Length - 1); ++idx) {
            if (input[idx] == input[(idx + half) % input.Length]) {
                sum += Int32.Parse(input[idx].ToString());
            }
        }

        Console.WriteLine($"sum: {sum}");
    }
}