public class Solution {
    
    
    public IList<long> MaximumEvenSplit(long finalSum) {
        
        if(finalSum%2 == 1)
            return new long[0];
        
        long sum = 0;
        
        List<long> solution = new List<long>();
        
        for(int i = 2;i<=finalSum;i+=2){
            if(sum + i <= finalSum){
                solution.Add(i);
                sum+=i;
            }
            else{
                solution[solution.Count-1] += (finalSum-sum);
                break;
            }
        }
        return solution;
    }
}