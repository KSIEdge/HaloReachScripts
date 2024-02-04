; ================================================================================================================
; ======== WRAITH SCRIPTS ========================================================================================
; ================================================================================================================	

(script command_script cs_abort
	(sleep 1)
)

(script command_script cs_wraith_shoot

	(cs_run_command_script sq_sur_wraith_01/gunner cs_abort)	
	(cs_run_command_script sq_sur_wraith_02/gunner cs_abort)	
	(cs_enable_moving TRUE)
	(sleep (* 30 10))
	(sleep_until
		(begin
			(begin_random
				(begin
					(sleep (random_range 60 150))
					(cs_shoot_point TRUE ps_wraith/p0)
				)
				(begin
					(sleep (random_range 60 150))
					(cs_shoot_point TRUE ps_wraith/p1)
				)
				(begin
					(sleep (random_range 60 150))
					(cs_shoot_point TRUE ps_wraith/p2)
				)
				(begin
					(sleep (random_range 60 150))
					(cs_shoot_point TRUE ps_wraith/p3)
				)
			)
		FALSE)
	)
