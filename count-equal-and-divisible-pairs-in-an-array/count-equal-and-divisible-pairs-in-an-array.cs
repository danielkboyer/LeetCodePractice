public class Solution {
    public int CountPairs(int[] nums, int k) {
        int count = 0;
        for(int x = 0;x<nums.Length;x++){
            for(int y = x+1;y<nums.Length;y++){
                if(nums[x] == nums[y] && x*y %k == 0){
                    count++;
                }
            }
        }
        return count;
    }
}