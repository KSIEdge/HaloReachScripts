============================================================================
[extras_gate]
	flags: gate
	movement: run (alert)
	squad group filter: gr_survival_extras
	
[cov_drop_follow
		flags: magic player sight
		
[sniper01_interior (volume_test_object tv_interior (ai_get_object sq_sur_sniper_01/sniper_01))
		flags: magic player sight
		inhibit groups: retreat, vehicles, beserk
		movement: run (alert)
		squad group filter: gr_survival_sniper_01
		
[sniper02_interior (volume_test_object tv_interior (ai_get_object sq_sur_sniper_02/sniper_02))
	...
		
[sniper_01
	attitude: defensive	
		flags: magic player sight
		inhibit groups: retreat, beserk
		movement: run (alert)
		squad group filter: gr_survival_sniper_01
		
[sniper_02
	...

[wraith_gate]
		flags: gate, ignore fronts, don't generate front
		movement: run (alert)
		squad group filter: gr_survival_wraiths
		
	[wraith_01
			flags: ignore fronts, don't generate front
			command script: cs_abort
			movement: run (alert)
			squad group filter: gr_survival_wraith_01
			
		[wraith_01_shoot (not (volume_test_players tv_wraith_01))
				flags: ignore fronts, don't generate front
				command script: cs_wraith_shoot
				movement: run (alert)
				squad group filter: gr_survival_wraith_01
			
	[wraith_02
		...
		
[ghost_gate]
		flags: gate, ignore fronts, don't generate front
		movement: run (alert)
		squad group filter: gr_survival_ghosts
		
	[ghosts
		attitude: aggresive
			movement: run (alert)

[extras_backup
		flags: magic player sight
		inhibit groups: retreat, beserk
		movement: walk (idle)
		squad group filter: gr_survival_snipers

============================================================================

[remaining
		flags: magic player sight
		inhibit groups: cover, vehicles
		movement: run (alert)
		follow: player front
		follow radius: 10
		follow Z clamp: 1
		squad group filter: gr_survival_remaining
	
[hold_task
		movement: run (alert)
		squad group filter: gr_survival_all
	
[bonus_gate] b_sur_bonus_round_running
		flags: gate
		movement: run (alert)
		squad group filter: gr_survival_bonus
	
	[bonus_follow
			flags: magic player sight
			inhibit groups: cover, vehicles
			movement: run (alert)
			follow: player front
			follow radius: 10
			follow Z clamp: 1
			
============================================================================
[main_wave_gate]
		flags: gate
		inhibit groups: vehicles
		movement: run (alert)
		squad group filter: gr_survival_waves
		
	[hero_follow_gate]
		filter: leader (check box)
			flags: gate
			movement: run (alert)
			
		[hero_follow (<= (ai_task_count obj_survival/remaining) 3)
				flags: magic player sight
				inhibit groups: cover, vehicles
				movement: run (alert)
				follow: player front
				follow radius: 10
				follow Z clamp: 1
				exhaustion script: survival_hero_refresh_follow
	
	[follow_gate]
			flags: gate
			movement: run (alert)
			
		[main_follow (and (<= (ai_task_count obj_survival/hero_follow) 0) (<= (ai_task_count obj_survival/remaining) 3))
				flags: magic player sight
				inhibit groups: cover, vehicles
				movement: run (alert)
				follow: player front
				follow radius: 10
				follow Z clamp: 1
				exhaustion script: survival_refresh_follow

	[generator_gate] b_sur_generator_defense_active
			flags: gate
			inhibit groups: vehicles
			movement: run (alert)
			exhaustion script: survival_refresh_generator
			
		[gen0 b_sur_generator0_alive
				inhibit groups: vehicles
				movement: run (alert)
				player front radius: 5
				exhaustion script: survival_refresh_generator
				
		[gen1 b_sur_generator1_alive
			...
			
		[gen2 b_sur_generator2_alive
			...

[gen0_boost (and (> (ai_task_count obj_survival/gen0) 0) (>= (game_coop_player_count) 3))
		inhibit groups: vehicles
		movement: run (alert)

[gen1_boost (and (> (ai_task_count obj_survival/gen1) 0) (>= (game_coop_player_count) 3))
	...
	
[gen2_boost (and (> (ai_task_count obj_survival/gen2) 0) (>= (game_coop_player_count) 3))
	...
	
============================================================================
