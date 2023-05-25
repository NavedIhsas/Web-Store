using Application.SettingsDb;
using Domain.SaleInModels;
using Domain.ShopModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BusinessUnit = Domain.SaleInModels.BusinessUnit;
using Setting = Domain.SaleInModels.Setting;

namespace Application.Interfaces
{
    public interface IAuthHelper
    {
        void ConfigureSettingTable();
        List<BusinessUnit> SelectBranch();
        Guid? SetBranch(string branchId);
        bool ServerConnect();
        bool BaseServerConnect();
    }

    public class AuthHelper : IAuthHelper
    {
        private readonly ShopContext _context;
        private readonly SaleInContext _saleInContext;
        private readonly ILogger<AuthHelper> _logger;
        public AuthHelper(ShopContext context, ILogger<AuthHelper> logger, SaleInContext saleInContext)
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
                    _context.Settings.Add(new Domain.ShopModels.Setting()
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
                    _context.Settings.Add(new Domain.ShopModels.Setting()
                    { SetKey = id.ToString(), SetValue = key });
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
            return _saleInContext.BusinessUnits.AsNoTracking().ToList();
        }

        public Guid? SetBranch(string branchId)
        {
            try
            {
                var fisPeriod = _saleInContext.FiscalPeriods.AsEnumerable().SingleOrDefault(x => x.BusUnitUid.ToString().Fix() == branchId);
                if (fisPeriod != null) return fisPeriod.FisPeriodUid;
                _logger.LogError($"هیچ شبعه ی با آیدی {branchId} ثبت نشده است");
                throw new NullReferenceException($" Id {branchId} in table FiscalPeriods Not Found");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
              throw  new Exception(exception.Message);
            }
        }

        /// <summary>
        /// SaleIn Database
        /// </summary>
        /// <returns></returns>
        public bool BaseServerConnect()
           => _saleInContext.Database.CanConnect();

        /// <summary>
        /// Branch Database
        /// </summary>
        /// <returns></returns>
        public bool ServerConnect()
            => _context.Database.CanConnect();
    }
}
