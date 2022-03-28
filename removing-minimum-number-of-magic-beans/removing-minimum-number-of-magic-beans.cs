public class Solution {
    public long MinimumRemoval(int[] beans) {
        
        Array.Sort(beans);
        
        long sum = 0;
        for(long x = 0;x<beans.Length;x++){
            sum+=beans[x];
        }
        
        long min = long.MaxValue;
        
        for(long x = 0;x<beans.Length;x++){
            
            min = Math.Min(min,sum - (beans[x]*(beans.Length-x)));
        }
        
        return min;
        
    }
    
    
    
    
    
}