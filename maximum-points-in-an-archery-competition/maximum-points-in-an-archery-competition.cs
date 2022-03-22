public class Solution {
    // A section is in the solution
    // A section is not in the solution
    public int[] MaximumBobPoints(int numArrows, int[] aliceArrows) {
        
        int[,] dpA = new int[12,numArrows+1];
        //Initialize to -1
        for(int x = 0;x<12;x++){
            for(int y = 0;y<numArrows+1;y++){
               dpA[x,y] = -1;
            }
        }
        
        
        //back track
        int[] solution = new int[12];
        int currentArrows = numArrows;
        for(int x = 1;x<12;x++){
            
            if(dp(x,currentArrows,dpA,aliceArrows) != dp(x+1,currentArrows,dpA,aliceArrows)){
                currentArrows -= aliceArrows[x] + 1;
                solution[x] = aliceArrows[x] +1;
                
            }
        }
        
        if(currentArrows > 0){
            solution[0] = currentArrows;
        }
        return solution;
        
    }
    
    
    public int dp(int k, int numArrows, int[,] dpA, int[] aliceArrows){
        
        if(k == 12 || numArrows == 0)
            return 0;
        
        if(dpA[k,numArrows] != -1) return dpA[k,numArrows];
        
        int max = dp(k+1,numArrows,dpA,aliceArrows);
        if(numArrows > aliceArrows[k]){
            max = Math.Max(max,k+ dp(k+1,numArrows - (aliceArrows[k]+1),dpA,aliceArrows));
        }
        
        
        return dpA[k,numArrows] = max;
    }
}