public class Solution {
    public int HammingDistance(int x, int y) {
        var xor = x ^ y;
        var result = 0;       
            
        
        while(xor > 0) {
            if((xor & 1) > 0 )
            {
                result++;
            }
            xor = xor >> 1;
        }
        
        return result;
    }
}