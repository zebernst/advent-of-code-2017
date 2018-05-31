using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Day07 {
    public struct Program {
        public string name;
        public int weight;
        public List<Program> children;
        public List<string> childNames;

        public List<Program> parents;
    }

    public static void task1() {
        var programs = new List<Program>();
        using (StreamReader sr = new StreamReader("day07\\input.txt")) {
            while (!sr.EndOfStream) {
                var input = sr.ReadLine();
                Regex re = new Regex(@"(\w+)\s\((\d+)\)(?: -> )?(.*)?");
                var m = re.Match(input);

                Program p = new Program();
                p.name = m.Groups[1].Value;
                p.weight = int.Parse(m.Groups[2].Value);
                p.childNames = m.Groups[3].Value.Split(", ").ToList();

                programs.Add(p);
                
                Console.WriteLine($"n: {p.name}, w: {p.weight}, c: {string.Join("|", p.childNames)}");
            }
        }

        for (int i = 0; i < programs.Count; i++) {
            var p = programs[i];
            p.parents = programs.Where(pr => pr.childNames.Contains(p.name)).ToList();
            programs[i] = p;
        }

        Console.WriteLine("bottom program: " + programs.Where(p => !p.parents.Any()).Select(p => p.name).First());
    }
}