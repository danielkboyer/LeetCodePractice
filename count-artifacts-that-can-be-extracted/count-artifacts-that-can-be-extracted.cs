public class Solution {
    public int DigArtifacts(int n, int[][] artifacts, int[][] dig) {
        
        HashSet<Point> digSpots = new HashSet<Point>();
        for(int x = 0;x< dig.Length;x++){
            digSpots.Add(new Point(){X = dig[x][0],Y = dig[x][1]});
            
        }
        
        
        int count = 0;
        for(int x = 0;x<artifacts.Length;x++){
            Point PointOne = new Point(){X = artifacts[x][0],Y = artifacts[x][1]};
            Point PointTwo = new Point(){X = artifacts[x][2],Y =  artifacts[x][3]};

            if(!digSpots.Contains(PointOne)){
                continue;
            }
            if(!digSpots.Contains(PointTwo)){
                continue;
            }
            int XDiff = PointTwo.X - PointOne.X;
            bool valid = true;
            while(XDiff != 0){
                
                if(!digSpots.Contains(new Point(){X = PointOne.X + XDiff, Y = PointOne.Y})){
                    valid = false;
                    break;
                }
                
                if(XDiff > 0)
                    XDiff -=1;
                if(XDiff < 0)
                    XDiff+=1;
                    
            }
            if(!valid)
                continue;
            int YDiff = PointTwo.Y - PointOne.Y;
            while(YDiff != 0){
                if(!digSpots.Contains(new Point(){X = PointOne.X , Y = PointOne.Y + YDiff})){
                    valid = false;
                    break;
                }
                
                if(YDiff > 0)
                    YDiff -=1;
                if(YDiff < 0)
                    YDiff+=1;
            }
            if(!valid)
                continue;
            
            count++;
            //bottom
            
        }
        
        return count;
        
        
    }
    
    public struct Point{
        public int X;
        public int Y;
    }
}