using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Day04 {
    public static void task1() {
        var input = new List<string>();
        using (StreamReader sr = new StreamReader("day04\\input.txt")) {
            while (!sr.EndOfStream) {
                input.Add(sr.ReadLine());
            }
        }

        var validPassphrases = new List<List<string>>();
        foreach (var passphrase in input) {
            string[] words = passphrase.Split(' ');
            if (words.Length == words.Distinct().Count()) {
                validPassphrases.Add(words.ToList());
            }
        }

        Console.WriteLine($"# of valid passphrases: {validPassphrases.Count()}");
    }
}