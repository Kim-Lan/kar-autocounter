﻿using System;

namespace LiveSplit.TimeFormatters
{
    public class AlternateTimeFormatter : ITimeFormatter
    {
        public TimeAccuracy Accuracy { get; set; }

        public AlternateTimeFormatter(TimeAccuracy accuracy)
        {
            Accuracy = accuracy;
        }

        public string Format (TimeSpan? time)
        {
            if (time == null)
            {
                return TimeFormatConstants.DASH;
            }
            else
            {
                var shortTime = new ShortTimeFormatter().Format(time);
                if (Accuracy == TimeAccuracy.Hundredths)
                    return shortTime;
                else if (Accuracy == TimeAccuracy.Tenths)
                    return shortTime.Substring(0, shortTime.IndexOf('.') + 2);
                else
                    return shortTime.Substring(0, shortTime.IndexOf('.'));
            }
        }
    }
}
