function candy(ratings: number[]): number {

    var n = ratings.length;
    var candies = Array(n).fill(1);
    for(var i =1;i<n;i++){

        var leftRating = ratings[i-1];
        var rating = ratings[i];
        if(rating > leftRating){
            if(candies[i] <= candies[i-1]){
                candies[i] = candies[i-1] + 1;
            }
        }
    }

    var totalCandy = 0;

    for(var i = n-1;i>=0;i--){
         var rightRating = ratings[i+1];
        var rating = ratings[i];

        if(rating > rightRating){
            if(candies[i] <= candies[i+1]){
                candies[i] = candies[i+1] + 1;
            }
        }
        totalCandy+=candies[i];
    }

    return totalCandy;
};