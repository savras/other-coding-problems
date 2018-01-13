public class Solution {
    public int SingleNumber(int[] nums) {
        var result = nums[0];
        for(var i = 1; i < nums.Length; i++) {
            result = result ^ nums[i];
        }
        return result;
    }    
}