; ==============================================================================================================
; ====== PHANTOM COMMAND SCIRPTS ===============================================================================
; ==============================================================================================================


;============================================= PHANTOM 01 ======================================================
(script command_script cs_sur_phantom_01
	(set v_sur_phantom_01 (ai_vehicle_get_from_starting_location sq_sur_phantom_01/phantom))
	(sleep 1)
	(object_cannot_die v_sur_phantom_01 TRUE)
	(cs_enable_pathfinding_failsafe TRUE)
	(cs_ignore_obstacles TRUE)			

	(cs_fly_by ps_sur_phantom_01/p0)
	(cs_vehicle_boost TRUE)
	(cs_fly_by ps_sur_phantom_01/p1)
	(cs_fly_to_and_face ps_sur_phantom_01/p2 ps_sur_phantom_01/p3)
	(cs_vehicle_boost FALSE)
	(cs_vehicle_speed 0.50)
	(sleep 15)

		
	; ========= DRIVE-BY DROPOFF =============================

		(cs_fly_to_and_face ps_sur_phantom_01/p3 ps_sur_phantom_01/face 3)
		(cs_vehicle_speed 0.3)
		(wake phantom_01_blip)
		(unit_open v_sur_phantom_01)
		(sleep 60)
		(vehicle_unload v_sur_phantom_01 "phantom_p_rb")
		(sleep (random_range 5 15))
		(cs_fly_to_and_face ps_sur_phantom_01/p4 ps_sur_phantom_01/p5 4)
		(vehicle_unload v_sur_phantom_01 "phantom_p_rf")
		(sleep (random_range 5 15))
		(cs_fly_to_and_face ps_sur_phantom_01/p5 ps_sur_phantom_01/p6 3)
		(vehicle_unload v_sur_phantom_01 "phantom_p_mr_b")
		(sleep (random_range 5 15))
		(cs_fly_to_and_face ps_sur_phantom_01/p6 ps_sur_phantom_01/face 4)
		(vehicle_unload v_sur_phantom_01 "phantom_p_mr_f")
		(sleep_until (= (vehicle_test_seat v_sur_phantom_01 "phantom_p_mr_f") 0))
		(sleep 30)
		(unit_close v_sur_phantom_01)
	; ========= DRIVE-BY DROPOFF =============================

	(sleep 15)
	(cs_vehicle_speed 1)
	(cs_fly_by ps_sur_phantom_01/p7)
	(cs_vehicle_boost TRUE)
	(cs_fly_by ps_sur_phantom_01/p8)
	(cs_fly_by ps_sur_phantom_01/p9)
	(cs_vehicle_boost FALSE)
	(cs_fly_by ps_sur_phantom_01/erase 10)
	; erase squad 
	(ai_erase ai_current_squad)
	;(ai_erase sq_sur_phantom_01)
)

(script continuous phantom_01_blip
	(sleep_forever)
	(print "blipping phantom_01...")
	(f_survival_callout_dropship v_sur_phantom_01)
)

