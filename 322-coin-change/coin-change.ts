function coinChange(coins: number[], amount: number): number {
    if(amount <= 0 ){
        return 0;
    }

    var dp = new Array(amount+1).fill(Number.MAX_VALUE);
    dp[0] = 0;
    for(let k = 1;k<amount+1;k++){
        for(let j = 0;j<coins.length;j++){
            if(k - coins[j] >= 0){
                dp[k] = Math.min(dp[k], 1 + dp[k - coins[j]]);
            }
            
        }
    }

    if(dp[amount] == Number.MAX_VALUE){
        return -1;
    }
    return dp[amount];
};