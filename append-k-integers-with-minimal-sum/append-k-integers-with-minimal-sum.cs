public class Solution {
    //solved in 12 minutes, i understand that sorting it is not the fastest solution but I care about winning competitions here
    public long MinimalKSum(int[] nums, int k) {
        Array.Sort(nums);
        long sum = 0;
        long currentAdd = 1;
        for(long x = 0;x<nums.Length;x++){
            long high = nums[x];
            while(currentAdd < high){
                sum += currentAdd++;
                k--;
                if(k == 0)
                    break;
            }
            if(k == 0)
                break;
            currentAdd = high+1;
            
        }
        while(k > 0){
            sum+=currentAdd++;
            k--;
        }
        
        return sum;
        
    }
}