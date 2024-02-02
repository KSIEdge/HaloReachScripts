;================================================ COVENANT SQUAD DROP CONTROL ============================================================

(global boolean g_sur_drop_spawn TRUE)
(global short g_sur_drop_limit 0)
(global short g_sur_drop_count 0)
(global short g_sur_drop_number 0)

(script dormant survival_drop_spawn
	; set the max number of drop pods at any one time 
	(cond
		((<= (game_coop_player_count) 4)		(set g_sur_drop_limit 1))
		((>= (game_coop_player_count) 5)		(set g_sur_drop_limit 2))
	)
	(sleep (* 30 60 2))

	; stays in this loop forever 
	(sleep_until
		(begin
			(sleep (* 30 180 1))
			(sleep_until 
				(and
					(<= (ai_living_count gr_survival_waves) 10)
					(<= (ai_living_count gr_survival_extras) 0)
					(= (survival_mode_current_wave_is_boss) FALSE)
					(= (survival_mode_current_wave_is_initial) FALSE)
				)
			)
			
			(print "cleaning up drop pods...")
			(sleep 1)
			(ai_erase sq_sur_drop_01)
			(ai_erase sq_sur_drop_02)
			(ai_erase sq_sur_drop_03)
			(ai_erase sq_sur_drop_04)
			(ai_erase sq_sur_drop_05)
				
			(begin_random_count g_sur_drop_limit
				(if g_sur_drop_spawn (wake drop_pod_01))
				(if g_sur_drop_spawn (wake drop_pod_02))
				(if g_sur_drop_spawn (wake drop_pod_03))
				(if g_sur_drop_spawn (wake drop_pod_04))
				(if g_sur_drop_spawn (wake drop_pod_05))
			)
			(sleep 1)
			(sleep_until (<= (ai_living_count gr_survival_extras) 0))
			(sleep 1)
			(set g_sur_drop_count 0)
			(set g_sur_drop_spawn TRUE)
			(sleep 1)
		FALSE)
	)
)
