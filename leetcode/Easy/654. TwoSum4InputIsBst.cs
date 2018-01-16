/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
// Assume unique integers.
public class Solution {
    public bool FindTarget(TreeNode root, int k) {        
        var hs = new HashSet<ulong>();
        return Find(root, k, hs);
    }
    
    public bool Find(TreeNode root, int k, HashSet<ulong> hs) {
        if(root == null)
        {
             return false;
        }
        
        if(hs.Contains((ulong)(k - root.val))){
            return true;
        }
        hs.Add((ulong)root.val);
        
        return Find(root.left, k, hs) || Find(root.right, k, hs);
    }    
}