function canCompleteCircuit(gas: number[], cost: number[]): number {
    const computed = Array(gas.length);

    var total = 0;
    var half = 0;
    for(var i = 0;i<computed.length;i++){
        var compute = gas[i] - cost[i];
        total += compute;
        half += Math.abs(compute);
        computed[i] = compute;
    }
    

    if(total < 0){
        return -1;
    }

    half /= 2;

    var carry = 0;
    var index = 0;
    for(var i =0;i<gas.length;i++){
        carry += computed[i];

        if(carry < 0){
            carry = 0;
            index = i +1;
            continue;
        }

        if(carry >= half){
            return index;
        }


    }

    return index;



};