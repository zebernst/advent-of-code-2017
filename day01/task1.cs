using System;
using System.IO;

class Task1 {
    public static void Main() {
        // read input
        string input;
        using (StreamReader sr = new StreamReader("day01\\input.txt")) {
            input = sr.ReadToEnd().Trim();
        }

        int sum = 0;
        for (int idx = 0; idx < (input.Length - 1); ++idx) {
            if (input[idx] == input[idx + 1]) {
                sum += Int32.Parse(input[idx].ToString());
            }
        }

        if (input[0] == input[input.Length - 1]) {
            sum += Int32.Parse(input[0].ToString());
        }

        Console.WriteLine($"sum: {sum}");
    }
}