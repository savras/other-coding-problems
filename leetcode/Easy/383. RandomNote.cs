public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        var result = true;
        var arr = new int[26];
        for(var i = 0; i < magazine.Length; i++) {
            arr[magazine[i] - 'a']++;
        }
        
        for(var i = 0; i < ransomNote.Length; i++) {
            arr[ransomNote[i] - 'a']--;
            if(arr[ransomNote[i] - 'a'] < 0){
                result = false;
                break;
            }
        }
        return result;
    }
}