   public class Solution
    {
        public long MinimumWeight(int n, int[][] edges, int src1, int src2, int dest)
        {

            //convert edges into adjacency matrix
            //O(n) time
            List<List<Node>> adjList = new List<List<Node>>();
            List<List<Node>> reversedGraph = new List<List<Node>>();
            for(int x = 0; x < n; x++)
            {
                adjList.Add(new List<Node>());
                reversedGraph.Add(new List<Node>());
            }
            for (int x = 0; x < edges.Length; x++)
            {
                int src = edges[x][0];
                int des = edges[x][1];
                int weight = edges[x][2];

                reversedGraph[des].Add(new Node(src, weight));
                adjList[src].Add(new Node(des, weight));
            }
            //find shortest path from src1 to all
            long[] src1ToAll = shortestPath(src1, n, adjList);
            //find shortest path from src2 to all
            long[] src2ToAll = shortestPath(src2, n, adjList);

            //find shortest path from dest to all on reversed graph
            long[] destToAll = shortestPath(dest, n, reversedGraph);

            long minTotal = long.MaxValue;
            for (int x = 0; x < n; x++)
            {
                if(src1ToAll[x] == long.MaxValue || src2ToAll[x] == long.MaxValue || destToAll[x] == long.MaxValue)
                {
                    continue;
                }

                long total = src1ToAll[x] + src2ToAll[x] + destToAll[x];
                if (total < minTotal)
                    minTotal = total;
            }

            if (minTotal == long.MaxValue)
                return -1;
            return minTotal;
            


        }

        //dikjstra's
        public long[] shortestPath(int src, int n, List<List<Node>> adjList)
        {
            Node[] nodeValues = new Node[n];

            MinHeap<Node> heap = new MinHeap<Node>();

            for (int x = 0; x < nodeValues.Length; x++)
            {
                nodeValues[x] = new Node(x, long.MaxValue);
                heap.Add(nodeValues[x]);
            }

            nodeValues[src].Value = 0;
            heap.DecreaseKey(nodeValues[src], nodeValues[src]);

            while (heap.Count > 0)
            {

                Node smallest = heap.RemoveMin();
                if (smallest.Value == long.MaxValue)
                    break;
                foreach (var node in adjList[smallest.NodeIndex])
                {
                    if (nodeValues[node.NodeIndex].Value > nodeValues[smallest.NodeIndex].Value + node.Value)
                    {
                        nodeValues[node.NodeIndex].Value = nodeValues[smallest.NodeIndex].Value + node.Value;
                        heap.DecreaseKey(nodeValues[node.NodeIndex], nodeValues[node.NodeIndex]);
                    }
                }
            }
            long[] distances = new long[n];
            for(int x = 0; x < n; x++)
            {
                if (x == src)
                    distances[x] = 0;
                else
                    distances[x] = nodeValues[x].Value;
            }

            return distances;

        }


        public class Node : IComparable<Node>
        {
            public int NodeIndex;
            public long Value;

            public Node(int node, long value)
            {
                NodeIndex = node;
                Value = value;
            }
            public int CompareTo(Node other)
            {
                return Value.CompareTo(other.Value);
            }

            public override string ToString()
            {
                return $"Index: {NodeIndex}, Value: {Value}";
            }
        }
    }

    /// <summary>
    /// min heap that includes the decrease key operation that is needed for dijkstras algo
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MinHeap<T> where T : IComparable<T>
    {
        private List<T> array = new List<T>();

        private Dictionary<T, int> map = new Dictionary<T, int>();

        /// <summary>
        /// swaps the two elements and updates the maps with the new indexes
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        private void Swap(int index1, int index2)
        {
            T tmp = array[index1];
            array[index1] = array[index2];
            array[index2] = tmp;

            //update dictionary values
            //values MUST always be present in dictionary
            map[tmp] = index2;
            map[array[index1]] = index1;
        }

        /// <summary>
        /// O(logn)
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            array.Add(element);
            int n = array.Count - 1;
            //add the new element to the map
            map.Add(element, n);
            //we need to bubble this element as far as we can to the top
            while (n > 0 && array[n].CompareTo(array[n / 2]) == -1) //as long as the element above it in the tree is greater than this element we just added
            {
                //perform a swap of the two elements
                Swap(n, n / 2);
                n = n / 2;
            }
        }

        /// <summary>
        /// O(1)
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return array[0];
        }

        public int Count
        {
            get
            {
                return array.Count;
            }
        }

        /// <summary>
        /// O(logn) assumes that the new key is less than the old key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newKey"></param>
        public void DecreaseKey(T key, T newKey)
        {
            if (!map.ContainsKey(key))
                throw new Exception($"No key to decrease for key {key}");
            int index = map[key];
            //remove the key from the map
            map.Remove(key);

            array[index] = newKey;

            map.Add(newKey, index);
            int c = index;
            while (c > 0 && array[c].CompareTo(array[c / 2]) == -1)
            {
                Swap(c, c / 2);
                c = c / 2;
            }


        }
        /// <summary>
        /// O(logn)
        /// </summary>
        /// <returns></returns>
        public T RemoveMin()
        {
            T retrieved = array[0];
            //remove the retrieved element from the map
            map.Remove(retrieved);

            //place the last element in the tree at the top and bubble down
            array[0] = array[array.Count - 1];
            map[array[0]] = 0;
            array.RemoveAt(array.Count - 1);

            int n = 0;

            while (n < array.Count)
            {
                int min = n;
                //the node to the bottom right of the current node
                int botLeft = 2 * n + 1;
                //the node to the bottom left of the current node
                int botRight = 2 * n + 2;
                //if the bot left is less than the current min node then we assign this as the new min node 
                if (botLeft < array.Count && array[botLeft].CompareTo(array[min]) == -1)
                {
                    min = botLeft;
                }
                //if the bot right is less than the current min node then we assign this as the new min node
                if (botRight < array.Count && array[botRight].CompareTo(array[min]) == -1)
                {
                    min = botRight;
                }
                //if the node at top is the smallest than we are finished
                if (min == n)
                    break;

                //perform a swap with the min node and the node above it
                Swap(n, min);
                n = min;
            }

            return retrieved;
        }
    }