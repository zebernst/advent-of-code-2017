using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Day02 {
    public static void task1() {
        List<List<int>> sheet = new List<List<int>>();

        using (var reader = new StreamReader("day02\\input.txt")) {
            while (!reader.EndOfStream) {
                var cells = reader.ReadLine().Split('\t');
                var row = cells.Select(c => Int32.Parse(c)).ToList();
                sheet.Add(row);
            }
        }

        var cksum = sheet.Select(r => r.Max() - r.Min()).Sum();
        Console.WriteLine($"checksum: {cksum}");
    }
}