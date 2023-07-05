


namespace Application.Common;


/// <summary>
/// Price Invoice Level in AccountClubType 
/// </summary>
public static class PriceInvoiceLevel
{
    public  const int Zero = 0;
    public  const int Level1 = 1;
    public  const int Level2 = 2;
    public  const int Level3 = 3;
    public  const int Level4 = 4;
    public  const int Level5 = 5;

}
public static class SessionName
{
    public const string ProductList = "ProductList";
    public const string ProductListDes = "ProductList-Des";
}


public static class InvoiceDetDiscountStatus
{
    public const int Product = 0;
    public const int AccountClubType = 1;
    public const int Both = 2;
}

public static class ConstantParameter
{

    /// <summary>
    ///     اندازه کد گروه اصلی
    /// </summary>
    public static string DigitCountMainGroupCode = "CODING_PRD_LVL1";

    /// <summary>
    ///     آیدی پیش فرض فیلد اندازه کد گروه اصلی
    /// </summary>
    public static Guid DigitCountMainGroupCodeGuid = new("FBEE897E-3FA2-4B4E-938D-C6F95AC28852");

    /// <summary>
    ///     اندازه کد زیرگروه
    /// </summary>
    public static string DigitCountSubGroupCode = "CODING_PRD_LVL2";

    /// <summary>
    ///     آیدی پیش فرض فیلد اندازه کد زیرگروه
    /// </summary>
    public static Guid DigitCountSubGroupCodeGuid = new("B20E5558-49F6-484E-B623-CEF4A155B058");

    /// <summary>
    ///     اندازه کد کالا
    /// </summary>
    public static string ProductCodeLength = new("CODING_PRD_LVL3");

    public static Guid ProductCodeLengthGuId = new("a0d27ca2-031f-47f3-9cd7-330852052e89");

    /// <summary>
    ///     تولید خودکار کد کالا
    /// </summary>
    public static string AutoProductCode = new("AutoProductCode");

    public static Guid AutoProductCodeId = new("f9058772-e87e-485f-ba57-ff1ae3596d9b");


    /// <summary>
    /// وضعیت تخفیف کالا در دریف فاکتور
    /// 1: product
    /// 2:AccountClubType
    /// 3:Both Product and AccountClubType
    /// </summary>
    public static string InvoiceDetDiscountStatus = new("InvoiceDetDiscountStatus");

    public static Guid InvoiceDetDiscountStatusId = new("f9058772-e87e-485f-ba57-ff1ae3596c9b");


    /// <summary>
    /// product discount Type
    /// </summary>
    /// <returns></returns>
    public static int Percent = 0;

    /// <summary>
    /// product discount Type
    /// </summary>
    /// <returns></returns>
    public static int Amount = 1;

}


