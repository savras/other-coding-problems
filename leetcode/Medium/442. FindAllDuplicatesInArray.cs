public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        var result = new List<int>();
        for(var i = 0; i < nums.Length; i++) {
            var index = Math.Abs(nums[i]) - 1;
            if(nums[index] < 0) {
                result.Add(Math.Abs(index) + 1);
            }
            else{
                nums[index] *= -1;
            }
        }
        return result;
    }
}