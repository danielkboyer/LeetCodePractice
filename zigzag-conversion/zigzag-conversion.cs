public class Solution { 
    public string Convert(string s, int numRows) {
        
        
        //edge case
        if(numRows == 1)
            return s;
        string toReturn = "";
        int start = (numRows*2)-2;
        
        for(int x = 0;x<numRows;x++){
            int processNumber = start-(2*x);
            if(processNumber == 0){
                processNumber = start;
            }
            
            int currentIndex = x;
            while(currentIndex < s.Length){
                toReturn+=s[currentIndex];
                currentIndex+=processNumber;
                processNumber = start-processNumber;
                
                if(processNumber == 0){
                    processNumber = start;
                }
                
                
            }
            
            
        }
        return toReturn;
    }
}