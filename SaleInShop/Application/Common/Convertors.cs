using System.Globalization;
using MD.PersianDateTime;
using NodaTime;

namespace Application.Common
{

    public static class Tools
    {

        public static string[] MonthNames =
            { "حمل", "ثور", "جوزا", "سرطان", "اسد", "سنبله", "میزان", "عقرب", "قوس", "جدی", "دلو", "حوت" };

        public static string[] DayNames = { "شنبه", "یکشنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" };
        public static string[] DayNamesG = { "یکشنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه", "شنبه" };

        private static readonly string[] Pn = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
        private static readonly string[] En = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };


        public static string ToFarsi(this DateTime? date)
        {
            try
            {
                if (date != null) return date.Value.ToFarsi();
            }
            catch (Exception)
            {
                return "";
            }

            return "";
        }

       

        public static string ChangeTimeToFarsi(DateTime date, string format)
        {
            var time = new PersianDateTime(date);
            return time.ToString(format);
        }

        public static string ToFarsi(this DateTime date)
        {
            if (date == new DateTime()) return "";
            var pc = new PersianCalendar();
            return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
        }

        public static string ToDiscountFormat(this DateTime date)
        {
            if (date == new DateTime()) return "";
            return $"{date.Year}/{date.Month}/{date.Day}";
        }

        public static string GetTime(this DateTime date)
        {
            return $"_{date.Hour:00}_{date.Minute:00}_{date.Second:00}";
        }

