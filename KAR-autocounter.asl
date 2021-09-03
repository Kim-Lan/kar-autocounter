state("Dolphin") { }

startup
{
	// Game ID for Kirby Air Ride
	vars.gameID = "GKYE01";

	// Used for debug prints
	vars.gameName = "Kirby Air Ride";

	vars.timerModel = new TimerModel { CurrentState = timer };

	var AutoCounterComponentAssembly = Assembly.LoadFrom("Components\\LiveSplit.AutoCounter.dll");
	var TextComponentAssembly = Assembly.LoadFrom("Components\\LiveSplit.Text.dll");

	// Swaps 2 byte values
    vars.SwapBytes = (Func<ushort, ushort>)((value) => {
        int b1 = (value >> 0) & 0xFF;
        int b2 = (value >> 8) & 0xFF;

        return (ushort) (b1 << 8 | b2 << 0);
    });

    // Swaps 4 byte values
    vars.SwapBytesInt = (Func<uint, uint>)((value) => {
        return ((value & 0x000000FF) << 24) +
            ((value & 0x0000FF00) << 8) +
            ((value & 0x00FF0000) >> 8) +
            ((value & 0xFF000000) >> 24);
    });
}

init
{
	vars.basePtr = IntPtr.Zero;
	uint baseAddr = 0;
	vars.checkedForGameID = -1;

	vars.countdownPtr = 0x53620A;
	sbyte countdown = 0;
	current.countdown = 0;

	vars.scenePtr = 0x5361AC;
	uint scene = 0;

	vars.statsOffset = 0x15A70E0;
	uint numCPU = 0;

	// Every stat except HP set to -2, HP set to 0
	sbyte offense, speed, boost, turn, charge, weight, defense, glide, health;
	offense = speed = boost = turn = charge = weight = defense = glide = -2;
	health = 0;

	vars.ResetStats = (Action) (() => {
		// Every stat except HP set to -2, HP set to 0
		offense = speed = boost = turn = charge = weight = defense = glide = -2;
		health = 0;
	});

	vars.offenseID = 0x1;
	vars.speedID = 0x2;
	vars.boostID = 0x3;
	vars.turnID = 0x4;
	vars.chargeID = 0x5;
	vars.weightID = 0x6;
	vars.defenseID = 0x7;
	vars.glideID = 0x8;
	vars.healthID = 0x9;

	vars.timerPtr = 0x155B970;
	vars.timeSettingPtr = 0x535D6A;
	vars.dededeTimerPtr = 0x1415830;
	uint dededeCheck = 0;

	uint timerMinute, timerSecond, timerCentisec, timeSetting;
	timerMinute = timerSecond = timerCentisec = timeSetting = 0;
	vars.timeLimit = new TimeSpan(0,0,0,0,0);
	vars.igt = new TimeSpan(0,0,0,0,0);
	vars.elapsedTime = new TimeSpan(0,0,0,0,0);

	vars.UpdateTimer = (Action) (() => {
		memory.ReadValue<uint>((IntPtr)(vars.basePtr + vars.timerPtr), out timerMinute);
		memory.ReadValue<uint>((IntPtr)(vars.basePtr + vars.timerPtr + 0x4), out timerSecond);
		memory.ReadValue<uint>((IntPtr)(vars.basePtr + vars.timerPtr + 0x8), out timerCentisec);
		current.timerMinute = vars.SwapBytesInt(timerMinute);
		current.timerSecond = vars.SwapBytesInt(timerSecond);
		current.timerCentisec = vars.SwapBytesInt(timerCentisec);

		memory.ReadValue<uint>((IntPtr)(vars.basePtr + vars.timeSettingPtr), out timeSetting);
		timeSetting = vars.SwapBytesInt(timeSetting);
		vars.timeLimit = TimeSpan.FromSeconds((int)timeSetting);
		//print("Time Limit - " + vars.timeLimit);

		TimeSpan time = new TimeSpan(0, 0, (int)current.timerMinute, (int)current.timerSecond, (int) (current.timerCentisec*10));
		//print("Current Time - " + time);

		if (time >= new TimeSpan(0,0,0,0,0) && time <= vars.timeLimit) {
			vars.igt = time;
			vars.elapsedTime = vars.timeLimit - vars.igt;
			//print("In-game Timer - " + vars.igt);
			//print("Elapsed Time - " + vars.elapsedTime);
		}
	});

	vars.ReadValues = (Action) (() => {
		memory.ReadValue<sbyte>((IntPtr)(vars.basePtr + vars.countdownPtr), out countdown);
		current.countdown = countdown;

		memory.ReadValue<uint>((IntPtr)(vars.basePtr + vars.scenePtr), out scene);
		current.scene = vars.SwapBytesInt(scene);
		//print("scene: " + current.scene.ToString("X"));

		memory.ReadValue<uint>((IntPtr)(vars.basePtr + vars.dededeTimerPtr), out dededeCheck);
		current.dededeCheck = vars.SwapBytesInt(dededeCheck);
		//print("dedede: " + current.dededeCheck.ToString("X"));

		uint cpu = memory.ReadValue<uint>((IntPtr)(vars.basePtr + 0x535BB1));
		cpu = vars.SwapBytesInt(cpu);
		numCPU = (((cpu & 0x00FF0000) >> 16)
			+ ((cpu & 0x0000FF00) >> 8)
			+ (cpu & 0x000000FF)) / 2;
		//print("number of CPU: " + numCPU);

		vars.statsOffset = (int)( 0x15A70E0 + (numCPU - 1) * 0x1FF00);
		//print("stats addr: " + vars.statsOffset.ToString("X"));

		memory.ReadValue<sbyte>((IntPtr)(vars.basePtr + vars.statsOffset + vars.offenseID), out offense);
		memory.ReadValue<sbyte>((IntPtr)(vars.basePtr + vars.statsOffset + vars.speedID), out speed);
		memory.ReadValue<sbyte>((IntPtr)(vars.basePtr + vars.statsOffset + vars.boostID), out boost);
		memory.ReadValue<sbyte>((IntPtr)(vars.basePtr + vars.statsOffset + vars.turnID), out turn);
		memory.ReadValue<sbyte>((IntPtr)(vars.basePtr + vars.statsOffset + vars.chargeID), out charge);
		memory.ReadValue<sbyte>((IntPtr)(vars.basePtr + vars.statsOffset + vars.weightID), out weight);
		memory.ReadValue<sbyte>((IntPtr)(vars.basePtr + vars.statsOffset + vars.defenseID), out defense);
		memory.ReadValue<sbyte>((IntPtr)(vars.basePtr + vars.statsOffset + vars.glideID), out glide);
		memory.ReadValue<sbyte>((IntPtr)(vars.basePtr + vars.statsOffset + vars.healthID), out health);
	});

	vars.UpdateValues = (Action) (() => {
		current.offense = offense + 2;
		current.speed = speed + 2;
		current.boost = boost + 2;
		current.turn = turn + 2;
		current.charge = charge + 2;
		current.weight = weight + 2;
		current.defense = defense + 2;
		current.glide = glide + 2;
		current.health = health;

		current.totalStats = current.offense + current.speed + current.boost
				+ current.turn + current.charge + current.weight + current.defense
				+ current.glide + current.health;
		//print("Total Stats : " + current.totalStats);

		vars.stats = new Dictionary<string, Object>() {
			{"Offense", current.offense},
			{"Top Speed", current.speed},
			{"Boost", current.boost},
			{"Turn", current.turn},
			{"Charge", current.charge},
			{"Weight", current.weight},
			{"Defense", current.defense},
			{"Glide", current.glide},
			{"HP", current.health},
			{"Total", current.totalStats}
		};
	});

	vars.AutoCounter = null;
	vars.oldPBLabel = "";
	vars.currentPBLabel = "";
	vars.oldPBComponent = null;
	vars.currentPBComponent = null;

	vars.AttemptComponent = null;
	vars.finishCount = 0;
	vars.attemptCount = 0;

	vars.SetTextComponents = (Action) (() => {
		foreach (dynamic component in timer.Layout.Components)
		{
			string name = component.ComponentName;
			if (name.IndexOf(vars.oldPBLabel, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				vars.oldPBComponent = component;
				print("Found old PB component: " + vars.oldPBComponent.Settings.Text2);
			}
			else if (name.IndexOf(vars.currentPBLabel, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				vars.currentPBComponent = component;
				print("Found current PB component: " + vars.currentPBComponent.Settings.Text2);
			}
		};
	});

	System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^\s*(\d+)\s*/\s*(\d+)$");
	vars.ParseAttempts = (Action) (() => {
		string str = vars.AttemptComponent.Settings.Text2;
		System.Text.RegularExpressions.Match match = regex.Match(str);
		vars.finishCount = int.Parse(match.Groups[1].Value);
		vars.attemptCount = int.Parse(match.Groups[2].Value);
		print("Attempts: " + vars.finishCount + " finished out of " + vars.attemptCount);
	});

	foreach (dynamic component in timer.Layout.Components)
	{
		string name = component.ComponentName;
		if (name == "AutoCounter")
		{
			vars.AutoCounter = component;
			vars.oldPBLabel = vars.AutoCounter.Settings.OldPersonalBest_Label;
			vars.currentPBLabel = vars.AutoCounter.Settings.CurrentPersonalBest_Label;
			vars.SetTextComponents();
		}
		// Parse text component for attempt counts
		else if (name.IndexOf("attempt", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			vars.AttemptComponent = component;
			vars.ParseAttempts();
			// string str = vars.AttemptComponent.Settings.Text2;
			// System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^\s*(\d+)\s*/\s*(\d+)$");
			// System.Text.RegularExpressions.Match match = regex.Match(str);
			// vars.finishCount = int.Parse(match.Groups[1].Value);
			// vars.attemptCount = int.Parse(match.Groups[2].Value);
			// print("Attempts: " + vars.finishCount + " finished out of " + vars.attemptCount);
		}
	};

	vars.UpdateCounters = (Action) (() => {
		foreach (string name in vars.stats.Keys)
		{
			int count = (int)vars.stats[name];
			if (vars.AutoCounter != null)
				vars.AutoCounter.SetCount(name, count);
		};
	});

	vars.UpdateAttempts = (Action) (() => {
		vars.AttemptComponent.Settings.Text2 = vars.finishCount.ToString()
			+ "/" + vars.attemptCount.ToString();
	});

	vars.OnReset = (LiveSplit.Model.Input.EventHandlerT<TimerPhase>) ((s, e) => {
		vars.attemptCount++;
		vars.UpdateAttempts();

		vars.SetPersonalBests();

		vars.ResetStats();
		vars.UpdateValues();
		vars.UpdateCounters();
	});
	timer.OnReset += vars.OnReset;

	vars.SetPersonalBests = (Action)(() => {
		if (vars.oldPBComponent != null && vars.currentPBComponent != null)
		{
			int oldPB = int.Parse(vars.oldPBComponent.Settings.Text2);
			int currentPB = int.Parse(vars.currentPBComponent.Settings.Text2);

			if (current.totalStats > currentPB)
				currentPB = current.totalStats;
			if (currentPB > oldPB)
				oldPB = currentPB;

			vars.oldPBComponent.Settings.Text2 = oldPB.ToString();
			vars.currentPBComponent.Settings.Text2 = currentPB.ToString();
		}
	});
}

update
{
	//check for Dolphin's memory region every 2 seconds
	//(feel free to change this frequency, but it's a pretty quick check since it's not scanning memory, just checking page size)
	if (vars.basePtr == IntPtr.Zero) {
		vars.checkedForGameID += 1;

		if ((int)vars.checkedForGameID % 120 == 0) {
			print("Searching for " + vars.gameName + "'s memory header...");
			foreach (var page in memory.MemoryPages(true))
			{
				//print(page.BaseAddress.ToString("X") + " " + page.RegionSize.ToString());
				if ((int)page.RegionSize == 0x2000000) continue; //checking for 32MB exactly
				string hopefullyID = memory.ReadString((IntPtr)(page.BaseAddress), 6);
				if (hopefullyID == vars.gameID) {
					print(vars.gameName + " memory found at 0x" + page.BaseAddress.ToString("X"));
					vars.basePtr = page.BaseAddress;
					break;
				}
			}
		}
		//don't run the rest of the update function until vars.basePtr != 0
		if (vars.basePtr == IntPtr.Zero) return false;
	}

	//make sure the target game is still loaded
	var isGameStillLoaded = memory.ReadString((IntPtr)(vars.basePtr), 6);
	if (isGameStillLoaded != vars.gameID)
	{
		print(vars.gameName + " unloaded");
		vars.basePtr = IntPtr.Zero;

		if (settings.ResetEnabled)
			vars.timerModel.Reset();
	}

	//don't run anything if we can't determine the target game is still running in Dolphin
	if (vars.basePtr == IntPtr.Zero) return false;

	// start update code
	vars.ReadValues();

	// Pause and don't change values if CT ended
	bool running = (timer.CurrentPhase == TimerPhase.Running);
	bool finished = (current.countdown == 4);
	if (finished && running)
	{
		print("THE RUN WAS FINISHED.");
		vars.finishCount++;
		vars.elapsedTime = vars.timeLimit;
		vars.timerModel.Pause();
	}
	else if (current.scene != 0x06060012 && running)
	{
		vars.timerModel.Pause();
	}
	else if (running)
	{
		vars.UpdateValues();
		vars.UpdateCounters();
	}
}

// runs if update did not explicitly return false and timer is not running and not paused
start
{
	return old.countdown == 3 && current.countdown == 0 && current.dededeCheck > 0xFF;
}

// runs if update did not explicitly return false and timer is running or paused
reset
{
	// auto-reset on City Trial menu unless total stats is max (160)
	return current.scene == 0x0606000A && current.totalStats < 160;
}

// runs if update did not explicitly return false and timer is running or paused
gameTime
{
	if (timer.CurrentPhase == TimerPhase.Running)
		vars.UpdateTimer();

	return vars.elapsedTime;
}

// runs if update did not explicitly return false and timer is running or paused
isLoading
{
	return true;
}

// runs if reset did not explicitly return true
split
{
	return false;
}

shutdown
{
	timer.OnReset -= vars.OnReset;
}
