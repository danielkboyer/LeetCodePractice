public class Solution {
    public int MaxArea(int[] height) {
        
        int water = 0;
        int i = height.Length-1;
        int j = 0;
      
        while (j < i){
            water = Math.Max(water,(i-j) * Math.Min(height[i],height[j]));
            
            if(height[i] > height[j]){
                j++;
            }
            else{
                i--;
            }
        }
        
        return water;
    }
}