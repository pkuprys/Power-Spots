/**
 * This method checks whether a challenge is allowed or if it has been successful.
 * In the case where a team has already owned a spot, it will allow them to 
 * take the challenge again.
 * If they have not owned the spot before, then this will set them as the owner if the 
 * challenge is successfully completed
 */
Parse.Cloud.beforeSave("Challenge", function(request, response) {
	var success = request.object.get("success");
  	if (typeof(success) == 'undefined' || success == null) {
  		console.log("new challenge attempt"); 		
  		// this is a new challenge attempt, see if this challenge is available for this team
  		// it is available if they are not the current owners
  		var spot = request.object.get("spot");
  		var team = request.object.get("team");
  		if(spot == null || team == null){
  			response.error("An error has occurred, please try again.");
  		}
  		spot.fetch({
  			success: function(spot) {
    			if(spot.get("owner") && spot.get("owner").id === team.id){
    				console.log("Team already owns this spot");
    				response.error("Your team has already claimed this Spot once.");
    			}
    			else{
    				console.log("Attempting new challenge.");
    				response.success();
    			}
  			},
  			error: function(error) {
    			response.error("An error has occurred, please try again.");
  			}
		});
	}
	else if(!success){
		// don't do anything because it's a failed attempt
		console.log("Failed challenge attempt.");
	    response.success();
	}
	else{
		// they have successfully completed the challenge, so award the spot to them
		// and increment their token count if it is the first time they took the spot
		var spot = request.object.get("spot");
  		var team = request.object.get("team");

		var query = new Parse.Query("Challenge");
		query.equalTo("spot", spot);
		query.equalTo("team", team);
		query.equalTo("success", true);
		query.count({
			success: function(count) {
				if(count > 0){
					console.log("Spot already claimed once.");
				}
				else{
					console.log("Incrementing team token count");
					team.increment("tokenCount");
					team.save();
				}
			},
			error: function(error) {
				response.error("An error has occurred, please try again.");
			}
		});

		//update spot owner
		spot.fetch({
			success: function(spot) {
				console.log("spot claimed");
				spot.set("owner", request.object.get("team"));
				spot.save();
				response.success();			
  			},
			error: function(error) {
				response.error("An error has occurred, please try again.");
			}
		});
	}
});