using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class Day08 {
    private class Register 
    {
        public readonly string name;
        public int value;

        public Register(string name) 
        {
            this.name = name;
            this.value = 0;
        }

        public override string ToString() {
            return $"{this.name}: {this.value}";
        }
    }

    public static Boolean Operator(this string str, int a, int b) 
    {
        switch (str) 
        {
            case "<": return a < b;
            case ">": return a > b;
            case "==": return a == b;
            case "!=": return a != b;
            case "<=": return a <= b;
            case ">=": return a >= b;
            default: throw new ArgumentException("invalid logic string");
        }
    }

    public static void task1() {
        var registers = new List<Register>();
        var instructions = new List<Match>();
        using (StreamReader sr = new StreamReader("day08\\input.txt")) {
            while (!sr.EndOfStream) {
                var input = sr.ReadLine();
                Regex re = new Regex(@"^(\w+)\s(inc|dec)\s(-?\d+)\sif\s(\w+)\s([<>=!]{1,2})\s(-?\d+)$");
                var m = re.Match(input);

                var search = registers.Where(rg => rg.name.Equals(m.Groups[1].Value));
                if (!search.Any())
                    registers.Add(new Register(name: m.Groups[1].Value));

                instructions.Add(m);
            }
        }

        for (int i = 0; i < instructions.Count; i++) {
            var m = instructions[i];

            var operation = m.Groups[2].Value;
            var value = int.Parse(m.Groups[3].Value);
            var queryType = m.Groups[5].Value;
            var queryValue = int.Parse(m.Groups[6].Value);

            var targetRegister = registers.Where(r => r.name == m.Groups[1].Value).Single();
            var queryRegister = registers.Where(r => r.name == m.Groups[4].Value).Single();

            if (queryType.Operator(queryRegister.value, queryValue)) {
                switch (operation) {
                    case "inc": targetRegister.value += value; break;
                    case "dec": targetRegister.value -= value; break;
                }
            }
        }
        
        Console.WriteLine($"largest value in any register: {registers.Select(r => r.value).Max()}");
    }
}