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
            }
        }

        for (int i = 0; i < programs.Count; i++) {
            var p = programs[i];
            p.parents = programs.Where(pr => pr.childNames.Contains(p.name)).ToList();
            programs[i] = p;
        }

        Console.WriteLine("bottom program: " + programs.Where(p => !p.parents.Any()).Select(p => p.name).First());
    }

    public static void task2() {
        var programs = new List<Program>();
        using (StreamReader sr = new StreamReader("day07\\input.txt")) {
            while (!sr.EndOfStream) {
                var input = sr.ReadLine();
                Regex re = new Regex(@"(\w+)\s\((\d+)\)(?: -> )?(.*)?");
                var m = re.Match(input);

                Program p = new Program();
                p.name = m.Groups[1].Value;
                p.weight = int.Parse(m.Groups[2].Value);
                p.childNames = m.Groups[3].Value.Equals("") ? new List<string>() : m.Groups[3].Value.Split(", ").ToList();
                p.children = new List<Program>();

                programs.Add(p);
            }
        }

        for (int i = 0; i < programs.Count; i++) {
            var p = programs[i];
            p.parents = programs.Where(pr => pr.childNames.Contains(p.name)).ToList();
            programs[i] = p;
        }

        foreach (var p in programs) 
            if (p.childNames.Any()) 
                foreach (var name in p.childNames) 
                    p.children.Add(programs.Where(pr => pr.name.Equals(name)).First());

        var root = programs.Where(p => !p.parents.Any()).First();

        Program faultyProgram = findUnbalanced(root);
        var weightedGroups = faultyProgram.parents.First().children.GroupBy(c => towerWeight(c)).OrderBy(g => g.Count()).Select(g => g.Key);
        int correctWeight = faultyProgram.weight + (weightedGroups.Last() - weightedGroups.First());

        Console.WriteLine($"parent: {faultyProgram.parents.First().name}");
        foreach (var p in faultyProgram.parents.First().children)
            Console.WriteLine($" child: {p.name} ({towerWeight(p)} = {p.weight} + children)");
        Console.WriteLine($"program {faultyProgram.name} should have weight {correctWeight}");
    }

    private static int towerWeight(Program root) {
        if (!root.children.Any())
            return root.weight;
        
        int[] weights = new int[root.children.Count];
        for (int i = 0; i < root.children.Count; i++)
            weights[i] = towerWeight(root.children[i]);;
        
        return root.weight + weights.Sum();
    }

    private static Program findUnbalanced(Program root) {
        var childWeights = new int[root.children.Count()];
        for (int i = 0; i < root.children.Count(); i++)
            childWeights[i] = towerWeight(root.children[i]);

        var weightedGroups = childWeights.GroupBy(c => c).OrderBy(g => g.Count());
        if (weightedGroups.Count() == 1) 
            return root;

        int oddWeightOut = weightedGroups.Select(g => g.Key).First();
        Program faultyPath = root.children[Array.IndexOf(childWeights, oddWeightOut)];

        return findUnbalanced(faultyPath);
    }
}