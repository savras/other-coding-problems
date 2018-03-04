public class Solution {
    public string ComplexNumberMultiply(string a, string b) {
        var plusIndexA = a.IndexOf("+");
        var plusIndexB = b.IndexOf("+");

        var excludeI = 1;
        
        var lenA = a.Length - 1;        
        var leftOperandA = Int32.Parse(a.Substring(0, plusIndexA));
        var rightOperandA = Int32.Parse(a.Substring(plusIndexA + 1, lenA - plusIndexA - excludeI));
        
        var lenB = b.Length - 1;
        var leftOperandB = Int32.Parse(b.Substring(0, plusIndexB));
        var rightOperandB = Int32.Parse(b.Substring(plusIndexB + 1, lenB - plusIndexB - excludeI));
        
        var leftOperandResult = (leftOperandA * leftOperandB) + 
                                ((rightOperandA * rightOperandB) * -1);
        var rightOperandResult = (leftOperandA * rightOperandB) + 
                                (rightOperandA * leftOperandB);
            
        return $"{leftOperandResult}+{rightOperandResult}i";
    }
}