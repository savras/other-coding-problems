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
    public IList<int> LargestValues(TreeNode root) {
        var result = new List<int>();
        if(root == null) { return result; }
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        queue.Enqueue(null);    // Use null to mark the end of all nodes in a level.
        
        var level = 0;
        while(queue.Count > 0){
            var node = queue.Peek();
            queue.Dequeue();
            
            // If we have added all nodes from the same level
            if(node == null) {
                if(queue.Count > 0)
                {
                    queue.Enqueue(null);
                }
                
                level++;
            }
            else {
                // Track greatest value in each row in result.
                if(result.Count <= level) {
                    result.Add(node.val);
                }
                else if(result[level] < node.val) {
                    result[level] = node.val;
                }
                
                // Fill queue with next level nodes.
                if(node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if(node.right != null) {
                    queue.Enqueue(node.right);
                }   
            }
        }
        return result;
    }
}