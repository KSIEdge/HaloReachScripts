;============================================= PHANTOM 03 ======================================================
(script command_script cs_sur_phantom_03
	(set v_sur_phantom_03 (ai_vehicle_get_from_starting_location sq_sur_phantom_03/phantom))
	(sleep 1)
	(object_cannot_die v_sur_phantom_03 TRUE)
	(cs_enable_pathfinding_failsafe TRUE)
	(cs_ignore_obstacles TRUE)			
		
	; ======== LOAD WRAITH  ==================
	(if (survival_mode_scenario_extras_enable)
		(if 	
			(and 
				(= (random_range 0 4) 0)
				(<= (object_get_health (ai_vehicle_get_from_spawn_point sq_sur_wraith_01/driver)) 0)
			)
			(f_load_phantom_cargo
								v_sur_phantom_03
								"single"
								sq_sur_wraith_01
								none
			)
		)
	)
	; ======== LOAD WRAITH  ==================
	
	(cs_fly_by ps_sur_phantom_03/p0)
	(cs_vehicle_boost TRUE)
	(cs_fly_by ps_sur_phantom_03/p1)
	(cs_fly_by ps_sur_phantom_03/p2)
	(cs_vehicle_boost FALSE)
	(cs_fly_to_and_face ps_sur_phantom_03/drop ps_sur_phantom_03/face 1)
	(sleep 15)
	(wake phantom_03_blip)

	; ========= DROP DUDES HERE =============================
	
	; drop wraith 
	(vehicle_unload v_sur_phantom_03 "phantom_lc")

	(f_unload_phantom
					v_sur_phantom_03
					"dual"
	)
	; ========= DROP DUDES HERE =============================
	
	(sleep 15)
	(cs_fly_by ps_sur_phantom_03/p2)
	(cs_vehicle_boost TRUE)
	(cs_fly_by ps_sur_phantom_03/p1)
	(cs_fly_by ps_sur_phantom_03/p0)
	(cs_vehicle_boost FALSE)
	(cs_fly_by ps_sur_phantom_03/erase 10)
	; erase squad 
	(ai_erase ai_current_squad)
)

(script continuous phantom_03_blip
	(sleep_forever)
	(print "blipping phantom_03...")
	(f_survival_callout_dropship v_sur_phantom_03)
)


(global vehicle v_sq_sur_wraith_01 NONE)
