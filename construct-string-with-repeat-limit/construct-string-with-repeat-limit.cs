public class Solution {
    public string RepeatLimitedString(string s, int repeatLimit) {
        
        char[] array = s.ToCharArray();
        
        array = array.OrderByDescending(c => c).ToArray();
        
        //return new string(array);
        // a,a,b,a,a,b,a,a,b,a,a,b,a,a,b,a,a,a,a,a,....
        //a,a,b,a,a,b,a
        //b,b,b,b,b,b,b,a,a,a,a,a
        //
        //"zzcccca"
        //index = 2
        //amount = 4
        //placeindex = 7
        //x = 5
        //grabindex = 7
        //y == 4
        int index = 0;
        int last = -1;
        while(index < array.Length){
            
            int x = index;
            while(x +1 < array.Length && array[x] == array[x+1]){
                x++;
            }
            //at this point we now that index through x are the same letter
            int amount = (x - index)+1;
            //if less than repeat
            if(amount <= repeatLimit)
            {
                index = x+1;
                continue;
            }
            var broke = false;
            int placeIndex = index+repeatLimit;
            int grabIndex = x+1;
            for(int y = placeIndex;y<=grabIndex;y+= repeatLimit+1){
                if(grabIndex >= array.Length){
                    last = y;
                    broke = true;
                    Console.WriteLine("Broke");
                    break;
                }
                var temp = array[y];
                array[y] = array[grabIndex];
                array[grabIndex] = temp;
                grabIndex++;
            }
            
            if(broke)
                break;
            index = x;
            
            
        }
        
        //we need to remove any repeating characters after index
        if(last != -1){
            char[] newArray = new char[last];
            for(int x = 0;x<last;x++){
                newArray[x] = array[x];
            }
            
            return new string(newArray);
        }
        
        return  new string(array);
        
    }
}