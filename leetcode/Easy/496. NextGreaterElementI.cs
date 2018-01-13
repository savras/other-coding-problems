public class Solution {
    public int[] NextGreaterElement(int[] findNums, int[] nums) {
        var result = new Dictionary<int,int>();
        var found = new HashSet<int>();
        for(var i = 0; i < nums.Length; i++) {
            for(var j = 0; j < findNums.Length; j++) {
                if(findNums[j] == nums[i])
                {
                    found.Add(findNums[j]);
                    continue;
                }
                
                if(found.Contains(findNums[j]) && nums[i] > findNums[j] && !result.ContainsKey(findNums[j])){
                    result.Add(findNums[j], nums[i]);
                }
            }            
        }
        var arr = new List<int>();
        for(var i = 0; i < findNums.Length; i++) {
            
            if(result.ContainsKey(findNums[i]))
            {
                arr.Add(result[findNums[i]]);
            }
            else {
                arr.Add(-1);
            }            
        }
        
        return arr.ToArray();
    }
}