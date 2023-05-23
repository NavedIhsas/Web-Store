using Application.SettingsDb;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Application.Interfaces
{
    public interface IAuthHelper
    {
        void ConfigureSettingTable();
    }

    public class AuthHelper : IAuthHelper
    {
        private readonly SaleInContext _context;
        private readonly ILogger<AuthHelper> _logger;
        public AuthHelper(SaleInContext context, ILogger<AuthHelper> logger)
        {
            _context = context;
            _logger = logger;
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
                    _context.Settings.Add(new Setting()
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
                    _context.Settings.Add(new Setting()
                        { SetKey = id.ToString(), SetValue = key });
                    _context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
               _logger.LogError($"به دلیل خطای زیر جدول تنظیمات بروز رسانی نشد  ({exception})");
                throw new Exception($"به دلیل خطای زیر جدول تنظیمات بروز رسانی نشد  ({exception})");
            }

        }
    }
}
