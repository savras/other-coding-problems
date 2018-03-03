/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

// This solution is based on:
//https://leetcode.com/problems/maximum-binary-tree/discuss/106147/c-9-lines-on-log-n-map-plus-stack-with-binary-search
// https://leetcode.com/problems/maximum-binary-tree/discuss/106146/c-on-solution?page=1

public class Solution {
    public TreeNode ConstructMaximumBinaryTree(int[] nums) {
        var stack = new List<TreeNode>();
        for(var i = 0; i < nums.Length; i++) {
            var node = new TreeNode(nums[i]);
            if(!stack.Any())
            {
                stack.Add(node);
            }
            else {
                if(node.val < stack.Last().val)
                {
                    stack.Last().right = node;
                    stack.Add(node);
                }
                else {
                    // Current node is larger than last item in the stack
                    while(stack.Any() && node.val > stack.Last().val) {
                        node.left = stack.Last();
                        stack.RemoveAt(stack.Count - 1);
                    }
                    
                    if(stack.Any()){
                        stack.Last().right = node;
                    }     
                    
                    stack.Add(node);
                }
            }
        }
        return stack[0];
    }
}