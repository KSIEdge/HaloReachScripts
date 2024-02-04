(wake spider_turret01)
(wake spider_turret02)
(wake spider_turret03)
(wake spider_turret04)
(global boolean b_spider_turret01 false)
(global boolean b_spider_turret02 false)
(global boolean b_spider_turret03 false)
(global boolean b_spider_turret04 false)
(global short s_total_turrets 0)

(script dormant spider_turret01
	(ai_place sq_spider_turret01)
	(ai_cannot_die sq_spider_turret01 true)
	(ai_disregard (ai_actors sq_spider_turret01/pilot) true)
	(ai_braindead sq_spider_turret01 TRUE)
	(sleep_until (> (device_get_position spider_turret_switch01) 0)1)
	(chud_track_object_with_priority (ai_vehicle_get sq_spider_turret01/pilot) 17)	
	(f_spider_turret sq_spider_turret01/pilot spider_turret_switch01)
)
(script dormant spider_turret02
	(ai_place sq_spider_turret02)
	(ai_cannot_die sq_spider_turret02 true)
	(ai_disregard (ai_actors sq_spider_turret02/pilot) true)
	(ai_braindead sq_spider_turret02 TRUE)
	(sleep_until (> (device_get_position spider_turret_switch02) 0)1)
	(chud_track_object_with_priority (ai_vehicle_get sq_spider_turret02/pilot) 18)	
	(f_spider_turret sq_spider_turret02/pilot spider_turret_switch02)
)
(script dormant spider_turret03
	(ai_place sq_spider_turret03)
	(ai_cannot_die sq_spider_turret03 true)
	(ai_disregard (ai_actors sq_spider_turret03/pilot) true)
	(ai_braindead sq_spider_turret03 TRUE)
	(sleep_until (> (device_get_position spider_turret_switch03) 0)1)
	(chud_track_object_with_priority (ai_vehicle_get sq_spider_turret03/pilot) 19)	
	(f_spider_turret sq_spider_turret03/pilot spider_turret_switch03)
)
(script dormant spider_turret04
	(ai_place sq_spider_turret04)
	(ai_cannot_die sq_spider_turret04 true)
	(ai_disregard (ai_actors sq_spider_turret04/pilot) true)
	(ai_braindead sq_spider_turret04 TRUE)
	(sleep_until (> (device_get_position spider_turret_switch04) 0)1)	
	(chud_track_object_with_priority (ai_vehicle_get sq_spider_turret04/pilot) 20)	
	(f_spider_turret sq_spider_turret04/pilot spider_turret_switch04)
)
(script dormant blip_spiders

	(f_blip_object spider_turret_switch03 blip_interface)
	(sleep 15)
	(device_set_power spider_turret_switch03 1)

	(f_blip_object spider_turret_switch02 blip_interface)
	(sleep 15)
	(device_set_power spider_turret_switch02 1)

	(f_blip_object spider_turret_switch01 blip_interface)
	(sleep 15)
	(device_set_power spider_turret_switch01 1)

	(f_blip_object spider_turret_switch04 blip_interface)
	(sleep 15)
	(device_set_power spider_turret_switch04 1)

)

(global boolean b_turret_switch_help FALSE)
(global short s_turret_online_count 0)
(global short s_turret_online_old -1)

