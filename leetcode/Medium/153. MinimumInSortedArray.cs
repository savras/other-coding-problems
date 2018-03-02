public class Solution {
    public int FindMin(int[] nums) {
        var len = nums.Length - 1;
        var left = 0;
        var right = len;
        
        while(left < right) {
            var mid = left + (right - left)/2;
            
            if(nums[mid] > nums[right]) {
               left = mid + 1;
            }
            else {
                right = mid;
            }
        }
        return nums[left];
    }
}