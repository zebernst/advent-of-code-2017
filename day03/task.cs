using System;

class Day03 {
    static int input = 325489;
    public static void task1() {
        Console.WriteLine(input);
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
}