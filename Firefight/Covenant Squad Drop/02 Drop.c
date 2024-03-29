;=============== Covenant Squad Drop 01 =======================================
(script continuous drop_pod_01
	(sleep_forever)
	(sleep (random_range 5 15))
	(print "squad pod 01...")
	(object_create dm_drop_01)
	(ai_place sq_sur_drop_01)
	(sleep 1)
	(set v_sur_drop_01 (ai_vehicle_get_from_spawn_point sq_sur_drop_01/driver))
	(sleep 1)
	(objects_attach dm_drop_01 "" v_sur_drop_01 "")
	(sleep 1)
	(device_set_position dm_drop_01 1)
	(sleep_until (>= (device_get_position dm_drop_01) 0.85) 1)
	(wake drop_blip_01)
	(unit_open v_sur_drop_01)
	(sleep 30)
	(print "kicking ai out of pod 01...")
	(vehicle_unload v_sur_drop_01 "")
	(sleep_until (>= (device_get_position dm_drop_01) 0.98) 1)
	(effect_new_on_object_marker fx\fx_library\pod_impacts\default\pod_impact_default_large.effect dm_drop_01 "fx_impact")
	(sleep_until (>= (device_get_position dm_drop_01) 1) 1)
	(sleep 1)
	(objects_detach dm_drop_01 v_sur_drop_01)
	(object_destroy dm_drop_01)
	(sleep 1)
	(set g_sur_drop_count (+ g_sur_drop_count 1))
	(if (>= g_sur_drop_count g_sur_drop_limit) (set g_sur_drop_spawn FALSE))
)

(script continuous drop_blip_01
	(sleep_forever)
	(print "blipping drop pod 01...")
	(f_survival_callout_dropship v_sur_drop_01)
)
