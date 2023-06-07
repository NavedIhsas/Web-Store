namespace Application.Common
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


        public static string GetLast(this string source, int tailLength)
        {
            if (tailLength >= source.Length)
                return source;
            return source.Substring(source.Length - tailLength);
        }

    }
}
