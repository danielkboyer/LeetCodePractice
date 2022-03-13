public class Solution {
    //Let's solve this with Dynamic Programming
    //First find SubProblem
    //
    public int MaximumTop(int[] nums, int k) {
        
        if(k == 0)
            return nums[0];
        if(k % 2 == 1 && nums.Length == 1)
            return -1;
        if(k %2 ==  0 && nums.Length == 1)
            return nums[0];
        if(nums.Length == 2){
            if(k == 1)
                return nums[1];
            else if(k == 2)
                return nums[0];
            else
                return Math.Max(nums[0] , nums[1]);
        }
        
        if(k == 1)
            return nums[1];
        if(k == 2)
            return Math.Max(nums[0],nums[2]);
        
        
        
        int max = -1;
        //at this point k >= 3 and nums.Length >= 3
        for(int x = 0;x<= k && x<nums.Length;x++){
            if(nums[x] > max && x != k-1)
                max = nums[x];
        }
        
        return max;
    }
}