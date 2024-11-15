using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQueryableShowcase.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets DateTime from UNIX time long.
        /// </summary>
        public static DateTime FromUnixTime(this long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(Math.Min(unixTime, 253402300799));
        }

        /// <summary>
        /// Gets DateTime from UNIX time string.
        /// </summary>
        public static DateTime FromUnixTime(this string unixTime)
        {
            return Int64.Parse(unixTime).FromUnixTime();
        }

        /// <summary>
        /// DateTime to UNIX time
        /// </summary>
        public static long ToUnixTime(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - epoch).TotalSeconds);
        }

        public static DateTime Clip(this DateTime date, DateTime min, DateTime max)
        {
            if (date < min)
            {
                return min;
            }
            else if (date > max)
            {
                return max;
            }

            return date;
        }
    }
}
