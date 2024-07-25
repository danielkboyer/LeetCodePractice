function wordBreak(s: string, wordDict: string[]): boolean {
    const dp = new Array(s.length+1).fill(false);
    dp[0] = true;

    var wordSet = new Set(wordDict);


    for(var i = 1;i<=s.length;i++){
        for(var j = 0;j<i;j++){
            if(dp[j] && wordSet.has(s.substring(j,i))){
                dp[i] = true;
                break;
            }
        }
    }

    return dp[s.length];
};