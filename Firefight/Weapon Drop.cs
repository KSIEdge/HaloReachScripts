;================================================ WEAPON DROP CONTROL ============================================================

(global short g_sur_resupply_limit 0)

;checking if the weapon is in the supply pod still
(script static boolean (resupply_pod_test_weapon (object pod))
	(or
		(!= (object_at_marker pod "gun_high") NONE)
		(!= (object_at_marker pod "gun_mid") NONE)
		(!= (object_at_marker pod "gun_lower") NONE)
	)	
)


;main resupply thread
(script dormant survival_resupply_pod_spawn
	; set the max number of resupply pods at any one time 
	(cond
		((<= (game_coop_player_count) 2)		(set g_sur_resupply_limit 1))
		((= (game_coop_player_count) 3)		(set g_sur_resupply_limit 1))
		((= (game_coop_player_count) 4)		(set g_sur_resupply_limit 2))
		((>= (game_coop_player_count) 5)		(set g_sur_resupply_limit 2))
	)

	(sleep 1)
	
	; stays in this loop forever 
	(sleep_until
		(begin
			(sleep_until (survival_mode_should_drop_weapon) 5)
			
			(sleep 1)
			
			(print "cleaning up old resupply pods...")
			(sleep 1)
			(object_destroy sc_resupply_01)
			(object_destroy sc_resupply_02)
			(object_destroy sc_resupply_03)
			(object_destroy sc_resupply_04)
			(object_destroy sc_resupply_05)
			(object_destroy sc_resupply_06)
			(object_destroy sc_resupply_07)
			(object_destroy sc_resupply_08)
			(object_destroy sc_resupply_09)
			(object_destroy sc_target_01)
			(object_destroy sc_target_02)
			(object_destroy sc_target_03)
			
			(sleep 1)
			(print "bringing in longsword...")
			(object_create dm_longsword_01)
			(print "spawning in grenades...")
			(object_create_folder_anew cr_grenades)
			(sleep 1)
			(device_set_position_track dm_longsword_01 "ff10" 0)
			(device_animate_position dm_longsword_01 1 10.0 3 3 FALSE)
			(sleep_until (>= (device_get_position dm_longsword_01) 0.4) 1)
			(print "dropping off weapons...")
			(begin_random_count 1
				(wake resupply_target_01)
				(wake resupply_target_02)
				(wake resupply_target_03)
			)
			(begin_random_count g_sur_resupply_limit
				(wake resupply_pod_01)
				(wake resupply_pod_02)
				(wake resupply_pod_03)
				(wake resupply_pod_04)
				(wake resupply_pod_05)
				(wake resupply_pod_06)
				(wake resupply_pod_07)
				(wake resupply_pod_08)
				(wake resupply_pod_09)
			)
			
			(sleep 120)
			(object_destroy dm_longsword_01)
			
		FALSE)
	)
)

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


;=============== Target 02 =======================================
(script continuous resupply_target_02
	(sleep_forever)
	(sleep (random_range 5 15))
	(print "target 02...")
	(object_create dm_target_02)
	(begin
		(if (= (airstrike_weapons_exist) FALSE)
			(begin
				(airstrike_set_launches 2)
				(sleep 1)
				(object_create_variant sc_target_02 "target_laser")
			)
			
			(begin
				(airstrike_set_launches 2)
				(submit_incident_with_cause_campaign_team "sur_airstrike_refill" player)
				(sleep 1)
				(begin_random_count 1
					(object_create_variant sc_target_02 "laser")
					(object_create_variant sc_target_02 "rocket")
					(object_create_variant sc_target_02 "sniper")
				)
			)
		)
	)
	(sleep 1)
	(objects_attach dm_target_02 "" sc_target_02 "")
	(sleep 1)
	(device_set_position dm_target_02 1)
		(sleep_until (>= (device_get_position dm_target_02) 0.98) 1)
		(effect_new_on_object_marker fx\fx_library\pod_impacts\default\pod_impact_default_small.effect sc_target_02 "fx_impact")	
	(sleep_until (>= (device_get_position dm_target_02) 1) 1)
	(sleep 1)
	(objects_detach dm_target_02 sc_target_02)
	(object_destroy dm_target_02)
	(sleep (random_range 8 17))
	(object_damage_damage_section sc_target_02 "panel" 100)
	(wake target_waypoint_02)
)

