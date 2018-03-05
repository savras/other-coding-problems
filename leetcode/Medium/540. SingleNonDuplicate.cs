public class Solution {
    public int SingleNonDuplicate(int[] nums) {        
        var left = 0;
        var right = nums.Length - 1;
        
        while(left < right) {
            var mid = left + (right - left)/2;
            if(mid % 2 == 0)
            {
                if(nums[mid - 1] == nums[mid])
                {
                    right = mid;
                }
                else 
                {
                    left = mid;
                }
            }            
            else{
                if(nums[mid - 1] == nums[mid]) {
                    left = mid + 1;
                }
                else {
                    right = mid - 1;
                }
            }
        }
        
        return nums[left];
    }
}