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
    public TreeNode MergeTrees(TreeNode t1, TreeNode t2) {
        
        if(t1 == null && t2 == null) {
            return null;
        }
        
        var value = 0;
        
        if(t1 != null)
        {
            value += t1.val;
        }
        
        if(t2 != null)
        {
            value += t2.val;
        }
        
        var node = new TreeNode(value);
        node.left = MergeTrees(t1?.left, t2?.left);
        node.right = MergeTrees(t1?.right, t2?.right);
        
        return node;
    }
}