(script continuous target_waypoint_02
	(sleep_forever)
	(print "placing waypoint on target 02...")
	(sound_impulse_start sfx_blip NONE 1)
	(f_blip_object sc_target_02 blip_ordnance)
	(sleep_until (not (resupply_pod_test_weapon sc_target_02)) 5)
	(f_unblip_object sc_target_02)
)


;=============== Target 03 =======================================
(script continuous resupply_target_03
	(sleep_forever)
	(sleep (random_range 5 15))
	(print "target 03...")
	(object_create dm_target_03)
	(begin
		(if (= (airstrike_weapons_exist) FALSE)
			(begin
				(airstrike_set_launches 2)
				(sleep 1)
				(object_create_variant sc_target_03 "target_laser")
			)
			
			(begin
				(airstrike_set_launches 2)
				(submit_incident_with_cause_campaign_team "sur_airstrike_refill" player)
				(sleep 1)
				(begin_random_count 1
					(object_create_variant sc_target_03 "laser")
					(object_create_variant sc_target_03 "rocket")
					(object_create_variant sc_target_03 "sniper")
				)
			)
		)
	)
	(sleep 1)
	(objects_attach dm_target_03 "" sc_target_03 "")
	(sleep 1)
	(device_set_position dm_target_03 1)
		(sleep_until (>= (device_get_position dm_target_03) 0.98) 1)
		(effect_new_on_object_marker fx\fx_library\pod_impacts\default\pod_impact_default_small.effect sc_target_03 "fx_impact")	
	(sleep_until (>= (device_get_position dm_target_03) 1) 1)
	(sleep 1)
	(objects_detach dm_target_03 sc_target_03)
	(object_destroy dm_target_03)
	(sleep (random_range 8 17))
	(object_damage_damage_section sc_target_03 "panel" 100)
	(wake target_waypoint_03)
)

(script continuous target_waypoint_03
	(sleep_forever)
	(print "placing waypoint on target 03...")
	(sound_impulse_start sfx_blip NONE 1)
	(f_blip_object sc_target_03 blip_ordnance)
	(sleep_until (not (resupply_pod_test_weapon sc_target_03)) 5)
	(f_unblip_object sc_target_03)
)

;=============== Resupply 01 =======================================
(script continuous resupply_pod_01
	(sleep_forever)
	(sleep (random_range 5 15))
	(print "resupply pod 01...")
	(object_create dm_resupply_01)
	(begin_random_count 1
		(object_create_variant sc_resupply_01 "laser")
		(object_create_variant sc_resupply_01 "rocket")
		(object_create_variant sc_resupply_01 "sniper")
	)
	(sleep 1)
	(objects_attach dm_resupply_01 "" sc_resupply_01 "")
	(sleep 1)
	(device_set_position dm_resupply_01 1)
		(sleep_until (>= (device_get_position dm_resupply_01) 0.98) 1)
		(effect_new_on_object_marker fx\fx_library\pod_impacts\default\pod_impact_default_small.effect sc_resupply_01 "fx_impact")	
	(sleep_until (>= (device_get_position dm_resupply_01) 1) 1)
	(sleep 1)
	(objects_detach dm_resupply_01 sc_resupply_01)
	(object_destroy dm_resupply_01)
	(sleep (random_range 8 17))
	(object_damage_damage_section sc_resupply_01 "panel" 100)
	(wake resupply_waypoint_01)
)

