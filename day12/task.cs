using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class Day12 
{
    public static void ToDotLang() 
    {
        using (var sr = new StreamReader("day12\\input.txt"))
        {
            var lines = new List<string>();
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                Regex re = new Regex(@"^(\d+) <-> (.*)");
                var m = re.Match(line);

                var src = m.Groups[1].Value;
                var dests = m.Groups[2].Value.Split(", ");

                lines.Add($"    {src} -- {{ {String.Join(" ", dests)} }};");
            }

            // using (var sw = new StreamWriter(day21))
            System.IO.File.WriteAllLines("day12\\graphviz.txt", lines.Prepend("graph G {").Append("}"));
        }
    }

    private class Program 
    {
        public readonly int id;
        public HashSet<Program> communications;

        public Program(int id)
        {
            this.id = id;
            this.communications = new HashSet<Program>();
        }

        public override string ToString() 
        {
            return $"Program(id:{id})";
        }
    }

    public static void task1() 
    {
        var town = new HashSet<Program>();
        using (var sr = new StreamReader("day12\\input.txt"))
        {
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                Regex re = new Regex(@"^(\d+) <-> (.*)");
                var m = re.Match(line);

                var src = int.Parse(m.Groups[1].Value);
                var dests = m.Groups[2].Value.Split(", ").Select(v => int.Parse(v));      

                var srcExists = town.Where(o => o.id.Equals(src)).Any();
                var p = srcExists ? town.Where(o => o.id.Equals(src)).Single() : new Program(id:src);
                if (!srcExists) town.Add(p);

                foreach (var dest in dests) 
                {
                    if (src.Equals(dest)) continue;
                    var destExists = town.Where(o => o.id.Equals(dest)).Any();
                    var d = destExists ? town.Where(o => o.id.Equals(dest)).Single() : new Program(id:dest);
                    if (!destExists) town.Add(d);
                    p.communications.Add(d);
                }
            }
        }

        var zero = town.Where(o => o.id == 0).Single();
        int count = 0;
        var visited = new List<int>();
        countGroup(zero, ref count, ref visited);

        Console.WriteLine($"number of programs in the group with program id 0: {count}");
    }

    private static void countGroup(Program root, ref int count, ref List<int> visited)
    {
        ++count;
        visited.Add(root.id);

        foreach (var p in root.communications)
        {
            if (visited.Contains(p.id)) continue;
            countGroup(p, ref count, ref visited);
        }
    }
}