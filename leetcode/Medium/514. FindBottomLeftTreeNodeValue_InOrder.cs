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
    // InOrder, track largest level, and first ever encountered value
    public void InOrder(TreeNode root, int currentLevel, ref int maxLevel, ref int result) 
    {
        if(root == null) { return; }
        
        InOrder(root.left, currentLevel + 1, ref maxLevel, ref result);
        if(currentLevel > maxLevel)
        {
            maxLevel = currentLevel;
            result = root.val;
        }
        InOrder(root.right, currentLevel + 1, ref maxLevel, ref result);
    }
    
    public int FindBottomLeftValue(TreeNode root) {
        var maxLevel = 0;
        var result = root.val;
        InOrder(root, 0, ref maxLevel, ref result);
        return result;
    }
}