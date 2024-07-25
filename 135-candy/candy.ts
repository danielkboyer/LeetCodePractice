function candy(ratings: number[]): number {
    
    var added = true;
    var candies = Array(ratings.length).fill(1);
    while(added){
        added = false;
        for(var i = 0;i<ratings.length; i++){
            var leftRating = i == 0 ? ratings[i] : ratings[i-1];
            var rightRating = i == ratings.length -1 ? ratings[i]: ratings [i+1];

            var rating = ratings[i];
            var candy = candies[i];

            if(rating > leftRating){
                if(candy <= candies[i-1]){
                    candies[i] = candies[i-1]+1;
                    added = true;
                }
            }

            if(rating > rightRating){
                if(candy <= candies[i+1]){
                    candies[i] = candies[i+1] + 1;
                    added = true;
                }
            }

        }
    }

    return candies.reduce((prev,add)=>prev+add);


};