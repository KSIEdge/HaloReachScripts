; -------------------------------------------------------------------------------------------------
; WEATHER
; -------------------------------------------------------------------------------------------------
(global boolean b_weather_debug				false)
(global boolean b_rain_is_active 			false)
(global boolean b_rain_thunderclap			false)
(global boolean b_rain_always_on			false)
(global boolean b_rain_change_state			false)
(global short s_rain_min_on_time 			60)
(global short s_rain_max_on_time 			180)
(global short s_rain_min_off_time 			30)
(global short s_rain_max_off_time 			45)
(global short s_rain_min_ramp_up_time 		2)
(global short s_rain_max_ramp_up_time 		10)
(global short s_rain_min_ramp_down_time 	6)
(global short s_rain_max_ramp_down_time 	12)
(global short s_rain_min_lightning_delay 	5)
(global short s_rain_max_lightning_delay 	20)
(global short s_rain_min_thunder_delay 		1)
(global short s_rain_max_thunder_delay 		3)
(global real r_rain_min_force				1)
(global real r_rain_max_force				1)

(global ai ai_to_deafen NONE)
; -------------------------------------------------------------------------------------------------
(script static void weather_set_theme_default
	(if debug (print "weather: default theme starting"))
	(set b_rain_thunderclap			false)
	(set s_rain_min_on_time 		60)
	(set s_rain_max_on_time 		180)
	(set s_rain_min_off_time 		30)
	(set s_rain_max_off_time 		45)
	(set s_rain_min_ramp_up_time 	2)
	(set s_rain_max_ramp_up_time 	10)
	(set s_rain_min_ramp_down_time 	6)
	(set s_rain_max_ramp_down_time 	12)
	(set s_rain_min_lightning_delay 5)
	(set s_rain_max_lightning_delay 20)
	(set s_rain_min_thunder_delay 	1)
	(set s_rain_max_thunder_delay 	3)
	(set r_rain_min_force			1)
	(set r_rain_max_force			1)
)

(script static void weather_set_theme_storm
	(if debug (print "weather: storm theme starting"))
	(set b_rain_thunderclap			true)
	(set s_rain_min_on_time 		300)
	(set s_rain_max_on_time 		600)
	(set s_rain_min_off_time 		60)
	(set s_rain_max_off_time 		120)
	(set s_rain_min_ramp_up_time 	15)
	(set s_rain_max_ramp_up_time 	45)
	(set s_rain_min_ramp_down_time 	50)
	(set s_rain_max_ramp_down_time 	120)
	(set s_rain_min_lightning_delay 3)
	(set s_rain_max_lightning_delay 15)
	(set s_rain_min_thunder_delay 	1)
	(set s_rain_max_thunder_delay 	2)
	(set r_rain_min_force			1)
	(set r_rain_max_force			1)
)

(script static void weather_set_theme_light
	(if debug (print "weather: light rain theme starting"))
	(set b_rain_thunderclap			false)
	(set s_rain_min_on_time 		80)
	(set s_rain_max_on_time 		180)
	(set s_rain_min_off_time 		120)
	(set s_rain_max_off_time 		120)
	(set s_rain_min_ramp_up_time 	15)
	(set s_rain_max_ramp_up_time 	45)
	(set s_rain_min_ramp_down_time 	50)
	(set s_rain_max_ramp_down_time 	80)
	(set s_rain_min_lightning_delay 20)
	(set s_rain_max_lightning_delay 45)
	(set s_rain_min_thunder_delay 	3)
	(set s_rain_max_thunder_delay 	6)
	(set r_rain_min_force			0.2)
	(set r_rain_max_force			0.6)
)

; -------------------------------------------------------------------------------------------------

(script startup weather_rain
	(weather_animate_force off 1 0)
	(sleep_until
		(begin
			(sleep_range_seconds s_rain_min_off_time s_rain_max_off_time)
			(weather_rain_start)
			(sleep_range_seconds s_rain_min_on_time s_rain_max_on_time)
			(weather_rain_stop)
		0)
	1)
)

(script static void weather_rain_start
	(if b_weather_debug (print "weather: rain starting..."))
	(weather_animate_force 
		light_rain 
		(real_random_range r_rain_min_force r_rain_max_force)
		(random_range s_rain_min_ramp_up_time s_rain_max_ramp_up_time)
	)
	(set b_rain_is_active true)
)

(script static void weather_rain_stop
	(if b_weather_debug (print "weather: rain stopping..."))
	(weather_animate_force off 1 (random_range s_rain_min_ramp_down_time s_rain_max_ramp_down_time))
	(set b_rain_is_active false)
)

(script startup weather_lightning
	(branch 
		(= b_mission_complete true) (branch_abort)
	)
	
	(weather_lightning_flash)
	(sleep_until (= b_ovr_started true))
	(sleep_until
		(begin
			(sleep_range_seconds s_rain_min_lightning_delay s_rain_max_lightning_delay)
			(weather_lightning_flash)
			;*
			(if b_rain_is_active
				(sleep_range_seconds s_rain_min_thunder_delay s_rain_max_thunder_delay)
				(sleep_range_seconds (* 3 s_rain_min_thunder_delay) (* 3 s_rain_max_thunder_delay)))
			*;
			(sleep_range_seconds s_rain_min_thunder_delay s_rain_max_thunder_delay)
			(weather_thunder_clap)
		0)
	60)
)

(script static void weather_lightning_flash
	(if b_weather_debug (print "weather: flash!"))
	(interpolator_start lightning))
	
(script static void weather_thunder_clap
	(if b_rain_thunderclap
		(begin
			(if b_weather_debug (print "weather: thunder clap!"))
			(sound_impulse_start sound\levels\solo\weather\thunder_claps.sound NONE 1)
			(ai_thunder_deafen ai_to_deafen true)
			(sleep (* 30 2.5))
			(ai_thunder_deafen ai_to_deafen false)
		)	
		(begin
			(if b_weather_debug (print "weather: rolling thunder..."))		
			(sound_impulse_start sound\levels\solo\weather\rain\details\thunder.sound NONE 1)
		)
	)
)

(script static void (ai_thunder_deafen (ai actors) (boolean deafen))
	(if deafen
		(begin
			(if (< (ai_combat_status actors) 4)
				(begin
					(if b_weather_debug (print "deafening the ai..."))
					(ai_set_blind actors true)
					(ai_set_deaf actors true)))
		)
		
		(begin
			(if b_weather_debug (print "ai now have their vision and hearing again..."))
			(ai_set_blind actors false)
			(ai_set_deaf actors false)
		)
	)
)
