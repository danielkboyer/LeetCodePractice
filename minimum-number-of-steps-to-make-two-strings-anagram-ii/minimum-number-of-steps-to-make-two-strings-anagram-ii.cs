public class Solution {
    //problem read and code written in 6:08
    public int MinSteps(string s, string t) {
        Dictionary<char,int> sDict = new Dictionary<char,int>();
        Dictionary<char,int> tDict = new Dictionary<char,int>();
        
        for(int x = 0;x<s.Length;x++){
            if(sDict.ContainsKey(s[x])){
                sDict[s[x]]+=1;
                continue;
            }
            sDict.Add(s[x],1);
        }
        
        for(int x = 0;x<t.Length;x++){
            if(tDict.ContainsKey(t[x])){
                tDict[t[x]]+=1;
                continue;
            }
            tDict.Add(t[x],1);
        }
        
        int moves = 0;
        foreach(var key in sDict.Keys){
            int sAmount = sDict[key];
            int tAmount = 0;
            if(tDict.ContainsKey(key)){
                tAmount = tDict[key];
            }
            
            moves += Math.Max(sAmount-tAmount,0);
            
        }
        
        foreach(var key in tDict.Keys){
            int tAmount = tDict[key];
            int sAmount = 0;
            if(sDict.ContainsKey(key)){
                sAmount = sDict[key];
            }
            
            moves += Math.Max(tAmount-sAmount,0);
            
        }
        
        return moves;
        
        
    }
}