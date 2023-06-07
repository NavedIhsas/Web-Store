namespace Application.Common
{
    public static class ConstantParameter
    {
        /// <summary>
        /// اندازه کد گروه اصلی
        /// </summary>
        public static string DigitCountMainGroupCode = "CODING_PRD_LVL1";
        
        /// <summary>
        /// آیدی پیش فرض فیلد اندازه کد گروه اصلی
        /// </summary>
        public static Guid DigitCountMainGroupCodeGuid = new("FBEE897E-3FA2-4B4E-938D-C6F95AC28852");
       
        /// <summary>
        /// اندازه کد زیرگروه
        /// </summary>
        public static string DigitCountSubGroupCode = "CODING_PRD_LVL2";
       
        /// <summary>
        /// آیدی پیش فرض فیلد اندازه کد زیرگروه
        /// </summary>
        public static Guid DigitCountSubGroupCodeGuid = new("B20E5558-49F6-484E-B623-CEF4A155B058");
       
        /// <summary>
        /// اندازه کد کالا
        /// </summary>
        public static string ProductCodeLength = new("CODING_PRD_LVL3");
        public static Guid ProductCodeLengthGuId = new("a0d27ca2-031f-47f3-9cd7-330852052e89");

        /// <summary>
        /// تولید خودکار کد کالا
        /// </summary>
        public static string AutoProductCode = new("AutoProductCode");
        public static Guid AutoProductCodeId = new("f9058772-e87e-485f-ba57-ff1ae3596d9b");
    }
}

