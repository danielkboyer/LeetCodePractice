function minimumTotal(triangle: number[][]): number {

    
    var n = triangle.length;
    var dp = new Array(n);
    for(let i = 0;i<n;i++){
        dp[i] = new Array(triangle[i].length);
    }

    dp[0][0] = triangle[0][0];

    for(let i = 1; i< n;i++){
        for(let j = 0;j<triangle[i].length;j++){
            var value = triangle[i][j];
            if(j == 0){
                dp[i][j] = dp[i-1][0] + value;
                continue;
            }
            if(j == triangle[i].length -1){
                dp[i][j] = dp[i-1][j-1] + value;
                continue;
            }

            dp[i][j] = Math.min(dp[i-1][j-1], dp[i-1][j])+ value;
        }
    }

    return Math.min(...dp[n-1]);
};