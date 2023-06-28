using Application.Common;
using Application.Interfaces.Context;
using Domain.SaleInModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Setting = Domain.ShopModels.Setting;

namespace Application.Interfaces;

public interface IAuthHelper
{
    void ConfigureSettingTable();
    List<BusinessUnit> SelectBranch();
    Guid? SetBranch(string branchId);
    bool ServerConnect();
    bool BaseServerConnect();

    /// <summary>
    ///     کد محصول
    /// </summary>
    /// <returns></returns>
    bool IsAutomatic();


    /// <summary>
    ///     اندازه طول کد محصول
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    bool? CheckLength(string code);

    List<Setting> GetSettings();

    string AutoGenerateCode(Guid prdLvlId);
    bool AutoCodeProduct();
}

public class AuthHelper : IAuthHelper
{
    private readonly IShopContext _context;
    private readonly ILogger<AuthHelper> _logger;
    private readonly ISaleInContext _saleInContext;

    public AuthHelper(IShopContext context, ILogger<AuthHelper> logger, ISaleInContext saleInContext)
    {
        _context = context;
        _logger = logger;
        _saleInContext = saleInContext;
    }

    public void ConfigureSettingTable()
    {
        try
        {
            var getSubGroupDigitCount = ConstantParameter.DigitCountMainGroupCode;
            var getSubGroupDigitCountGuid = ConstantParameter.DigitCountMainGroupCodeGuid;
            var mainCodeGroup = _context.Settings.SingleOrDefault(x => x.SetKey == getSubGroupDigitCount);

            if (mainCodeGroup == null)
            {
                var checkGuid = _context.Settings.SingleOrDefault(x => x.SetUid == getSubGroupDigitCountGuid);
                if (checkGuid != null) getSubGroupDigitCountGuid = new Guid();
                _context.Settings.Add(new Setting
                    { SetKey = getSubGroupDigitCountGuid.ToString(), SetValue = getSubGroupDigitCount });
                _context.SaveChanges();
            }

            var key = ConstantParameter.DigitCountSubGroupCode;
            var id = ConstantParameter.DigitCountSubGroupCodeGuid;
            var mainGroup = _context.Settings.SingleOrDefault(x => x.SetKey == key);

            if (mainGroup != null) return;
            {
                var checkGuid = _context.Settings.SingleOrDefault(x => x.SetUid == id);
                if (checkGuid != null) id = new Guid();
                _context.Settings.Add(new Setting { SetKey = id.ToString(), SetValue = key });
                _context.SaveChanges();
            }


            var productKey = ConstantParameter.ProductCodeLength;
            var productId = ConstantParameter.ProductCodeLengthGuId;
            var productCheck = _context.Settings.SingleOrDefault(x => x.SetKey == productKey);

            if (productCheck != null) return;
            {
                var checkGuid = _context.Settings.SingleOrDefault(x => x.SetUid == productId);
                if (checkGuid != null) productId = new Guid();
                _context.Settings.Add(new Setting { SetKey = productId.ToString(), SetValue = productKey });
                _context.SaveChanges();
            }

            var autoProductKey = ConstantParameter.AutoProductCode;
            var autoProductId = ConstantParameter.AutoProductCodeId;
            var autoProductCheck = _context.Settings.SingleOrDefault(x => x.SetKey == autoProductKey);

            if (autoProductCheck != null) return;
            {
                var checkGuid = _context.Settings.SingleOrDefault(x => x.SetUid == autoProductId);
                if (checkGuid != null) autoProductId = new Guid();
                _context.Settings.Add(new Setting { SetKey = autoProductId.ToString(), SetValue = autoProductKey });
                _context.SaveChanges();
            }
        }
        catch (Exception exception)
        {
            _logger.LogError($"به دلیل خطای زیر جدول تنظیمات بروز رسانی نشد  ({exception})");
            throw new Exception($"Can't Update Table Setting Because  ({exception})");
        }
    }

    public List<BusinessUnit> SelectBranch()
    {
        return _saleInContext.BusinessUnits.Where(x => x.BusUnitStatus != false).AsNoTracking().ToList();
    }

