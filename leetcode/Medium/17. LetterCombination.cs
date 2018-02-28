public class Solution {
    public IList<string> LetterCombinations(string digits) {
    
        if(digits.Length == 0) {
            return new List<string>();
        }
        
        var result = new List<string>();
        GetLetterCombination(digits, result, 0, new StringBuilder());
        return result;
    }
    
    public void GetLetterCombination(string digits, List<string> result, int index, StringBuilder runningCombination)
    {
        if(index >= digits.Length) { 
            result.Add(runningCombination.ToString());
            return; 
        }
        
        var letters = GetLettersForDigit(digits[index]);
        
        for(var i = 0; i < letters.Length; i++)
        {
            runningCombination.Append(letters[i]);
            GetLetterCombination(digits, result, index + 1, runningCombination);
            runningCombination.Remove(runningCombination.Length - 1, 1);
        }
    }
    
    public string GetLettersForDigit(char digit) {
        switch(digit)
        {
            case '2': {
                return "abc";
                break;
            }
            case '3': {
                return "def";
                break;
            }
            case '4': {                
                return "ghi";
                break;
            }
            case '5': {                
                return "jkl";
                break;
            }
            case '6': {                
                return "mno";
                break;
            }
            case '7': {                
                return "pqrs";
                break;
            }
            case '8': {                
                return "tuv";
                break;
            }
            case '9': {                
                return "wxyz";
                break;
            }
            default: {
                return string.Empty;
                break;
            }
        }
    }
}