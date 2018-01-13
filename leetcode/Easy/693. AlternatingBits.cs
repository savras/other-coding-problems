public class Solution {
    public bool HasAlternatingBits(int n) {
        
        var bitCounter = n & 1;
        
        while(n > 0) {
            n = n >> 1;
            var bit = n & 1;
            
            if((bitCounter ^ bit) == 0)
            {
                return false;
            }
            bitCounter = bit;
        }
        
        return true;
        
    }
}