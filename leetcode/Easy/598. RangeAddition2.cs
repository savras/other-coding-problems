public class Solution {
    public int MaxCount(int m, int n, int[,] ops) {
        var x = m;
        var y = n;
        for(var i = 0; i < ops.GetLength(0); i++) {
            x = Math.Min(ops[i, 0], x);
            y = Math.Min(ops[i, 1], y);
        }
        
        return x * y;
    }
}