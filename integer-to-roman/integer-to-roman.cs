public class Solution {
    public string IntToRoman(int num) {
        
        string roman = "";
        int thousand = num/1000;
        for(int x = 0;x<thousand;x++){
            roman += "M";
        }
        
        
        
        num = num%1000;
        
        string[] numerals = {"C","D","M","X","L","C","I","V","X"} ;
        int divisor = 100;
        
        for(int x = 0;x<3;x++){
            if(num/divisor == 4){
                roman += numerals[x*3]+numerals[x*3+1];
                num -= 4*divisor;
            }
            else if(num/divisor == 9){
                roman += numerals[x*3]+numerals[x*3+2];
                num -= 9*divisor;
            }
            else if (num/divisor >= 5){
                roman += numerals[x*3+1];
                num -= 5*divisor;
            }
            int remainder = num/divisor;
            for(int y = 0;y<remainder;y++){
                roman += numerals[x*3];
            }
            num -= remainder * divisor;
            
            
            divisor /= 10;
        }
        
        
        
        
        return roman;
        
    }
}