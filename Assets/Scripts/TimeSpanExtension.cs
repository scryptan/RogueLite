using System;

namespace RogueLike
{
    public static class TimeSpanExtension
    {
        public static TimeSpan Hours(this int value) => TimeSpan.FromHours(value);
        public static TimeSpan Minutes(this int value) => TimeSpan.FromMinutes(value);
        public static TimeSpan Seconds(this int value) => TimeSpan.FromSeconds(value);
        public static TimeSpan Milliseconds(this int value) => TimeSpan.FromMilliseconds(value);
    }
}