namespace WPFetch.Model.Enums
{
    public enum Locales
    {
        EN,
        FR 
    }

    public static class LocalesExtention
    {
        public static string GetString(this Locales locales)
        {
            return locales switch
            {
                Locales.FR => "Français",
                Locales.EN => "English",
                _ => "Invalid Locale!"
            };
        }
    }
}
