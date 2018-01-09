public class Solution {
    public int IslandPerimeter(int[,] grid) {
        var neighbourCount = 0;
        var islandSquareCount = 0;
        for(var i = 0; i < grid.GetLength(0); i++) {
            for(var j = 0; j < grid.GetLength(1); j++) {
                if(grid[i,j] == 1)
                {
                    islandSquareCount++;
                    if(i > 0 && grid[i - 1, j] == 1)
                    {
                        neighbourCount++;
                    }
                    if(i < grid.GetLength(0) - 1 && grid[i + 1, j] == 1 )
                    {
                        neighbourCount++;
                    }
                    if(j > 0 && grid[i, j - 1] == 1) 
                    {
                        neighbourCount++;
                    }
                    if(j < grid.GetLength(1) - 1 && grid[i, j + 1] == 1)
                    {
                        neighbourCount++;
                    }
                }
            }
        }
        var totalPossiblePerimeter = 4 * islandSquareCount;
        var perimeter = totalPossiblePerimeter - neighbourCount;
        return perimeter;        
    }
}