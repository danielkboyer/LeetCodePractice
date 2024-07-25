function climbStairs(n: number): number {
    var calc = Array(n).fill(1);

    calc[0] = 1;
    calc[1] = 2;
    for(var i = 2; i<n;i++){
        calc[i] = calc[i-2] + calc[i-1];
    }
    return calc[n-1];
};