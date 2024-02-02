;=============== Target 01 =======================================
(script continuous resupply_target_01
	(sleep_forever)
	(sleep (random_range 5 15))
	(print "target 01...")
	(object_create dm_target_01)
	(begin
		(if (= (airstrike_weapons_exist) FALSE)
			(begin
				(airstrike_set_launches 2)
				(sleep 1)
				(object_create_variant sc_target_01 "target_laser")
			)
			
			(begin
				(airstrike_set_launches 2)
				(submit_incident_with_cause_campaign_team "sur_airstrike_refill" player)
				(sleep 1)
				(begin_random_count 1
					(object_create_variant sc_target_01 "laser")
					(object_create_variant sc_target_01 "rocket")
					(object_create_variant sc_target_01 "sniper")
				)
			)
		)
	)
	(sleep 1)
	(objects_attach dm_target_01 "" sc_target_01 "")
	(sleep 1)
	(device_set_position dm_target_01 1)
		(sleep_until (>= (device_get_position dm_target_01) 0.98) 1)
		(effect_new_on_object_marker fx\fx_library\pod_impacts\default\pod_impact_default_small.effect sc_target_01 "fx_impact")	
	(sleep_until (>= (device_get_position dm_target_01) 1) 1)
	(sleep 1)
	(objects_detach dm_target_01 sc_target_01)
	(object_destroy dm_target_01)
	(sleep (random_range 8 17))
	(object_damage_damage_section sc_target_01 "panel" 100)
	(wake target_waypoint_01)
)

(script continuous target_waypoint_01
	(sleep_forever)
	(print "placing waypoint on target 01...")
	(sound_impulse_start sfx_blip NONE 1)
	(f_blip_object sc_target_01 blip_ordnance)
	(sleep_until (not (resupply_pod_test_weapon sc_target_01)) 5)
	(f_unblip_object sc_target_01)
)
