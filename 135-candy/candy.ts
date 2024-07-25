function candy(ratings: number[]): number {

    var n = ratings.length;
    var ratingWithIndex = Array(n);

    for(var i =0;i<n;i++){
    ratingWithIndex[i] = new RatingWithIndex(ratings[i],i);

    }


    var candies = Array(n).fill(1);


    ratingWithIndex.sort((a,b)=>a.rating - b.rating);
    
    for(var i =0;i<n;i++){
        var ratingAndIndex = ratingWithIndex[i];
        var index = ratingAndIndex.index;
        var rating = ratingAndIndex.rating;

        var leftRating = index > 0 ? ratings[index-1]: ratings[0];
        var rightRating = index < n-1 ? ratings[index+1]: ratings[index];


        if(rating > leftRating){
            if(candies[index] <= candies[index-1]){
                candies[index] = candies[index-1] + 1;
            }
        }

        if(rating > rightRating){
            if(candies[index] <= candies[index+1]){
                candies[index] = candies[index+1] +1;
            }
        }
    }

    return candies.reduce((a,b) => a+b);
};


class RatingWithIndex{
    constructor(public rating, public index){}
}