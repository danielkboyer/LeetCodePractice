public class Solution {
    public IList<string> CellsInRange(string s) {
        
        int subtract = (int)'A';
        char col1 = char.Parse(s.Substring(0,1));
        int row1 = int.Parse(s.Substring(1,1));
        char col2 = char.Parse(s.Substring(3,1));
        int row2 = int.Parse(s.Substring(4,1));
        
        List<string> cells = new List<string>();
        
        char currentLetter = col1;
        while(true){
            
            for(int x = row1;x<= row2;x++){
                cells.Add(currentLetter+""+x);   
            }
            
            if(currentLetter == col2)
                break;
            currentLetter +=(char)1;
        }
        
        return cells;
        
        
    }
}