(script continuous resupply_waypoint_01
	(sleep_forever)
	(print "placing waypoint on resupply 01...")
	(sound_impulse_start sfx_blip NONE 1)
	(f_blip_object sc_resupply_01 blip_ordnance)
	(sleep_until (not (resupply_pod_test_weapon sc_resupply_01)) 5)
	(f_unblip_object sc_resupply_01)
)
					
										
;=============== Resupply 02 =======================================
(script continuous resupply_pod_02
	(sleep_forever)
	(sleep (random_range 5 15))
	(print "resupply pod 02...")
	(object_create dm_resupply_02)
	(begin_random_count 1
		(object_create_variant sc_resupply_02 "laser")
		(object_create_variant sc_resupply_02 "rocket")
		(object_create_variant sc_resupply_02 "sniper")
	)
	(sleep 1)
	(objects_attach dm_resupply_02 "" sc_resupply_02 "")
	(sleep 1)
	(device_set_position dm_resupply_02 1)
		(sleep_until (>= (device_get_position dm_resupply_02) 0.98) 1)
		(effect_new_on_object_marker fx\fx_library\pod_impacts\default\pod_impact_default_small.effect sc_resupply_02 "fx_impact")	
	(sleep_until (>= (device_get_position dm_resupply_02) 1) 1)
	(sleep 1)
	(objects_detach dm_resupply_02 sc_resupply_02)
	(object_destroy dm_resupply_02)
	(sleep (random_range 8 17))
	(object_damage_damage_section sc_resupply_02 "panel" 100)
	(wake resupply_waypoint_02)
)

(script continuous resupply_waypoint_02
	(sleep_forever)
	(print "placing waypoint on resupply 02...")
	(sound_impulse_start sfx_blip NONE 1)
	(f_blip_object sc_resupply_02 blip_ordnance)
	(sleep_until (not (resupply_pod_test_weapon sc_resupply_02)) 5)
	(f_unblip_object sc_resupply_02)
)

;=============== Resupply 03 =======================================
(script continuous resupply_pod_03
	(sleep_forever)
	(sleep (random_range 5 15))
	(print "resupply pod 03...")
	(object_create dm_resupply_03)
	(begin_random_count 1
		(object_create_variant sc_resupply_03 "laser")
		(object_create_variant sc_resupply_03 "rocket")
		(object_create_variant sc_resupply_03 "sniper")
	)
	(sleep 1)
	(objects_attach dm_resupply_03 "" sc_resupply_03 "")
	(sleep 1)
	(device_set_position dm_resupply_03 1)
		(sleep_until (>= (device_get_position dm_resupply_03) 0.98) 1)
		(effect_new_on_object_marker fx\fx_library\pod_impacts\default\pod_impact_default_small.effect sc_resupply_03 "fx_impact")	
	(sleep_until (>= (device_get_position dm_resupply_03) 1) 1)
	(sleep 1)
	(objects_detach dm_resupply_03 sc_resupply_03)
	(object_destroy dm_resupply_03)
	(sleep (random_range 8 17))
	(object_damage_damage_section sc_resupply_03 "panel" 100)
	(wake resupply_waypoint_03)
)

(script continuous resupply_waypoint_03
	(sleep_forever)
	(print "placing waypoint on resupply 03...")
	(sound_impulse_start sfx_blip NONE 1)
	(f_blip_object sc_resupply_03 blip_ordnance)
	(sleep_until (not (resupply_pod_test_weapon sc_resupply_03)) 5)
	(f_unblip_object sc_resupply_03)
)

;=============== Resupply 04 =======================================
(script continuous resupply_pod_04
	(sleep_forever)
	(sleep (random_range 5 15))
	(print "resupply pod 04...")
	(object_create dm_resupply_04)
	(begin_random_count 1
		(object_create_variant sc_resupply_04 "laser")
		(object_create_variant sc_resupply_04 "rocket")
		(object_create_variant sc_resupply_04 "sniper")
	)
	(sleep 1)
	(objects_attach dm_resupply_04 "" sc_resupply_04 "")
	(sleep 1)
	(device_set_position dm_resupply_04 1)
		(sleep_until (>= (device_get_position dm_resupply_04) 0.98) 1)
		(effect_new_on_object_marker fx\fx_library\pod_impacts\default\pod_impact_default_small.effect sc_resupply_04 "fx_impact")	
	(sleep_until (>= (device_get_position dm_resupply_04) 1) 1)
	(sleep 1)
	(objects_detach dm_resupply_04 sc_resupply_04)
	(object_destroy dm_resupply_04)
	(sleep (random_range 8 17))
	(object_damage_damage_section sc_resupply_04 "panel" 100)
	(wake resupply_waypoint_04)
)

