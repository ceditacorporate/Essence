namespace PureSMS.Helpers
{
    public static class StringExtensions
    {
        public static bool IsPresent(this string value) => !string.IsNullOrWhiteSpace(value);
    }
}
