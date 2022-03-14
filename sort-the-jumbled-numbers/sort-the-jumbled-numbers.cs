public class Solution {
    public int[] SortJumbled(int[] mapping, int[] nums) {
        Node[] final = new Node[nums.Length];
        
        
        for(int y = 0;y<nums.Length;y++){
            string n = nums[y].ToString();
            Node node = new Node();
            node.value = 0;
            node.index = y;
            for(int x = 0;x<n.Length;x++){
                node.value += mapping[int.Parse(n.Substring(x,1))] * (int)Math.Pow(10,n.Length-x-1);
            }
            final[y] = node;
            
        }
        
        Array.Sort(final);
        
        int[] toReturn = new int[nums.Length];
        
        for(int x = 0;x<final.Length;x++){
            toReturn[x] = nums[final[x].index];
        }
        
        return toReturn;
        
    }
    
    
    public class Node:IComparable<Node>
    {
        public int value;
        public int index;
        
        
        public int CompareTo(Node node){
            if(value < node.value)
                return -1;
            if(value > node.value)
                return 1;
            if(index < node.index)
                return -1;
            if(index > node.index)
                return 1;
            return 0;
        }
    }
}