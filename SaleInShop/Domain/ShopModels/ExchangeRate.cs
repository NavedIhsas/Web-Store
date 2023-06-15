namespace Domain.ShopModels;

public class ExchangeRate
{
    public Guid ExchRateUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public string ExchRateName { get; set; }

    public decimal? ExchRatePrice { get; set; }

    public bool? ExchRateStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public string ExchRateImage { get; set; }

    public string ExchRateLatinName { get; set; }

    public double? ExchRatePercentRisk { get; set; }
}