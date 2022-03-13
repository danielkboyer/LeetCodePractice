public class Solution {
    public IList<int> FindKDistantIndices(int[] nums, int key, int k) {
        
        List<int> toReturn = new List<int>();
        int highestIndex = -1;
        for(int x = 0;x<nums.Length;x++){
            if(nums[x] == key)
            {
                int startIndex = x-k;
                if(startIndex <= highestIndex)
                    startIndex = highestIndex+1;
                for(int y = startIndex;y<=x+k &&  y< nums.Length;y++){
                    if(y < 0)
                        continue;
                    toReturn.Add(y);
                    highestIndex = y;
                }
            }
        }
        
        return toReturn;
        
        
        
    }
}