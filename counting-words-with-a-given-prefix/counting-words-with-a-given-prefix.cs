public class Solution {
    public int PrefixCount(string[] words, string pref) {
        
        int count = 0;
        
        for(int x = 0;x<words.Length;x++){
            string word = words[x];
            if(word.Length >= pref.Length){
                bool prefix = true;
                for(int y = 0;y<pref.Length;y++){

                    if(word[y] != pref[y]){
                        prefix = false;
                        break;
                    }
                }
                if(prefix)
                    count++;
            }
         
        }
        
        return count;
    }
}