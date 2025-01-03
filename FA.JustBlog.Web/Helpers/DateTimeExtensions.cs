namespace FA.JustBlog.Web.Helpers
{
    public static class DateTimeExtensions
    {
        public static string ToFriendlyTime(this DateTime dateTime)
        {
            var now = DateTime.Now;
            var difference = now - dateTime;

            if (difference.TotalSeconds < 60)
            {
                return $"{difference.Seconds} seconds ago";
            }
            if (difference.TotalMinutes < 60)
            {
                return $"{difference.Minutes} minutes ago";
            }
            if (difference.TotalHours < 24)
            {
                return $"{difference.Hours} hours ago";
            }
            if (difference.TotalDays < 2)
            {
                return $"yesterday at {dateTime:hh:mm tt}";
            }
            if (difference.TotalDays < 7)
            {
                return $"{difference.Days} days ago";
            }

            // Default format for older dates
            return dateTime.ToString("MMMM dd, yyyy 'at' hh:mm tt");
        }
    }
}
