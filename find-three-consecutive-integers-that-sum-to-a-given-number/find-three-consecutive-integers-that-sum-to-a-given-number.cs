public class Solution {
    public long[] SumOfThree(long num) {
        if(num == 0)
            return new long[]{-1,0,1};
        if(num%3 != 0)
            return new long[0];
        
        long number = num/3;
         
        return new long[]{number-1,number,number+1};
    }
}