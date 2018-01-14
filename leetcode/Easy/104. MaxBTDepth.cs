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
    public int GetMaxDepth(TreeNode root) {
        if(root == null) {
            return 0;
        }
        
        return Math.Max(GetMaxDepth(root.left),  GetMaxDepth(root.right)) + 1;        
    }
    public int MaxDepth(TreeNode root) {
        return GetMaxDepth(root);            
    }
}