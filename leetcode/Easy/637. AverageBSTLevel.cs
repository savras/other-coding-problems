/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<double> AverageOfLevels(TreeNode root) {
        var values = new Dictionary<int, double>();
        var levelCount = new Dictionary<int, int>();
        
        PopulateLevels(root, values, levelCount, 0);
        
        var result = new List<double>();
        for(var i = 0; i < values.Count; i++) {
            result.Add(values[i]/(double)levelCount[i]);
        }
        return result.ToArray();
    }
    
    public void PopulateLevels(TreeNode root, Dictionary<int, double> values, Dictionary<int, int> levelCount, int level)
    {
        if(root == null) {
            return;
        }
        
        if(values.ContainsKey(level)) {
            values[level] += root.val;
            levelCount[level]++;
        }
        else {
            values.Add(level, root.val);
            levelCount.Add(level, 1);
        }
        PopulateLevels(root.left, values, levelCount, level + 1);
        PopulateLevels(root.right, values, levelCount,  level + 1);
    }
}