;============================================= PHANTOM 02 ======================================================
(script command_script cs_sur_phantom_02
	(set v_sur_phantom_02 (ai_vehicle_get_from_starting_location sq_sur_phantom_02/phantom))
	(sleep 1)
	(object_cannot_die v_sur_phantom_02 TRUE)
	(cs_enable_pathfinding_failsafe TRUE)
	(cs_ignore_obstacles TRUE)			

	(cs_fly_by ps_sur_phantom_02/p0)
	(cs_vehicle_boost TRUE)
	(cs_fly_by ps_sur_phantom_02/p1)
	(cs_fly_by ps_sur_phantom_02/p2)
	(cs_vehicle_boost FALSE)
	(cs_fly_by ps_sur_phantom_02/p3)
	(sleep 15)

	; ========= DRIVE-BY DROPOFF =============================

		(cs_fly_to_and_face ps_sur_phantom_02/p4 ps_sur_phantom_02/face 3)
		(cs_vehicle_speed 0.4)
		(wake phantom_02_blip)
		(unit_open v_sur_phantom_02)
		(sleep 60)
		(vehicle_unload v_sur_phantom_02 "phantom_p_lb")
		(sleep (random_range 5 15))
		(cs_fly_to_and_face ps_sur_phantom_02/p5 ps_sur_phantom_02/face 3)
		(vehicle_unload v_sur_phantom_02 "phantom_p_lf")
		(sleep (random_range 5 15))
		(cs_fly_to_and_face ps_sur_phantom_02/p6 ps_sur_phantom_02/face 3)
		(vehicle_unload v_sur_phantom_02 "phantom_p_ml_b")
		(sleep (random_range 5 15))
		(cs_fly_to_and_face ps_sur_phantom_02/p7 ps_sur_phantom_02/face 3)
		(vehicle_unload v_sur_phantom_02 "phantom_p_ml_f")
		(sleep_until (= (vehicle_test_seat v_sur_phantom_02 "phantom_p_ml_f") 0))
		(sleep 30)
		(unit_close v_sur_phantom_02)
	; ========= DRIVE-BY DROPOFF =============================


	(sleep 15)
	(cs_vehicle_speed 1.0)
	(cs_vehicle_boost TRUE)
	(cs_fly_to_and_face ps_sur_phantom_02/p8 ps_sur_phantom_02/face)
	(cs_fly_by ps_sur_phantom_02/p9)
	(cs_fly_by ps_sur_phantom_02/p10)
	(cs_vehicle_boost FALSE)
	(cs_fly_by ps_sur_phantom_02/erase 10)
	; erase squad 
	(ai_erase ai_current_squad)
	;(ai_erase sq_sur_phantom_02)
)

(script continuous phantom_02_blip
	(sleep_forever)
	(print "blipping phantom_02...")
	(f_survival_callout_dropship v_sur_phantom_02)
)


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


;============================================= PHANTOM 04 ======================================================
(script command_script cs_sur_phantom_04
	(set v_sur_phantom_04 (ai_vehicle_get_from_starting_location sq_sur_phantom_04/phantom))
	(sleep 1)
	(object_cannot_die v_sur_phantom_04 TRUE)
	(cs_enable_pathfinding_failsafe TRUE)
	(cs_ignore_obstacles TRUE)			
		
	; ======== LOAD WRAITH  ==================			
	(if (survival_mode_scenario_extras_enable)
		(if 
			(and 
				(= (random_range 0 4) 0)
				(<= (object_get_health (ai_vehicle_get_from_spawn_point sq_sur_wraith_02/driver)) 0)
			)
			(f_load_phantom_cargo
								v_sur_phantom_04
								"single"
								sq_sur_wraith_02
								none
			)
		)
	)	
	; ======== LOAD WRAITH  ==================

	(cs_fly_by ps_sur_phantom_04/p0)
	(cs_vehicle_boost TRUE)
	(cs_fly_by ps_sur_phantom_04/p1)
	(cs_fly_by ps_sur_phantom_04/p2)
	(cs_vehicle_boost FALSE)
	(cs_fly_to_and_face ps_sur_phantom_04/drop ps_sur_phantom_04/face 1)
	(sleep 15)
	(wake phantom_04_blip)

	; ========= DRIVE-BY DROPOFF =============================

	; drop wraith 
	(vehicle_unload v_sur_phantom_04 "phantom_lc")
	
	(f_unload_phantom
					v_sur_phantom_04
					"dual"
	)
	; ========= DRIVE-BY DROPOFF =============================
	
	(sleep 15)
	(cs_fly_by ps_sur_phantom_04/p3)
	(cs_vehicle_boost TRUE)
	(cs_fly_by ps_sur_phantom_04/p1)
	(cs_fly_by ps_sur_phantom_04/p0)
	(cs_vehicle_boost FALSE)
	(cs_fly_by ps_sur_phantom_04/erase 10)
	; erase squad 
	(ai_erase ai_current_squad)
)

(script continuous phantom_04_blip
	(sleep_forever)
	(print "blipping phantom_04...")
	(f_survival_callout_dropship v_sur_phantom_04)
)


(global vehicle v_sq_sur_wraith_02 NONE)


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
