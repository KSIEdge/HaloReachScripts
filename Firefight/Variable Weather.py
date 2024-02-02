; =================================================================================================
; ===== RAIN ======================================================================================
; =================================================================================================

(global short s_rain_force -1)
(global short s_rain_force_last -1)

(script dormant survival_rain_control
	(wake survival_rain) 
	(sleep_until
		(begin
			(sleep_until (<= (survival_mode_wave_get) 0))
			(set s_rain_force 4)
				(sleep (* 30 10))

			(sleep_until (> (survival_mode_wave_get) 0))
			(set s_rain_force 5)
				(sleep (* 30 10))

			(sleep_until (>= (survival_mode_wave_get) 4))
			(set s_rain_force 7)
				(sleep (* 30 10))
		FALSE)
	5)
)

(script dormant survival_rain

	(sleep_until
		(begin

			(if (not (= s_rain_force s_rain_force_last))
				(begin
				
					(print "changing rain")
					(set s_rain_force_last s_rain_force)

					(cond
						((= s_rain_force 1)
							(begin
								(print "no rain")
								(weather_animate_force no_rain 1 (random_range 5 15))		
							)
						)
						((= s_rain_force 2)
							(begin
								(print "light change 1/2")
								(weather_animate_force no_rain 1 (random_range 5 15))	
								(set s_rain_force 3)
								(sleep (random_range (* 30 20)(* 30 60)))
							)
						)
						((= s_rain_force 3)
							(begin
								(print "light change 2/2")
								(weather_animate_force light_rain 1 (random_range 5 15))		
								(set s_rain_force 2)
								(sleep (random_range (* 30 20)(* 30 60)))
							)
						)
						((= s_rain_force 4)
							(begin
								(print "medium")
								(weather_animate_force light_rain .5 (random_range 5 15))		
							)
						)
						((= s_rain_force 5)
							(begin
								(print "medium change 1/2")
								(weather_animate_force light_rain 1 (random_range 5 15))	
								(set s_rain_force 6)
								(sleep (random_range (* 30 20)(* 30 60)))
							)
						)
						((= s_rain_force 6)
							(begin
								(print "medium change 2/2")
								(weather_animate_force heavy_rain .5 (random_range 5 15))		
								(set s_rain_force 5)
								(sleep (random_range (* 30 20)(* 30 60)))
							)
						)
						((= s_rain_force 7)
							(begin
								(print "heavy")
								(weather_animate_force heavy_rain 1 (random_range 5 15))		
							)
						)
					)

				)
			)

		FALSE)
	5)

)
