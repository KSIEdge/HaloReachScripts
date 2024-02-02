;============================================= BONUS PHANTOM =======================================================


(script command_script cs_sur_bonus_phantom
	(set v_sur_bonus_phantom (ai_vehicle_get_from_spawn_point sq_sur_bonus_phantom/phantom))
	(sleep 1)
	(object_cannot_die v_sur_bonus_phantom TRUE)
	(cs_enable_pathfinding_failsafe TRUE)
	(cs_ignore_obstacles TRUE)			
		
	(cs_fly_by ps_sur_bonus_phantom/p0)
	(cs_vehicle_boost TRUE)
	(cs_fly_by ps_sur_bonus_phantom/p1)
	(cs_fly_by ps_sur_bonus_phantom/p2)
	(cs_vehicle_boost FALSE)
	(cs_fly_to_and_face ps_sur_bonus_phantom/drop ps_sur_bonus_phantom/face 1)
	(sleep 15)
	(wake phantom_bonus_blip)

	; ======== DROP DUDES HERE ======================
		
		(set b_sur_bonus_phantom_ready TRUE)

	; ======== DROP DUDES HERE ======================
	
	; sleep until BONUS ROUND is over 
	(sleep_until b_sur_bonus_end)
	(sleep 45)
		
	; fly away 
	(sleep 15)
	(cs_fly_by ps_sur_bonus_phantom/p2)
	(cs_vehicle_boost TRUE)
	(cs_fly_by ps_sur_bonus_phantom/p1)
	(cs_fly_by ps_sur_bonus_phantom/p0)
	(cs_vehicle_boost FALSE)
	(cs_fly_by ps_sur_bonus_phantom/erase 10)
	; erase squad 
	(ai_erase ai_current_squad)
)

(script continuous phantom_bonus_blip
	(sleep_forever)
	(print "blipping bonus phantom...")
	(f_survival_callout_dropship v_sur_bonus_phantom)
)
