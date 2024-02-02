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
