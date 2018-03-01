public class Solution {
    public int MaximumProduct(int[] nums) {
        Array.Sort(nums);
        var len = nums.Length - 1;
        return Math.Max(nums[0] * nums[1] * nums[len], nums[len] * nums[len - 1] * nums[len - 2]);
    }
}