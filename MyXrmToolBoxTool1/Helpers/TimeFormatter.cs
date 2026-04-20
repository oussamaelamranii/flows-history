using System;

namespace MyXrmToolBoxTool1.Helpers
{
    public static class TimeFormatter
    {
        public static string MillisecondsTimeString(int milliseconds)
        {
            var ts = TimeSpan.FromMilliseconds(milliseconds);

            if (ts.TotalHours >= 1)
            {
                return $"{(int)ts.TotalHours}h {ts.Minutes}m {ts.Seconds}s";
            }

            if (ts.TotalMinutes >= 1)
            {
                return $"{ts.Minutes}m {ts.Seconds}s";
            }

            return $"{ts.Seconds}.{ts.Milliseconds:D3}s";
        }
    }
}
