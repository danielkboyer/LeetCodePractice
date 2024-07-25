function maximalSquare(matrix: string[][]): number {
    if(matrix.length == 0 || matrix[0].length == 0){
        return 0;
    }
  const calculated: number[][] = new Array(matrix.length)
                                   .fill(0)
                                   .map(() => 
                                     new Array(matrix[0].length).fill(0)
                                   );

var maxNumber = 0;
    for(var i = 0;i<matrix.length;i++){
        for(var j = 0;j<matrix[i].length; j++){
            if(i == 0 || j == 0){
                calculated[i][j] = matrix[i][j] == "1" ? 1: 0;
                maxNumber = Math.max(calculated[i][j],maxNumber);
                continue;
            }
            if(matrix[i][j] == "0"){
                calculated[i][j] = 0;
                continue;
            }

            calculated[i][j] = Math.min(calculated[i-1][j],calculated[i-1][j-1], calculated[i][j-1]) + 1;

            maxNumber = Math.max(calculated[i][j],maxNumber);


        }
    }

    return maxNumber*maxNumber;

};