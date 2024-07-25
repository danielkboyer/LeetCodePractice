function rob(nums: number[]): number {
    
    if(nums.length == 1){
        return nums[0];
    }

    if(nums.length == 2){
        return Math.max(nums[0],nums[1]);
    }
    var calc: HouseValue[] = new Array(nums.length);
    calc[0] = new HouseValue(nums[0],0);
    calc[1] = new HouseValue(nums[1],nums[0]);

    for(var i = 2;i<nums.length;i++){
        calc[i] = new HouseValue(Math.max(calc[i-2].takeValue, calc[i-2].nonTakeValue) + nums[i],Math.max(calc[i-1].takeValue, calc[i-1].nonTakeValue))
    }

    var last = calc[nums.length-1];

    return Math.max(last.takeValue,last.nonTakeValue);

};


class HouseValue{
    constructor(public takeValue: number, public nonTakeValue: number){}
}