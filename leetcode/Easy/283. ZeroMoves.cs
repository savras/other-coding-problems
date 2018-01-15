public class Solution {
    public void MoveZeroes(int[] nums) {
        var earliestZeroPos = 0;
        for(var i = 0; i < nums.Length; i++) {
            if(nums[i] == 0) {
                continue;
            }
            else if (nums[i] != 0 && i > earliestZeroPos)
            {
                nums[earliestZeroPos] = nums[i];
                nums[i] = 0;
            }
			earliestZeroPos++;		
        }        
    }
}