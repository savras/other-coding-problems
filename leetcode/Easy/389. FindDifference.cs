public class Solution {
    public char FindTheDifference(string s, string t) {
        var arr = new int[26];
        for(var i = 0; i < t.Length; i++)
        {
            arr[t[i] - 'a']++;
        }
        
        for(var i = 0; i < s.Length; i++)
        {
            arr[s[i] - 'a']--;
        }
        
        
        int result = 0;
        for(var i = 0; i < arr.Length; i++)
        {
            if(arr[i] > 0)
            {
                result = i;
                break;
            }
        }
        
        return (char)(result + (int)'a');
    }
}