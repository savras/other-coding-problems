public class Solution {
    public int[] ConstructRectangle(int area) {
        var factor = (int)Math.Sqrt(area);
        
        var remainder = area % factor;
        while(remainder!= 0){
            factor--;
            remainder = area % factor;            
        }
        var factor2 = area / factor;
        
        
        return new[] {factor2, factor};
    }
}