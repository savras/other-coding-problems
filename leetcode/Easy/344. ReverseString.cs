public class Solution {
    public string ReverseString(string s) {
        var stack = new Stack<char>();
        for(var i = 0; i < s.Length; i++){
            stack.Push(s[i]);
        }
        
        var sb = new StringBuilder();
        while(stack.Count > 0) {
            sb.Append(stack.Pop());
        }
        
        return sb.ToString();
    } 
}