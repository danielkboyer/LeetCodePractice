public class Solution {
    public int CountHillValley(int[] nums) {
        int count = 0;
        for (int i = 1; i < nums.Length-1; i++)
        {
            int equalIndex = i+1;
            while(equalIndex < nums.Length && nums[equalIndex] == nums[i]){
                equalIndex +=1;
            }
            
            if(equalIndex >= nums.Length)
                break;
            
            if((nums[i-1] < nums[i] && nums[i] > nums[equalIndex]) || (nums[i-1] > nums[i] && nums[equalIndex] > nums[i])){
                count++;
            }
            
            i = equalIndex-1;
        }

            return count;
    }
}