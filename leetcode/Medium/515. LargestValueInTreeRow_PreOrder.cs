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
    public void PreOrder(TreeNode node, List<int> result, int level) {
        if(node == null) { return; }        
        
        if(result.Count <= level) {
            result.Add(node.val);
        }
        else{
            if(node.val > result[level])
            {
                result[level] = node.val;
            }
        }
        
        PreOrder(node.left, result, level + 1);
        PreOrder(node.right, result, level + 1);
    }
    
    public IList<int> LargestValues(TreeNode root) {
        var result = new List<int>();
        
        PreOrder(root, result, 0);
        
        return result;
    }
}