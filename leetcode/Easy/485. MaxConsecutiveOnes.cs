public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        var current = 0;
        var max = 0;
        for(var i = 0; i < nums.Length; i++) {
            if(nums[i] == 0) {
                current = 0;
            }
            else {
                current++;
            }
            max = Math.Max(current, max);
        }
        
        return max;
    }
}