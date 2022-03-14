/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        
        Dictionary<int,(TreeNode node, bool isParent)> map = new Dictionary<int,(TreeNode node, bool isParent)>();
        
        
        for(int x = 0;x<descriptions.Length;x++){
            int parent = descriptions[x][0];
            int child = descriptions[x][1];
            bool isLeft = descriptions[x][2] == 1;
            
            TreeNode parentNode = null;
            if(!map.ContainsKey(parent)){
                parentNode = new TreeNode(parent);
                map.Add(parent,(parentNode,true));
            }
            else{
                parentNode = map[parent].node;
            }
            
            TreeNode childNode = null;
            if(!map.ContainsKey(child)){
                childNode = new TreeNode(child);
                map.Add(child,(childNode,false));
            }
            else{
                var returned = map[child];
                returned.isParent = false;
                childNode = returned.node;
                map[child] = returned;
            }
             
            if(isLeft){
                parentNode.left = childNode;
            }
            else{
                parentNode.right = childNode;
            }
            
            
        }
        
        foreach(var key in map.Keys){
            if(map[key].isParent)
                return map[key].node;
        }
        
        return null;
    }
}