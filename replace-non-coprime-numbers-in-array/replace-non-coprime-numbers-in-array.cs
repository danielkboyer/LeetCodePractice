public class Solution {
    public IList<int> ReplaceNonCoprimes(int[] nums)
        {

            LinkedList<int> toReturn = new LinkedList<int>();

            foreach(int a in nums)
            {
                int b = a;
                while (true)
                {
                    int last = toReturn.Count == 0 ? 1 : toReturn.Last.Value;

                    int x = gcf(last, b);
                    if (x == 1) break;
                    toReturn.RemoveLast();
                    b *=  last / x;
                }
                toReturn.AddLast(b);
            }

            return toReturn.ToList();
        }


        static int gcf(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
}