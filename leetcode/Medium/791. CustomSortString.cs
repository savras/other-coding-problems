public class Solution {
    public string CustomSortString(string S, string T) {
        var dict = new Dictionary<char, int[]>();    // [0] for order, [1] for count
        for(var i = 0; i < S.Length; i++) {
            dict.Add(S[i], new int[] {i, 0});
        }
        
        var sb = new StringBuilder();
        for(var i = 0; i < T.Length; i++) {
            if(dict.ContainsKey(T[i]))
            {
                dict[T[i]][1]++;
            }
            else {
                sb.Append(T[i]);
            }
        }
        
        var orderedList = dict.OrderBy(d => d.Value[0]);
        foreach(var item in orderedList) {
            for(var i = 0; i < item.Value[1]; i++)
            {
                sb.Append(item.Key);
            }
        }
        return sb.ToString();
    }
}