public class Solution {
    public IList<IList<int>> GetAncestors(int n, int[][] edges) {
        
        
        Node[] nodes = new Node[n];
        for(int x = 0;x<n;x++){
            nodes[x] = new Node(x);
        }
        List<List<int>> edgesInArray = new List<List<int>>();
        for(int x = 0;x<n;x++){
            edgesInArray.Add(new List<int>());
        }
        foreach(var edge in edges){
            nodes[edge[1]].inDegree++;
            edgesInArray[edge[0]].Add(edge[1]);
        }
        
        Queue<Node> queue = new Queue<Node>();
        //add start nodes
        foreach(var node in nodes.Where(t=>t.inDegree == 0)){
            queue.Enqueue(node);
        }
        
        while(queue.Count > 0){
            
            var node = queue.Dequeue();
            
            for(int x = 0;x<edgesInArray[node.index].Count;x++){
                var queueNode = nodes[edgesInArray[node.index][x]];
                queueNode.inDegree --;
                queueNode.ancestors.Add(node);
                foreach(var ancestor in node.ancestors){
                queueNode.ancestors.Add(ancestor);
                }
                if(queueNode.inDegree == 0){
                    queue.Enqueue(queueNode);
                }
            }
            
        }
        
        IList<IList<int>> toReturn = new List<IList<int>>();
        
        for(int x = 0;x<nodes.Length;x++){
            toReturn.Add(new List<int>());
            var sorted = nodes[x].ancestors.ToList();
            sorted.Sort();
            toReturn[x] = sorted.Select(t=>t.index).ToList();
        }
        
        return toReturn;
    }
    
    public class Node:IComparable<Node>{

        public int index;
        public int inDegree;
        public HashSet<Node> ancestors = new HashSet<Node>();
        public Node(int index){
            
            this.index = index;
        }
        
        public int CompareTo(Node node){
            return index.CompareTo(node.index);
        }
    }
}