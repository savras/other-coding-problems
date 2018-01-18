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
    
    public int ConvertBSTInOrder(TreeNode root, int val) {
        if(root == null){
            return 0;
        }
        
        var rightVal = ConvertBSTInOrder(root.right, val);
        root.val += rightVal + val;
        var leftVal = ConvertBSTInOrder(root.left, root.val);
       
        return root.val + leftVal - val;
    }
    
    public TreeNode ConvertBST(TreeNode root) {
        ConvertBSTInOrder(root, 0);
        return root;
    }
}