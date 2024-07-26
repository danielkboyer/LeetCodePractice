function lengthOfLIS(nums: number[]): number {

    if(nums.length === 0){
        return 0;
    }
    const n = nums.length;
    var dp = Array(n).fill(1);

    for(let i = 1;i<n;i++){
        for(let j = 0;j<i;j++){
            if(nums[i] > nums[j]){
                dp[i] = Math.max(dp[i],dp[j]+1);
            }
        }
    }

    return Math.max(...dp);
};