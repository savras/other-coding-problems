public class Solution {
    public int DistributeCandies(int[] candies) {
        var len = candies.Length;        
        var half = len / 2;
        var hs = new HashSet<int>();
        for(var i = 0; i < len; i++) {
            if(!hs.Contains(candies[i])){
                hs.Add(candies[i]);
            }
            if(hs.Count >= half) {
                break;
            }
        }
        
        var result = Math.Min(half, hs.Count);
        
        return result;
    }
}