using System;
using System.Collections.Generic;
using System.Linq;

class Day03 {
    static int input = 325489;
    public static void task1() {
        int layer = (int)Math.Ceiling(Math.Sqrt(input)) / 2;
        int sideLength = 2 * layer;

        int x, y;
        int nearestSquare = (int)Math.Ceiling(Math.Sqrt(input));
        int diff = (int)Math.Pow(nearestSquare % 2 == 0 ? nearestSquare + 1 : nearestSquare, 2.0) - input;
        int sideCoord = (diff % sideLength - sideLength/2);
        if (diff < 1 * sideLength) {
            x = -1 * sideCoord;
            y = -1 * layer;
        }
        else if (diff < 2 * sideLength) {
            x = -1 * layer;
            y = sideCoord;
        }
        else if (diff < 3 * sideLength) {
            x = sideCoord;
            y = layer;
        }
        else {
            x = layer;
            y = -1 * sideCoord;
        }

        var manhattan = Math.Abs(x) + Math.Abs(y);

        Console.WriteLine($"manhattan dist: {manhattan}");
    }

    public static void task2() {
        Tuple<int, int> coords(int input) {
            if (input == 1)
                return Tuple.Create<int, int>(0, 0);

            int layer = (int)Math.Ceiling(Math.Sqrt(input)) / 2;
            int sideLength = 2 * layer;

            int x, y;
            int nearestSquare = (int)Math.Ceiling(Math.Sqrt(input));
            int diff = (int)Math.Pow(nearestSquare % 2 == 0 ? nearestSquare + 1 : nearestSquare, 2.0) - input;
            int sideCoord = (diff % sideLength - sideLength/2);
            if (diff < 1 * sideLength) {
                x = -1 * sideCoord;
                y = -1 * layer;
            }
            else if (diff < 2 * sideLength) {
                x = -1 * layer;
                y = sideCoord;
            }
            else if (diff < 3 * sideLength) {
                x = sideCoord;
                y = layer;
            }
            else {
                x = layer;
                y = -1 * sideCoord;
            }

            return Tuple.Create<int, int>(x, y);
        }

        int neighborSum(int x, int y, int[,] g) {
            int sum = 0;
            for (int i = x - 1; i <= x + 1; i++) {
                for (int j = y - 1; j <= y + 1; j++) {
                    if (j < g.GetLength(0) && i < g.GetLength(1)) {
                        sum += g[i,j];
                    }
                }
            }
            return sum;
        }

        int[,] grid = new int[300, 300];
        for (int r = 0; r < grid.GetLength(0); r++)
            for (int c = 0; c < grid.GetLength(1); c++)
                grid[r,c] = 0;
        grid[150,150] = 1;

        int n = 1, nsum = 0;
        while (nsum <= input) {
            Tuple<int, int> c = coords(n);
            int y = c.Item2, x = c.Item1, row, col;
            row = grid.GetLength(0) / 2 + y;
            col = grid.GetLength(1) / 2 + x;
            nsum = neighborSum(row, col, grid);
            grid[row, col] = nsum;
            n++;
        }

        Console.WriteLine(nsum);
    }
}