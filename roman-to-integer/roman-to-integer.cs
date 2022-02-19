public class Solution {
    public int RomanToInt(string s) {
        
        Dictionary<char,int> values = new Dictionary<char,int>();
        
        values.Add('M',1000);
        values.Add('D',500);
        values.Add('C',100);
        values.Add('L',50);
        values.Add('X',10);
        values.Add('V',5);
        values.Add('I',1);
        
        int toReturn = 0;
        for(int x = 0;x<s.Length;x++){
            if(x+1 >= s.Length){
                toReturn += values[s[x]];
                break;
            }
            if(values[s[x]] < values[s[x+1]]){
                toReturn += values[s[x+1]] - values[s[x]];
                x++;
            }
            else{
                toReturn += values[s[x]];
            }
        }
        
        return toReturn;
        
    }
}