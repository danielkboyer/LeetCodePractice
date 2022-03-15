public class Solution {
    public int MinMovesToMakePalindrome(string s) {
        
        int left = 0;
        int right = s.Length-1;
        
        char[] array = s.ToCharArray();
        int moves = 0;
        while(left < right){
            
            if(array[left] == array[right]){
                left++;
                right--;
                continue;
            }
            
            
            char prev = array[left];
            int r = right-1;
            while(prev != array[r]){
                r--;
               
            }
            
            //case for the middle
            if(r == left){
                Swap(array,left,left+1);
                moves++;
                continue;
            }
            
            
            for(int i = r;i<right;i++){
                Swap(array,i,i+1);
                moves++;
            }
            
            left++;
            right--;
            
            
        }
        
        return moves;
    }
    
    
    public void Swap(char[] array, int l, int r){
        char temp = array[l];
        array[l] = array[r];
        array[r] = temp;
    }
}