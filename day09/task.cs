using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Day09 {
    public static void task1() {
        string stream;
        using (StreamReader sr = new StreamReader("day09\\input.txt"))
            stream = sr.ReadLine();
        
        bool garbage = false;
        int currentLevel = 0, score = 0;
        
        for (int i = 0; i < stream.Length; i++)
        {
            char c = stream[i];

            switch (c) {
                case '!': i++; break;
                case '>': garbage = false; break;
                case '<': garbage = true; break;
                case '{': if (!garbage) currentLevel++; break;
                case '}': if (!garbage) score += currentLevel--; break;
                case ',': break;
            }
        }
        Console.WriteLine($"score: {score}");
    }

    public static void task2() {
        string stream;
        using (StreamReader sr = new StreamReader("day09\\input.txt"))
            stream = sr.ReadLine();
        
        bool garbage = false;
        int currentLevel = 0, score = 0, garbageCount = 0;
        
        for (int i = 0; i < stream.Length; i++)
        {
            char c = stream[i];
            bool controlChar = false;

            switch (c) 
            {
                case '!': i++; break;
                case '>': controlChar =  garbage; garbage = false; break;
                case '<': controlChar = !garbage; garbage = true; break;
                case '{': if (!garbage) currentLevel++; break;
                case '}': if (!garbage) score += currentLevel--; break;
            }

            if (garbage && !controlChar && c != '!') 
                garbageCount++;
        }
        Console.WriteLine($"# of garbage characters: {garbageCount}");
    }
}