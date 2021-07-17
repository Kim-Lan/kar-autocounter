state("dolphin", "5.0 stable") {
}

startup
{
    print("Start up.");

    var AutoCounterComponentAssembly = Assembly.LoadFrom("Components\\LiveSplit.AutoCounter.dll");

    vars.timerModel = new TimerModel { CurrentState = timer };

    // Swaps 2 byte values
    vars.SwapBytes = (Func<ushort, ushort>)((value) => {
        int b1 = (value >> 0) & 0xff;
        int b2 = (value >> 8) & 0xff;

        return (ushort) (b1 << 8 | b2 << 0);
    });

    // Swaps 4 byte values
    vars.SwapBytesInt = (Func<uint, uint>)((value) => {
        return ((value & 0x000000ff) << 24) +
            ((value & 0x0000ff00) << 8) +
            ((value & 0x00ff0000) >> 8) +
            ((value & 0xff000000) >> 24);
    });
}

init
{
    print("Initiating.");
    vars.basePtr = 0;

    // Update base pointer
    vars.UpdateSettings = (Action) (() => {
        vars.basePtr = memory.ReadValue<uint>(new IntPtr(0x11CDFD8));
        vars.statsBasePtr = 0x15E6EE0; // might need to change
    });

    sbyte offense = -2;
    sbyte speed = -2;
    sbyte boost = -2;
    sbyte turn = -2;
    sbyte charge = -2;
    sbyte weight = -2;
    sbyte defense = -2;
    sbyte glide = -2;
    sbyte health = 0;
    sbyte totalStats = 0;

    vars.ResetStats = (Action) (() => {
        offense = -2;
        speed = -2;
        boost = -2;
        turn = -2;
        charge = -2;
        weight = -2;
        defense = -2;
        glide = -2;
        health = 0;
        totalStats = 0;
    });

    uint timerMinute = 0;
    uint timerSecond = 0;
    uint timerCentisec = 0;

    uint timeSetting = 0;
    vars.timeLimit = null;
    vars.igt = null;
    vars.elapsedTime = new TimeSpan(0,0,0,0,0);
    vars.lastSplit = 0;

    vars.offensePtr = 0x1;
    vars.speedPtr = 0x2;
    vars.boostPtr = 0x3;
    vars.turnPtr = 0x4;
    vars.chargePtr = 0x5;
    vars.weightPtr = 0x6;
    vars.defensePtr = 0x7;
    vars.glidePtr = 0x8;
    vars.healthPtr = 0x9;

    vars.timerPtr = 0x155B970;
    vars.timeSettingPtr = 0x535D6A;

    vars.UpdateTimer = (Action) (() => {
        memory.ReadValue<uint>(new IntPtr(vars.basePtr + vars.timerPtr), out timerMinute);
        memory.ReadValue<uint>(new IntPtr(vars.basePtr + vars.timerPtr + 0x4), out timerSecond);
        memory.ReadValue<uint>(new IntPtr(vars.basePtr + vars.timerPtr + 0x8), out timerCentisec);
        current.timerMinute = vars.SwapBytesInt(timerMinute);
        current.timerSecond = vars.SwapBytesInt(timerSecond);
        current.timerCentisec = vars.SwapBytesInt(timerCentisec);

        memory.ReadValue<uint>(new IntPtr(vars.basePtr + vars.timeSettingPtr), out timeSetting);
        timeSetting = vars.SwapBytesInt(timeSetting);
        vars.timeLimit = TimeSpan.FromSeconds((int)timeSetting);
        print("Time Limit - " + vars.timeLimit);

        TimeSpan time = new TimeSpan(0, 0, (int)current.timerMinute, (int)current.timerSecond, (int) (current.timerCentisec*10));
        print("Current Time - " + time);

        if (time >= new TimeSpan(0,0,0) && time <= vars.timeLimit) {
            vars.igt = time;
            print("In-game Timer - " + vars.igt);

            if (vars.igt <= TimeSpan.FromMilliseconds(10))
                vars.elapsedTime = vars.timeLimit;
            else
                vars.elapsedTime = vars.timeLimit - vars.igt;
            print("Elapsed Time - " + vars.elapsedTime);
        };
    });

    vars.OnReset = (LiveSplit.Model.Input.EventHandlerT<TimerPhase>) ((s, e) => {
        vars.lastSplit = 0;
        vars.elapsedTime = new TimeSpan(0,0,0,0,0);
        vars.ResetStats();
        vars.UpdateValues();
        vars.UpdateCounters();
    });
    timer.OnReset += vars.OnReset;

    vars.ReadValues = (Action) (() => {
        memory.ReadValue<sbyte>(new IntPtr(vars.basePtr + vars.statsBasePtr + vars.offensePtr), out offense);
        memory.ReadValue<sbyte>(new IntPtr(vars.basePtr + vars.statsBasePtr + vars.speedPtr), out speed);
        memory.ReadValue<sbyte>(new IntPtr(vars.basePtr + vars.statsBasePtr + vars.boostPtr), out boost);
        memory.ReadValue<sbyte>(new IntPtr(vars.basePtr + vars.statsBasePtr + vars.turnPtr), out turn);
        memory.ReadValue<sbyte>(new IntPtr(vars.basePtr + vars.statsBasePtr + vars.chargePtr), out charge);
        memory.ReadValue<sbyte>(new IntPtr(vars.basePtr + vars.statsBasePtr + vars.weightPtr), out weight);
        memory.ReadValue<sbyte>(new IntPtr(vars.basePtr + vars.statsBasePtr + vars.defensePtr), out defense);
        memory.ReadValue<sbyte>(new IntPtr(vars.basePtr + vars.statsBasePtr + vars.glidePtr), out glide);
        memory.ReadValue<sbyte>(new IntPtr(vars.basePtr + vars.statsBasePtr + vars.healthPtr), out health);
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
        print("Total Stats : " + current.totalStats);

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
    foreach (dynamic component in timer.Layout.Components)
    {
            if (component.ComponentName == "AutoCounter")
            {
                vars.AutoCounter = component;
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


    vars.UpdateSplit = (Func<bool>) (() => {
        if (current.totalStats % 20 == 0 && vars.lastSplit != current.totalStats) {
            vars.lastSplit = current.totalStats;
            return true;
        }
        return false;
    });
}

start
{
    return vars.igt == vars.timeLimit;
}

update
{
    print("Updating.");

    vars.UpdateSettings();
    vars.UpdateTimer();

    if (timer.CurrentPhase == TimerPhase.Running && vars.igt > TimeSpan.FromMilliseconds(10)) {
        vars.ReadValues();
        vars.UpdateValues();
        vars.UpdateCounters();
    };

    if (timer.CurrentPhase == TimerPhase.Running && vars.igt <= TimeSpan.FromMilliseconds(10)) {
        timer.SetGameTime(vars.timeLimit);
        vars.timerModel.Pause();
    };
}

gameTime {
    return vars.elapsedTime;
}

split
{
    return vars.UpdateSplit();
}

isLoading
{
    return true;
}

shutdown
{
    timer.OnReset -= vars.OnReset;
}
