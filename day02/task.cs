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

    public static void task2() {
        List<List<int>> sheet = new List<List<int>>();

        using (var reader = new StreamReader("day02\\input.txt")) {
            while (!reader.EndOfStream) {
                var cells = reader.ReadLine().Split('\t');
                var row = cells.Select(c => Int32.Parse(c)).ToList();
                sheet.Add(row);
            }
        }

        int sum = 0;
        foreach (var row in sheet) {
            Console.WriteLine(row);
            for (int i = 0; i < row.Count; i++) {
                for (int j = 0; j < row.Count; j++) {
                    if (i == j)
                        continue;

                    if (row[i] % row[j] == 0)
                        sum += (row[i] / row[j]);
                }
            }
        }

        Console.WriteLine($"sum: {sum}");
    }
}