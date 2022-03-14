public class Solution {
    public int MostFrequent(int[] nums, int key) {
        int target = 0;
        int max = 0;
        Dictionary<int,int> map = new Dictionary<int,int>();
        
        for(int x = 0;x<nums.Length;x++){
            if(nums[x] == key){
                if(x+1 < nums.Length){
                    int t = nums[x+1];
                    if(map.ContainsKey(t)){
                        map[t]+=1;
                        int amount = map[t];

                        if(amount > max){
                            target = t;
                            max = amount;
                        }
                    }
                    else{

                        map.Add(t,1);
                        if(1 > max){
                            target = t;
                            max = 1;
                        }
                    }
                }
            }
        }
        
        return target;
    }
}