        public static string ToFarsiFull(this DateTime date)
        {
            var pc = new PersianCalendar();
            return
                $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00} {date.Hour:00}:{date.Minute:00}:{date.Second:00}";
        }

        public static string ToEnglishNumber(this string strNum)
        {
            if (!string.IsNullOrWhiteSpace(strNum))
            {
                var cash = strNum;
                for (var i = 0; i < 10; i++)
                    cash = cash.Replace(Pn[i], En[i]);
                return cash;
            }

            return strNum;
        }

        public static string ToPersianNumber(this int intNum)
        {
            var chash = intNum.ToString();
            for (var i = 0; i < 10; i++)
                chash = chash.Replace(En[i], Pn[i]);
            return chash;
        }

        public static DateTime? FromFarsiDate(this string InDate)
        {
            if (string.IsNullOrEmpty(InDate))
                return null;

            var spited = InDate.Split('/');
            if (spited.Length < 3)
                return null;

            if (!int.TryParse(spited[0].ToEnglishNumber(), out var year))
                return null;

            if (!int.TryParse(spited[1].ToEnglishNumber(), out var month))
                return null;

            if (!int.TryParse(spited[2].ToEnglishNumber(), out var day))
                return null;
            var c = new PersianCalendar();
            return c.ToDateTime(year, month, day, 0, 0, 0, 0);
        }


        public static DateTime ToGeorgianDateTime(this string persianDate)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(persianDate)) return new DateTime();
                persianDate = persianDate.ToEnglishNumber();
                var year = Convert.ToInt32(persianDate.Substring(0, 4));
                var month = Convert.ToInt32(persianDate.Substring(5, 2));
                var day = Convert.ToInt32(persianDate.Substring(8, 2));
                return new DateTime(year, month, day, new PersianCalendar());
            }
            catch (Exception e)
            {
                throw new Exception($"The persian Date {persianDate}  was not converted to georgian", e);
            }
        }  
        
      
        public static TimeSpan ToGeorgianTime(this string time)
        {
            try
            {
                if (time.Length == 4)
                {
                    var substring = time.Substring(3, 1);
                    var newHours = time.Substring(0, 2);
                    var newMinutes = "0" + substring;
                    time = newHours + ":" + newMinutes;

                }

                if (time.Length == 3)
                {
                    var substring = time[..1];
                    var newHours = "0" + substring;
                    var min = time.Substring(2, 1);
                    var newMinutes = "0" + min;
                    time = newHours + ":" + newMinutes;
                }
                if (time.Length == 5)
                    time += ":00";
                time = time.ToEnglishNumber();
                var hours = Convert.ToInt32(time.Substring(0, 2));
                var minute = Convert.ToInt32(time.Substring(3, 2));
                var second = Convert.ToInt32(time.Substring(6, 2));
                return new TimeSpan(hours, minute, second);
            }
            catch (Exception e)
            {
                throw new Exception($"The time {time} was not converted to georgian {e}");
            }
        }

        public static DateTime ToGeorgianFullDateTime(string persianDate, string time)
        {
            if (time.Length == 5)
                time += ":00";
            persianDate = persianDate.ToEnglishNumber();
            var year = Convert.ToInt32(persianDate.Substring(0, 4));
            var month = Convert.ToInt32(persianDate.Substring(5, 2));
            var day = Convert.ToInt32(persianDate.Substring(8, 2));
            var hours = Convert.ToInt32(time.Substring(0, 2));
            var minute = Convert.ToInt32(time.Substring(3, 2));
            var second = Convert.ToInt32(time.Substring(8, 2));
            return new DateTime(year, month, day, hours, minute, second, new PersianCalendar());
        }


        public static DateTime GeorgianDateTime(this string persianDate)
        {
            persianDate = persianDate.ToEnglishNumber();
            //var year = Convert.ToInt32(persianDate.Substring(0, 4));
            var month = Convert.ToInt32(persianDate.Substring(5, 2));
            var day = Convert.ToInt32(persianDate.Substring(8, 2));
            var hurs = Convert.ToInt32(persianDate.Substring(9, 2));
            //var minut = Convert.ToInt32(persianDate.Substring(11, 2));
            //var second = Convert.ToInt32(persianDate.Substring(13, 2));
            return new DateTime(hurs, month, day, new PersianCalendar());

        }

        public static string ToMoney(this double myMoney)
        {
            return myMoney.ToString("N0", CultureInfo.CreateSpecificCulture("fa-ir"));
        }

        public static string ToFileName(this DateTime date)
        {
            return $"{date.Year:0000}-{date.Month:00}-{date.Day:00}-{date.Hour:00}-{date.Minute:00}-{date.Second:00}";
        }


        public static string EncryptionPassword(string password)
        {
            var str = "20164. ";
            foreach (var c in password)
            {
                str = str + (((Convert.ToInt32(c)) + 21) * ((Convert.ToInt32(c)) + 21)).ToString() + '.';
            }

            return str;
        }


        public static DateTime ToMiladi(string persianDate)
        {
            var day = 1;
            if (string.IsNullOrWhiteSpace(persianDate)) return new DateTime();
            persianDate = persianDate.ToEnglishNumber();
            var year = Convert.ToInt32(persianDate[..4]);
            var month = Convert.ToInt32(persianDate.Substring(5, 2));
            if (persianDate.Length > 7)
                day = Convert.ToInt32(persianDate.Substring(8, 2));
            var persianDte = new LocalDate(year, month, day, CalendarSystem.PersianArithmetic);
            var gregorianDate = persianDte.WithCalendar(CalendarSystem.Gregorian);
            return Convert.ToDateTime(gregorianDate.Year + "/" + gregorianDate.Month + "/" + gregorianDate.Day);

        }

        public static string DecryptionPassword(string encodePassword)
        {
            var sqlCodePass = "";
            var sqlDeCodePass = "";
            var str = "";

            sqlCodePass = encodePassword;
            for (var i = 0; i <= sqlCodePass.Length - 1; i++)
            {
                if (sqlCodePass.Substring(i, 1) != ".")
                {
                    str = str + sqlCodePass.Substring(i, 1);
                }
                else
                {
                    str = (Math.Sqrt(float.Parse(str)) - 21).ToString(CultureInfo.InvariantCulture);
                    var tmpint = int.Parse(str);
                    sqlDeCodePass = sqlDeCodePass + Convert.ToChar(tmpint).ToString();
                    str = "";
                }
            }

            sqlDeCodePass = sqlDeCodePass.Substring(1, sqlDeCodePass.Length - 1);

            //+21^2 – 3رقم اول
            return sqlDeCodePass;
        }


    }
}