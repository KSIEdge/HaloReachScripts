(script command_script cs_sur_bonus_phantom //main script for bonus phantom
	(set v_sur_bonus_phantom (ai_vehicle_get_from_spawn_point sq_sur_bonus_phantom/phantom)) //sq_sur_bonus_phantom
	(sleep 1) //wait 1 second
	(object_cannot_die v_sur_bonus_phantom TRUE) //make phantom immune to damage
	(cs_enable_pathfinding_failsafe TRUE) //phantom will go through do everything it can to get to its destination
	(cs_ignore_obstacles TRUE) //used in combination with cs_enable_pathfinding_failsafe to avoid obstacles and phase through them
		
	(cs_fly_by ps_sur_bonus_phantom/p0) //cs_fly_by used to move a phantom to a point p0 
	(cs_vehicle_boost TRUE) //cs_vehicle_boost is TRUE, Phantom moves at incredible speeds
	(cs_fly_by ps_sur_bonus_phantom/p1)  //cs_fly_by used to move a phantom to a point p1
	(cs_fly_by ps_sur_bonus_phantom/p2) //cs_fly_by used to move a phantom to a point p2
	(cs_vehicle_boost FALSE) //cs_vehicle_boost is FALSE, Phantom moves at normal speed
	(cs_fly_to_and_face ps_sur_bonus_phantom/drop ps_sur_bonus_phantom/face 1)
	(sleep 15) //wait 15 seconds
	(wake phantom_bonus_blip) //blip bonus phantom on HUD
