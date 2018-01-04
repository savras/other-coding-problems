public class Solution {
    public string ReverseWords(string s) {
        var sb = new StringBuilder();
        var size = s.Length;
        
        StringBuilder word  = new StringBuilder();
        for(var i = size - 1; i >= 0; i--) {
            
            if(s[i] == ' ')
            {
                sb.Insert(0, word.ToString());
                sb.Insert(0, " ");
                word.Clear();
            }            
            else {
                word.Append(s[i]);
            }
        }
        sb.Insert(0, word.ToString());
        
        return sb.ToString();
    }
}