(script continuous resupply_waypoint_04
	(sleep_forever)
	(print "placing waypoint on resupply 04...")
	(sound_impulse_start sfx_blip NONE 1)
	(f_blip_object sc_resupply_04 blip_ordnance)
	(sleep_until (not (resupply_pod_test_weapon sc_resupply_04)) 5)
	(f_unblip_object sc_resupply_04)
)


;=============== Resupply 05 =======================================
(script continuous resupply_pod_05
	(sleep_forever)
	(sleep (random_range 5 15))
	(print "resupply pod 05...")
	(object_create dm_resupply_05)
	(begin_random_count 1
		(object_create_variant sc_resupply_05 "laser")
		(object_create_variant sc_resupply_05 "rocket")
		(object_create_variant sc_resupply_05 "sniper")
	)
	(sleep 1)
	(objects_attach dm_resupply_05 "" sc_resupply_05 "")
	(sleep 1)
	(device_set_position dm_resupply_05 1)
		(sleep_until (>= (device_get_position dm_resupply_05) 0.98) 1)
		(effect_new_on_object_marker fx\fx_library\pod_impacts\default\pod_impact_default_small.effect sc_resupply_05 "fx_impact")	
	(sleep_until (>= (device_get_position dm_resupply_05) 1) 1)
	(sleep 1)
	(objects_detach dm_resupply_05 sc_resupply_05)
	(object_destroy dm_resupply_05)
	(sleep (random_range 8 17))
	(object_damage_damage_section sc_resupply_05 "panel" 100)
	(wake resupply_waypoint_05)
)

(script continuous resupply_waypoint_05
	(sleep_forever)
	(print "placing waypoint on resupply 05...")
	(sound_impulse_start sfx_blip NONE 1)
	(f_blip_object sc_resupply_05 blip_ordnance)
	(sleep_until (not (resupply_pod_test_weapon sc_resupply_05)) 5)
	(f_unblip_object sc_resupply_05)
)


;=============== Resupply 06 =======================================
(script continuous resupply_pod_06
	(sleep_forever)
	(sleep (random_range 5 15))
	(print "resupply pod 06...")
	(object_create dm_resupply_06)
	(begin_random_count 1
		(object_create_variant sc_resupply_06 "laser")
		(object_create_variant sc_resupply_06 "rocket")
		(object_create_variant sc_resupply_06 "sniper")
	)
	(sleep 1)
	(objects_attach dm_resupply_06 "" sc_resupply_06 "")
	(sleep 1)
	(device_set_position dm_resupply_06 1)
		(sleep_until (>= (device_get_position dm_resupply_06) 0.98) 1)
		(effect_new_on_object_marker fx\fx_library\pod_impacts\default\pod_impact_default_small.effect sc_resupply_06 "fx_impact")	
	(sleep_until (>= (device_get_position dm_resupply_06) 1) 1)
	(sleep 1)
	(objects_detach dm_resupply_06 sc_resupply_06)
	(object_destroy dm_resupply_06)
	(sleep (random_range 8 17))
	(object_damage_damage_section sc_resupply_06 "panel" 100)
	(wake resupply_waypoint_06)
)

(script continuous resupply_waypoint_06
	(sleep_forever)
	(print "placing waypoint on resupply 06...")
	(sound_impulse_start sfx_blip NONE 1)
	(f_blip_object sc_resupply_06 blip_ordnance)
	(sleep_until (not (resupply_pod_test_weapon sc_resupply_06)) 5)
	(f_unblip_object sc_resupply_06)
)


