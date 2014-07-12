/**
 * This method checks whether a challenge is allowed or if it has been successful.
 * In the case where a team has already owned a spot, it will allow them to 
 * take the challenge again.
 * If they have not owned the spot before, then this will set them as the owner if the 
 * challenge is successfully completed
 */
Parse.Cloud.beforeSave("Challenge", function(request, response) {
	//get day
	var day = "1";
	var configQuery = new Parse.Query("GameConfiguration");
	configQuery.equalTo("key", "day");
	configQuery.find({
		success: function(results){
			day = results[0].get("value");
			console.log("Got day: " + day);
		},
		error: function(error) {
			console.log(error);
			response.error("An error has occurred, please try again.");
		}
	});
	
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
					console.log("Incrementing team token count for day: " + day);
					var column = day == "1" ? "dayOneTokenCount" : "dayTwoTokenCount";
					console.log(column);
					team.increment(column);
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

/**
 * This method checks whether the countdown value in the GameConfiguration table is 
 * being updated to end the game. If it is, it will set each team's endGame boolean 
 * value to true. If it is not, it will set it to false.
 */
Parse.Cloud.beforeSave("GameConfiguration", function(request, response) {
	var key = request.object.get("key");
	if(typeof(key) == 'undefined' || key != 'countdown') {
		response.success();
	}
	
	var endGame = false;
	var value = request.object.get("value");
	if(typeof(value) != 'undefined' && value == 'on'){
		endGame = true;
	}	
	var getTeams = new Parse.Query("Team");
	getTeams.find({
		success: function(teams){
			for(var i = 0; i < teams.length; i++){
				console.log("Setting " + teams[i].get("name") + "'s endGame status to " + endGame);
				teams[i].set("endGame", endGame);
				teams[i].save({
					success: function(result){
						console.log("Team endgame update successful");
					},
					error: function(error){
						console.log(error);
					}
				});
			}
			response.success();
		},
		error: function(error) {
			console.log(error);
			response.error("An error has occurred, please try again.");
		}
	});
});