public class Solution {
    
    int[] min = new int[]{2,1,4,7,4,8,3,6,4,8};
    int[] max = new int[]{2,1,4,7,4,8,3,6,4,7};
    
    public int Reverse(int x) {
         bool isNegative = false;
            if (x < 0)
            {
                isNegative = true;
                x = x * -1;
            }
            string xString = x.ToString();
            if (xString.Length > 10)
                return 0;

            string toReturn = "";
            if (xString.Length == 10)
            {

                (bool outBounds, bool equals) outOfBounds = (false,true);
                for (int i = xString.Length - 1; i >= 0; i--)
                {
                    string sub = xString.Substring(i, 1);
                    toReturn += sub;


                    if (outOfBounds.equals)
                    {
                        outOfBounds = OutOfBounds(int.Parse(sub), toReturn.Length - 1, isNegative);
                    }
                    if (outOfBounds.outBounds)
                        return 0;


                }
            }
            else
            {
                for (int i = xString.Length - 1; i >= 0; i--)
                {
                    toReturn += xString.Substring(i, 1);
                }
            }

            int newInt = int.Parse(toReturn);
            if (isNegative)
                return newInt * -1;
            return newInt;
    }
    
    //returns true if x is equal to or greater than max or min
        public (bool outBounds, bool equal) OutOfBounds(int x, int pos, bool negative)
        {
            //10 in length
            //2147483647
            //-2147483648

            if (negative)
            {

                return (x > min[pos], x == min[pos]);
            }

            return (x > max[pos], x == max[pos]);
        }
}