(script static void (f_spider_turret (ai turret) (device switch)) 
	(sleep_until
		(begin
			(print "generator switch activated!")			
			(set s_turret_online_count (+ s_turret_online_count 1))
			(if (>= s_turret_online_count 4) (set b_turret_switch_help true))
			(device_set_power switch 0)
			(ai_object_set_team turret player)
			(unit_open (ai_vehicle_get_from_spawn_point turret))
			(object_can_take_damage (ai_vehicle_get_from_starting_location turret))
			(f_unblip_object switch)			
			(sleep 30)															
			(ai_braindead turret false)
			(ai_disregard (ai_actors turret) false)
			(sleep_until (< (object_get_health (ai_vehicle_get_from_starting_location turret)) 0)1)
			(object_cannot_take_damage (ai_vehicle_get_from_starting_location turret))
			(set s_turret_online_count (- s_turret_online_count 1))			
			(md_140_turret_offline)
			(print "too much damage turret01!")			
			(ai_braindead turret TRUE)
			(ai_disregard (ai_actors turret) true)
			(cond
				((= turret sq_spider_turret01/pilot)(chud_track_object (ai_vehicle_get sq_spider_turret01/pilot) FALSE ))
				((= turret sq_spider_turret02/pilot)(chud_track_object (ai_vehicle_get sq_spider_turret02/pilot) FALSE ))
				((= turret sq_spider_turret03/pilot)(chud_track_object (ai_vehicle_get sq_spider_turret03/pilot) FALSE ))
				((= turret sq_spider_turret04/pilot)(chud_track_object (ai_vehicle_get sq_spider_turret04/pilot) FALSE ))
			)
			(unit_close (ai_vehicle_get_from_spawn_point turret))
			(sleep 300)
			(device_set_position_immediate switch 0)
			(unit_set_current_vitality (ai_vehicle_get_from_starting_location turret) 400 0)
			(f_blip_object switch blip_interface)
			(device_set_power switch 1)
			(sleep_until (> (device_get_position switch) 0)1)
			(cond
				((= turret sq_spider_turret01/pilot)(chud_track_object_with_priority (ai_vehicle_get sq_spider_turret01/pilot) 17))
				((= turret sq_spider_turret02/pilot)(chud_track_object_with_priority (ai_vehicle_get sq_spider_turret02/pilot) 18))
				((= turret sq_spider_turret03/pilot)(chud_track_object_with_priority (ai_vehicle_get sq_spider_turret03/pilot) 19))
				((= turret sq_spider_turret04/pilot)(chud_track_object_with_priority (ai_vehicle_get sq_spider_turret04/pilot) 20))
			)			
		false)		
	1)
)

(script dormant spider_counter
	(sleep_until
		(begin
			(if (!= s_turret_online_old s_turret_online_count)
				(begin
					;(chud_show_screen_objective "")
					(set s_turret_online_old s_turret_online_count)
					(cond
						((= s_turret_online_count 0) 
							(begin
								(f_hud_training player0 ct_turret_online_0)
								(f_hud_training player1 ct_turret_online_0)
								(f_hud_training player2 ct_turret_online_0)
								(f_hud_training player3 ct_turret_online_0)
							)
						)
						((= s_turret_online_count 1) 
							(begin
								(f_hud_training player0 ct_turret_online_1)
								(f_hud_training player1 ct_turret_online_1)
								(f_hud_training player2 ct_turret_online_1)
								(f_hud_training player3 ct_turret_online_1)
							)
						)
						((= s_turret_online_count 2) 
							(begin
								(f_hud_training player0 ct_turret_online_2)
								(f_hud_training player1 ct_turret_online_2)
								(f_hud_training player2 ct_turret_online_2)
								(f_hud_training player3 ct_turret_online_2)
							)
						)
						((= s_turret_online_count 3) 
							(begin
								(f_hud_training player0 ct_turret_online_3)
								(f_hud_training player1 ct_turret_online_3)
								(f_hud_training player2 ct_turret_online_3)
								(f_hud_training player3 ct_turret_online_3)
							)
						)
						((= s_turret_online_count 4) 
							(begin
								(f_hud_training player0 ct_turret_online_4)
								(f_hud_training player1 ct_turret_online_4)
								(f_hud_training player2 ct_turret_online_4)
								(f_hud_training player3 ct_turret_online_4)
							)
						)																		
					)
				)
			)
		false)
	1)												
)

(script static void test_spiders
	(wake spider_turret01)
	(wake spider_turret02)
	(wake spider_turret03)
	(wake spider_turret04)
	(wake spider_turret_hud01)
	(wake spider_turret_hud02)
	(wake spider_turret_hud03)
	(wake spider_turret_hud04)	
	(sleep 10)
	(wake blip_turrets)
)

(script dormant kill_spiders
	(sleep_forever spider_turret01)
	(sleep_forever spider_turret02)
	(sleep_forever spider_turret03)
	(sleep_forever spider_turret04)			
	(f_unblip_object spider_turret_switch01)
	(f_unblip_object spider_turret_switch02)
	(f_unblip_object spider_turret_switch03)			
	(f_unblip_object spider_turret_switch04)
	(unblip_all)
	(chud_track_object (ai_vehicle_get sq_spider_turret01/pilot) FALSE )
	(chud_track_object (ai_vehicle_get sq_spider_turret02/pilot) FALSE )
	(chud_track_object (ai_vehicle_get sq_spider_turret03/pilot) FALSE )
	(chud_track_object (ai_vehicle_get sq_spider_turret04/pilot) FALSE )
)

(script command_script cs_stay_in_turret
	(cs_shoot true)
	(cs_enable_targeting true)
	(cs_enable_moving true)
	(cs_enable_looking true)
	(cs_abort_on_damage FALSE)	
	(cs_abort_on_alert FALSE)
	(sleep_until (<= (ai_living_count ai_current_actor) 0))
)
