(script startup aa_turrets_start

	(aa_turrets_place)
	(device_set_power aa_turrets_switch 1)
	(sleep_until (> (device_get_position aa_turrets_switch) 0))
	(wake aa_turrets_getready)
	(sound_impulse_start sfx_blip NONE 1)
)

(script dormant aa_turrets_getready

	(device_set_power aa_turret_switch01 1)
	(if (not (> (device_get_position aa_turret_switch01) 0)) (f_blip_object aa_turret_switch01 blip_interface))
	(sleep_until (> (device_get_position aa_turret_switch01) 0))
	(wake aa_turret01)
	(device_set_power aa_turret_switch02 1)
	(if (not (> (device_get_position aa_turret_switch02) 0)) (f_blip_object aa_turret_switch02 blip_interface))
	(sleep_until (> (device_get_position aa_turret_switch02) 0))
	(wake aa_turret02)
	(device_set_power aa_turret_switch03 1)
	(if (not (> (device_get_position aa_turret_switch03) 0)) (f_blip_object aa_turret_switch03 blip_interface))
	(sleep_until (> (device_get_position aa_turret_switch03) 0))
	(wake aa_turret03)
	(device_set_power aa_turret_switch04 1)
	(if (not (> (device_get_position aa_turret_switch04) 0)) (f_blip_object aa_turret_switch04 blip_interface))
	(sleep_until (> (device_get_position aa_turret_switch04) 0))
	(wake aa_turret04)

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
	(if (<= (ai_living_count sq_aa_turret04) 0) (begin

		(ai_place sq_aa_turret04)
		(print "placing aa_turret04...")
		(sleep 1)
		(object_cannot_die (ai_vehicle_get_from_starting_location sq_aa_turret04/pilot) true)
		(object_cannot_take_damage (object_get_parent	sq_aa_turret04))
		(ai_disregard (ai_actors sq_aa_turret04) true)
		(ai_braindead sq_aa_turret04 true)

	))
)

(script dormant aa_turret01

	(print "aa_turret01 ACTIVE...")
	(f_unblip_object aa_turret_switch01)
	(ai_braindead sq_aa_turret01 false)
	(chud_track_object_with_priority (ai_vehicle_get sq_aa_turret01/pilot) 17)
	(sound_impulse_start sfx_blip NONE 1)
	(sleep 180)
	(chud_track_object (ai_vehicle_get sq_aa_turret01/pilot) false )

)

(script dormant aa_turret02

	(print "aa_turret02 ACTIVE...")
	(f_unblip_object aa_turret_switch02)
	(ai_braindead sq_aa_turret02 false)
	(chud_track_object_with_priority (ai_vehicle_get sq_aa_turret02/pilot) 18)
	(sound_impulse_start sfx_blip NONE 1)
	(sleep 180)
	(chud_track_object (ai_vehicle_get sq_aa_turret02/pilot) false )

)

(script dormant aa_turret03

	(print "aa_turret03 ACTIVE...")
	(f_unblip_object aa_turret_switch03)
	(ai_braindead sq_aa_turret03 false)
	(chud_track_object_with_priority (ai_vehicle_get sq_aa_turret03/pilot) 19)
	(sound_impulse_start sfx_blip NONE 1)
	(sleep 180)
	(chud_track_object (ai_vehicle_get sq_aa_turret03/pilot) false )

)

(script dormant aa_turret04

	(print "aa_turret04 ACTIVE...")
	(f_unblip_object aa_turret_switch04)
	(ai_braindead sq_aa_turret04 false)
	(chud_track_object_with_priority (ai_vehicle_get sq_aa_turret04/pilot) 20)
	(sound_impulse_start sfx_blip NONE 1)
	(sleep 180)
	(chud_track_object (ai_vehicle_get sq_aa_turret04/pilot) false )

)

(script static void air_attack

	(print "air attack test inbound...")
	(sleep 60)
	(print "air attack!")
	(sleep 60)
	(print "wave 1...")
	(ai_place sq_ai_test_air)
	(chud_track_object_with_priority (ai_vehicle_get sq_ai_test_air) 1)
	(sleep 180)
	(print "wave 2...")
	(ai_place sq_ai_test_air)
	(chud_track_object_with_priority (ai_vehicle_get sq_ai_test_air) 2)
	(sleep 180)
	(print "wave final...")
	(ai_place sq_ai_test_air)
	(chud_track_object_with_priority (ai_vehicle_get sq_ai_test_air) 2)
	(sleep 180)
	(print "air attack finish...")

)
