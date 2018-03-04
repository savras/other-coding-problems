public class Solution {
    public int[] CountBits(int num) {
        if(num == 0) { return new[] {0}; }
        var len = num + 1;
        var arr = new int[len];
        arr[0] = 0;        
        arr[1] = 1;
        
        var power = 0;  // Start from 2^0;
        var counter = 0;
        var currentPowerValue = 1 << power;
        var nextPowerValue = 1 << power + 1;
        for(var i = 2; i < len; i++) {            
            if(i == nextPowerValue)   // Multiples of 2^n
            {           
                arr[i] = 1;
                counter = 0;
                power++;
                currentPowerValue = 1 << power;
                nextPowerValue = 1 << power + 1;
            }
            else {
                arr[i] = arr[currentPowerValue] + arr[counter];
            }
            counter++;
        }
        
        return arr;
    }
}