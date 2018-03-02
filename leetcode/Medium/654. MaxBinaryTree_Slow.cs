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
    
    public int GetMaxValueIndex(int[] nums, int left, int right) {
        var maxSoFar = -1;
        var maxIndex = left;
        for(var i = left; i <= right; i++) {
            if(maxSoFar < nums[i]){
                maxSoFar = nums[i];
                maxIndex = i;
            }
        }
        
        return maxIndex;
    }
    
    public TreeNode CreateNode(int left, int right, int[] nums)
    {
        if(left > right) { return null; }
        
        
        var mid = GetMaxValueIndex(nums, left, right);
        var parent = new TreeNode(nums[mid]);
        parent.left = CreateNode(left, mid - 1, nums);
        parent.right = CreateNode(mid + 1, right, nums);
        
        return parent;
    }
    
    public TreeNode ConstructMaximumBinaryTree(int[] nums) {
        var len = nums.Length;
        var left = 0;
        var right = len  - 1;
        
        return CreateNode(0, right, nums);
    }
}