    public Guid? SetBranch(string branchId)
    {
        try
        {
            var fisPeriod = _saleInContext.FiscalPeriods.AsEnumerable()
                .SingleOrDefault(x => x.BusUnitUid.ToString().Fix() == branchId);
            if (fisPeriod != null) return fisPeriod.FisPeriodUid;
            _logger.LogError($"هیچ شبعه ی با آیدی {branchId} ثبت نشده است");
            throw new NullReferenceException($" Id {branchId} in table FiscalPeriods Not Found");
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);
            throw new Exception(exception.Message);
        }
    }

    /// <summary>
    ///     SaleIn Database
    /// </summary>
    /// <returns></returns>
    public bool BaseServerConnect()
    {
        return _saleInContext.Database.CanConnect();
    }

    public bool IsAutomatic()
    {
        try
        {
            var auto = _context.Settings.FirstOrDefault(x => x.SetKey == ConstantParameter.AutoProductCode)?.SetValue;
            var autoBool = Convert.ToBoolean(auto);
            return autoBool;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public bool? CheckLength(string code)
    {
        try
        {
            var isNumeric = int.TryParse(code, out _);
            if (!isNumeric) return false;
            var auto = AutoCodeProduct();
            if (auto) return true;
            if (string.IsNullOrWhiteSpace(code)) return false;

            var length = _context.Settings.FirstOrDefault(x => x.SetKey == ConstantParameter.ProductCodeLength)
                ?.SetValue;
            if (length == null) return null;
            return !(code.Length > int.Parse(length));
        }
        catch (Exception e)
        {
            _logger.LogError($"حین چک کردن کد کالا ({code}) خطای زیر رخ داد {e}");
            throw new Exception($"حین چک کردن کد کالا ({code}) خطای زیر رخ داد {e}");
        }
    }

    public List<Setting> GetSettings()
    {
        return _context.Settings.AsNoTracking().ToList();
    }

    public string AutoGenerateCode(Guid prdLvlId)
    {
        try
        {
            var auto = AutoCodeProduct();
            if (!auto) return "";
            {
                var maxSubGroup = "";
                var level = _context.ProductLevels.Find(prdLvlId);
                if (level == null) return "";
                var maxGroup = level.PrdLvlCodeValue;
                var subGroup = _context.ProductLevels.Where(x => x.PrdLvlParentUid == prdLvlId);
                if (subGroup.Any())
                    maxSubGroup = subGroup.Max(x => x.PrdLvlCodeValue);
                return maxGroup + maxSubGroup + AutoGenerateCode();
            }
        }
        catch (Exception e)
        {
            _logger.LogError($"حین تولید کردن کد خودکار برای کالا خطای زیر رخ داد {e}");
            throw new Exception($"حین تولید کردن کد خودکار برای کالا خطای زیر رخ داد {e}");
        }
    }

    public bool AutoCodeProduct()
    {
        try
        {
            var auto = _context.Settings.FirstOrDefault(x => x.SetKey == ConstantParameter.AutoProductCode)?.SetValue;
            var convertToB = Convert.ToBoolean(auto);
            return convertToB;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    ///     Branch Database
    /// </summary>
    /// <returns></returns>
    public bool ServerConnect()
    {
        return _context.Database.CanConnect();
    }


    private string AutoGenerateCode()
    {
        var codeLength = _context.Settings
            .FirstOrDefault(x => x.SetKey == ConstantParameter.ProductCodeLength)
            ?.SetValue;
        var generateLength = 0;
        if (codeLength != null)
            generateLength = int.Parse(codeLength);
        var product = _context.Products.Select(x => new { x.PrdCode });

        #region for First Product

        //TODo Test Tis
        if (!product.Any())
        {
            var z = "";
            for (var i = 0; i < generateLength; i++)
            {
                z += "0";
            }
               return z + "1";
        }

        #endregion

        var numbers = new List<int>();
        foreach (var p in product)
        {
            if (p.PrdCode.Length<=generateLength)
                continue;
            var length = p.PrdCode.Substring(p.PrdCode.Length - generateLength);
            var convertToInt = int.Parse(length);
            numbers.Add(convertToInt);
        }

        var max = numbers.Max();
        var generate = (max + 1).ToString();
        var r = generate.Length;
        var generateZero = Math.Abs(r - generateLength);

        var zero = "";
        for (var i = 0; i < generateZero; i++) zero += "0";
        return zero + generate;
    }
}