function trap(height: number[]): number {
    var n = height.length;

    if(n < 3){
        return 0;
    }

    var maxIndex = -1;
    var maxValue = -1;
    for(var i = 0;i<n;i++){
        if(height[i] > maxValue){
            maxValue = height[i];
            maxIndex = i;
        }
    }

    var leftPointer = 1
    var rightPointer = n-2;

    var maxLeft = height[0];
    var maxRight = height[n-1];
    
    var totalWater = 0;
    while(leftPointer < maxIndex){
        var h = Math.min(maxLeft,maxValue);

        totalWater += Math.max(h - height[leftPointer],0);
        maxLeft = Math.max(maxLeft,height[leftPointer]);
        leftPointer++;
    }

      while(rightPointer > maxIndex){
        var h = Math.min(maxRight,maxValue);

        totalWater += Math.max(h - height[rightPointer],0);
        maxRight = Math.max(maxRight,height[rightPointer]);
        rightPointer--;
    }

    return totalWater;



};