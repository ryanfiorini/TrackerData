using System;

namespace TrackerData.Services.Extensions
{
    public static partial class StringExtensions
    {
        public static DateTime? ParseDateTimeNull(this string value)
        {
            return !string.IsNullOrEmpty(value)
                ? DateTime.Parse(value)
                : null;
        }

    }
}