;=============== Resupply 07 =======================================
(script continuous resupply_pod_07
	(sleep_forever)
	(sleep (random_range 5 15))
	(print "resupply pod 07...")
	(object_create dm_resupply_07)
	(begin_random_count 1
		(object_create_variant sc_resupply_07 "laser")
		(object_create_variant sc_resupply_07 "rocket")
		(object_create_variant sc_resupply_07 "sniper")
	)
	(sleep 1)
	(objects_attach dm_resupply_07 "" sc_resupply_07 "")
	(sleep 1)
	(device_set_position dm_resupply_07 1)
		(sleep_until (>= (device_get_position dm_resupply_07) 0.98) 1)
		(effect_new_on_object_marker fx\fx_library\pod_impacts\default\pod_impact_default_small.effect sc_resupply_07 "fx_impact")	
	(sleep_until (>= (device_get_position dm_resupply_07) 1) 1)
	(sleep 1)
	(objects_detach dm_resupply_07 sc_resupply_07)
	(object_destroy dm_resupply_07)
	(sleep (random_range 8 17))
	(object_damage_damage_section sc_resupply_07 "panel" 100)
	(wake resupply_waypoint_07)
)

(script continuous resupply_waypoint_07
	(sleep_forever)
	(print "placing waypoint on resupply 07...")
	(sound_impulse_start sfx_blip NONE 1)
	(f_blip_object sc_resupply_07 blip_ordnance)
	(sleep_until (not (resupply_pod_test_weapon sc_resupply_07)) 5)
	(f_unblip_object sc_resupply_07)
)


;=============== Resupply 08 =======================================
(script continuous resupply_pod_08
	(sleep_forever)
	(sleep (random_range 5 15))
	(print "resupply pod 08...")
	(object_create dm_resupply_08)
	(begin_random_count 1
		(object_create_variant sc_resupply_08 "laser")
		(object_create_variant sc_resupply_08 "rocket")
		(object_create_variant sc_resupply_08 "sniper")
	)
	(sleep 1)
	(objects_attach dm_resupply_08 "" sc_resupply_08 "")
	(sleep 1)
	(device_set_position dm_resupply_08 1)
		(sleep_until (>= (device_get_position dm_resupply_08) 0.98) 1)
		(effect_new_on_object_marker fx\fx_library\pod_impacts\default\pod_impact_default_small.effect sc_resupply_08 "fx_impact")	
	(sleep_until (>= (device_get_position dm_resupply_08) 1) 1)
	(sleep 1)
	(objects_detach dm_resupply_08 sc_resupply_08)
	(object_destroy dm_resupply_08)
	(sleep (random_range 8 17))
	(object_damage_damage_section sc_resupply_08 "panel" 100)
	(wake resupply_waypoint_08)
)

(script continuous resupply_waypoint_08
	(sleep_forever)
	(print "placing waypoint on resupply 08...")
	(sound_impulse_start sfx_blip NONE 1)
	(f_blip_object sc_resupply_08 blip_ordnance)
	(sleep_until (not (resupply_pod_test_weapon sc_resupply_08)) 5)
	(f_unblip_object sc_resupply_08)
)


;=============== Resupply 09 =======================================
(script continuous resupply_pod_09
	(sleep_forever)
	(sleep (random_range 5 15))
	(print "resupply pod 09...")
	(object_create dm_resupply_09)
	(begin_random_count 1
		(object_create_variant sc_resupply_09 "laser")
		(object_create_variant sc_resupply_09 "rocket")
		(object_create_variant sc_resupply_09 "sniper")
	)
	(sleep 1)
	(objects_attach dm_resupply_09 "" sc_resupply_09 "")
	(sleep 1)
	(device_set_position dm_resupply_09 1)
		(sleep_until (>= (device_get_position dm_resupply_09) 0.98) 1)
		(effect_new_on_object_marker fx\fx_library\pod_impacts\default\pod_impact_default_small.effect sc_resupply_09 "fx_impact")	
	(sleep_until (>= (device_get_position dm_resupply_09) 1) 1)
	(sleep 1)
	(objects_detach dm_resupply_09 sc_resupply_09)
	(object_destroy dm_resupply_09)
	(sleep (random_range 8 17))
	(object_damage_damage_section sc_resupply_09 "panel" 100)
	(wake resupply_waypoint_09)
)

(script continuous resupply_waypoint_09
	(sleep_forever)
	(print "placing waypoint on resupply 09...")
	(sound_impulse_start sfx_blip NONE 1)
	(f_blip_object sc_resupply_09 blip_ordnance)
	(sleep_until (not (resupply_pod_test_weapon sc_resupply_09)) 5)
	(f_unblip_object sc_resupply_09)
)
