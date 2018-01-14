public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        var result = new List<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0) { continue; }

            var t = nums[i] - 1;
            var temp = nums[nums[i] - 1] - 1;
            while (temp >= 0)
            {
                nums[t] = 0;
                t = temp;
                temp = nums[temp] - 1;

            }
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                result.Add(i + 1);
            }
        }

        return result;
    }
}