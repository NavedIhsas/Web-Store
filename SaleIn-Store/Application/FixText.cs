namespace Application
{
    
    public static class Text
    {
        /// <summary>
        /// trim and lower
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Fix(this string text)
        {
            return text == null ? "" : text.Trim().ToLower();
        }
    }
}
