public class Solution {
    
    public int Explore(int[,] grid, int i, int j) {
        var areaSoFar = 1;        
        grid[i, j] = 0;
        
        if(j > 0 && grid[i, j - 1] == 1) {
            areaSoFar += Explore(grid, i, j - 1);
        }
        
        if(j < grid.GetLength(1) - 1 && grid[i, j + 1] == 1) {
            areaSoFar += Explore(grid, i, j + 1);
        }
        
        if(i > 0 && grid[i - 1, j] == 1) {
            areaSoFar += Explore(grid, i - 1, j);
        }
        
        if(i < grid.GetLength(0) - 1 && grid[i + 1, j] == 1) {
            areaSoFar += Explore(grid, i + 1, j);
        }        
        
        return areaSoFar;
    }
    
    public int MaxAreaOfIsland(int[,] grid) {
        var maxArea = 0;
        for(var i = 0; i < grid.GetLength(0); i++) {
            for(var j = 0; j < grid.GetLength(1); j++) {
                if(grid[i, j] == 1) {
                    maxArea = Math.Max(maxArea, Explore(grid, i, j));
                }
                
            }
        }
        
        return maxArea;
    }
}