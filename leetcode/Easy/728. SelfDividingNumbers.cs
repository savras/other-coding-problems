public class Solution {
    public IList<int> SelfDividingNumbers(int left, int right) {
        var result = new List<int>();
        for(var i = left; i <= right; i++) {
            var add = true;
            var number = i;            
            while(number > 0) {
                var remainder = number % 10;
                
                if(remainder == 0 || i % remainder != 0)
                {
                    add = false;
                    break;
                }
                number = number / 10;
            }
            
            if(add){
                result.Add(i);
            }
        }
        return result;
    }
}