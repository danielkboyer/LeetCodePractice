function productExceptSelf(nums: number[]): number[] {
    var numsProd = Array(nums.length);

    var pre = Array(nums.length);
    var suff = Array(nums.length);

    pre[0] = 1;
    suff[nums.length-1] = 1;

    for(var i = 1; i< nums.length;i++){
        pre[i] = pre[i-1] * nums[i-1];
    }

    for(var i = nums.length-2; i >=0; i--){
        suff[i]= suff[i+1] * nums[i+1];
    }


    for(var i = 0;i<nums.length;i++){
        numsProd[i] = suff[i] * pre[i];
    }

    return numsProd;
};