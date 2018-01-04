public class Solution {
    public bool JudgeCircle(string moves) {        
	var upDownCount = 0;
	var leftRightCount = 0;
        for(var i = 0; i < moves.Length; i++) {
            if(moves[i] == 'U') {
                upDownCount++;
            }
            else if (moves[i] == 'D') {
                upDownCount--;
            }
            else if (moves[i] == 'L') {
                leftRightCount++;
            }
            else if (moves[i] == 'R') {
                leftRightCount--;
            }                
        }
        
        if(upDownCount == 0 && leftRightCount == 0)
        {
            return true;
        }
        return false;        
    }
}