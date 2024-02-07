(global boolean isready_aa_turret01 FALSE)
(global boolean isready_aa_turret02 FALSE)
(global boolean isready_aa_turret03 FALSE)
(script startup aa_turrets

	(aa_turrets_place)
	(device_set_power aa_turret_switch01 1)
	(device_set_power aa_turret_switch02 1)
	(device_set_power aa_turret_switch03 1)

	(if (not (> (device_get_position aa_turret_switch01) 0)) (f_blip_object aa_turret_switch01 blip_interface))
	(sleep_until (> (device_get_position aa_turret_switch01) 0))
	(f_unblip_object aa_turret_switch01)
	(ai_braindead sq_aa_turret01 FALSE)
	
	(if (not (> (device_get_position aa_turret_switch02) 0)) (f_blip_object aa_turret_switch02 blip_interface))
	(sleep_until (> (device_get_position aa_turret_switch02) 0))
	(f_unblip_object aa_turret_switch02)
	(ai_braindead sq_aa_turret02 FALSE)
	
	(if (not (> (device_get_position aa_turret_switch03) 0)) (f_blip_object aa_turret_switch03 blip_interface))
	(sleep_until (> (device_get_position aa_turret_switch03) 0))
	(f_unblip_object aa_turret_switch03)
	(ai_braindead sq_aa_turret03 FALSE)

)

(script static void aa_turrets_place

	(if (<= (ai_living_count sq_aa_turret01) 0) (begin

		(ai_place sq_aa_turret01)
		(print "placing aa_turret01...")
		(sleep 1)
		(object_cannot_die (ai_vehicle_get_from_starting_location sq_aa_turret01/pilot) true)
		(object_cannot_take_damage (object_get_parent	sq_aa_turret01))
		(ai_disregard (ai_actors sq_aa_turret01) true)
		(ai_braindead sq_aa_turret01 true)

	))
	(if (<= (ai_living_count sq_aa_turret02) 0) (begin

		(ai_place sq_aa_turret02)
		(print "placing aa_turret02...")
		(sleep 1)
		(object_cannot_die (ai_vehicle_get_from_starting_location sq_aa_turret02/pilot) true)
		(object_cannot_take_damage (object_get_parent	sq_aa_turret02))
		(ai_disregard (ai_actors sq_aa_turret02) true)
		(ai_braindead sq_aa_turret02 true)

	))
	(if (<= (ai_living_count sq_aa_turret03) 0) (begin

		(ai_place sq_aa_turret03)
		(print "placing aa_turret03...")
		(sleep 1)
		(object_cannot_die (ai_vehicle_get_from_starting_location sq_aa_turret03/pilot) true)
		(object_cannot_take_damage (object_get_parent	sq_aa_turret03))
		(ai_disregard (ai_actors sq_aa_turret03) true)
		(ai_braindead sq_aa_turret03 true)

	))
)
