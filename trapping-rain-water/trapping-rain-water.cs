public class Solution {
    public int Trap(int[] height)
        {

            int total = 0;
            List<int> currentList = new List<int>();
            int currentSum = 0;
            int highest;
            if(height == null || height.Length == 0){
                return 0;
            }
            highest = height[0];
            for (int i = 1; i < height.Length; i++)
            {

                if (height[i] >= highest)
                {
                    total += currentSum;
                    currentList = new List<int>();
                    currentSum = 0;
                    highest = height[i];
                    continue;
                }

                //height is less than height
                currentList.Add(highest - height[i]);
                currentSum += highest - height[i];

                if (currentList.Count <= 1)
                {
                    continue;
                }

                if (currentList[currentList.Count - 2] > currentList[currentList.Count-1])
                {
                    int toCompare = currentList[currentList.Count - 1];

                    currentSum -= currentList[currentList.Count - 2] - toCompare;
                    total += currentList[currentList.Count - 2] - toCompare;
                    currentList[currentList.Count - 2] = toCompare;


                    for (int p = currentList.Count - 3; p >= 0; p--)
                    {
                        int difference = currentList[p] - toCompare;
                        if (difference <= 0)
                        {
                            break;
                        }
                        currentSum -= difference;
                        total += difference;
                        currentList[p] = toCompare;
                    }
                }


            }

            return total;
        }
}