public class Solution {
    public int CountCollisions(string directions) {
        //RLRSLL
        char[] array = directions.ToCharArray();
        int count = 0;
        bool sToLeft = false;
        int i = 0;
        
        while(i < array.Length){
            if(array[i] == 'L'){
                 if(sToLeft){
                     count++;
                 }
                i++;
            }
            else if(array[i] == 'R'){
                int rCount = 0;
                int x = i+1;
                while(x < array.Length && (array[x] == 'R')){
                    x++;
                    rCount++;
                }
                if(x == array.Length){
                    break;
                }
                
                if(array[x] == 'L'){
                    count+=2 + rCount;
                    
                    i = x+1;
                }
                else if(array[x] == 'S'){
                    i = x+1;
                    count+= 1 + rCount;
                }
                
                sToLeft = true;
                
                
            }
            else{
                sToLeft = true;
                i++;
            }
            
        }
        
        return count;
    }
}