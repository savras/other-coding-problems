public class Solution {
    public int CalPoints(string[] ops) {
        var sum = 0;
        var roundPoints = new Stack<int>(new List<int>{0, 0});   // Initialize previous two scores
        for(var i = 0; i < ops.Length; i++) {
            switch(ops[i]){
                case "+": {
                    var previousScore = roundPoints.Pop();
                    var curScore = previousScore + roundPoints.Peek();
                    roundPoints.Push(previousScore);
                    roundPoints.Push(curScore);
                    sum += curScore;
                    break;
                }
                case "D": {
                    var curScore = roundPoints.Peek();
                    curScore *= 2;
                    sum += curScore;
                    roundPoints.Push(curScore);
                    break;
                }
                case "C": {                    
                    var val = roundPoints.Pop();                    
                    sum -= val;
                    break;
                }
                default:{
                    var val = int.Parse(ops[i]);
                    roundPoints.Push(val);
                    sum += val;
                    break;
                }
            }
        }
        
        return sum;
    }
}