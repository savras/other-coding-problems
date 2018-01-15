public class Solution {
    public void MoveZeroes(int[] nums) {
        var earliestZeroPos = -1;
        for(var i = 0; i < nums.Length; i++) {
            if(nums[i] == 0 && earliestZeroPos == -1) {
                earliestZeroPos = i;
            }
            else if (nums[i] != 0 && earliestZeroPos != -1)
            {
                nums[earliestZeroPos] = nums[i];
                earliestZeroPos++;
                nums[i] = 0;
            }            
        }        
    }
}