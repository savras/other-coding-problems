using System.Runtime.InteropServices;

namespace q10
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new[,]
            {
                {0, 1, 1, 0},
                {1, 1, 1, 1},
                {0, 0, 1, 0},
                {0, 0, 1, 1}
            };

            var startX = 3; 
            var startY = 2;
            var newColour = 2;
            ColourFill(map, startX, startY, newColour, map[startX, startY]);
        }

        private static void ColourFill(int[,] map, int x, int y, int newColour, int oldColour)
        {
            // Out of bounds
            if (x < 0 || x >= map.GetLength(0) || y < 0 || y >= map.GetLength(1)) { return; }
            // Not the colour we want to update.
            if (map[x, y] != oldColour) { return; }

            if (map[x, y] == oldColour)
            {
                map[x, y] = newColour;
            }
            
            ColourFill(map, x - 1, y, newColour, oldColour);
            ColourFill(map, x, y + 1, newColour, oldColour);
            ColourFill(map, x + 1, y, newColour, oldColour);
            ColourFill(map, x, y - 1, newColour, oldColour);
        }
    }
}
