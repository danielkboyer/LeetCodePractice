public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int,int> dic = new Dictionary<int,int>();
        for(int x = 0;x<nums.Length;x++){
            int newTarget = target - nums[x];
            if(dic.ContainsKey(newTarget)){
                return new int[] {x,dic[newTarget]};
            }
            
            dic.Add(nums[x],x);
        }
        
        return null;
    }
}