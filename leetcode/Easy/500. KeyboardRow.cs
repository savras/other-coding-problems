public class Solution {
    public string[] FindWords(string[] words) {
        var topRow = new HashSet<char> {'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'};
        var midRow = new HashSet<char> {'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'};
        var botRow = new HashSet<char> {'z', 'x', 'c', 'v', 'b', 'n', 'm'};
        
        var wordSize = words.Length;
        var result = new List<string>();
        for(var i = 0; i < wordSize; i++)
        {
            var topRowCount = 0;
            var midRowCount = 0;
            var botRowCount = 0;
            for(var j = 0; j < words[i].Length; j++) {
                if(topRow.Contains(words[i][j])) {
                    topRowCount++;
                }
                if(midRow.Contains(words[i][j])) {
                    midRowCount++;
                }
                if(botRow.Contains(words[i][j])) {
                    botRowCount++;
                }
            }
                   
           if((topRowCount == 0 && midRowCount == 0) ||
             (midRowCount == 0 && botRowCount == 0) ||
             (topRowCount == 0 && botRowCount == 0)) {
               result.Add(words[i]);
           }
        }
                   
       return result.ToArray();
    }
}