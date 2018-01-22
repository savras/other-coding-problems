public class Solution {
    public int TitleToNumber(string s) {
        var len = s.Length;
        var sum = 0;
        for(var i = 0; i < len - 1; i++) {
            var charValue = s[i] - 'A' + 1;
            var power = len - i - 1;
            sum += (int)Math.Pow(26, power) * charValue;        
        }
        sum += s[len - 1] - 'A' + 1;
        
        return sum;
    }
}