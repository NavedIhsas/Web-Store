using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class ServiceTransaction
{
    public Guid StrId { get; set; }

    public Guid StrFrRecharge { get; set; }

    public Guid StrFrAccountclub { get; set; }

    public long StrFrSalon { get; set; }

    public Guid StrFrProduct { get; set; }

    public Guid StrFrCreateBy { get; set; }

    public Guid? StrFrModifiedBy { get; set; }

    public Guid StrFrContract { get; set; }

    public long? StrFrCsp { get; set; }

    public Guid? StrFrTicketDetail { get; set; }

    public short StrType { get; set; }

    public DateTime StrCreateOn { get; set; }

    public DateTime? StrModifiedOn { get; set; }

    public int StrYear { get; set; }

    public long StrIndicator { get; set; }

    public decimal StrAmount { get; set; }

    public decimal? StrDiscount { get; set; }

    public short StrStatus { get; set; }

    public short StrCheckoutType { get; set; }

    public string StrMobile { get; set; }

    public string StrFullName { get; set; }

    public string StrDesc { get; set; }

    public virtual ICollection<InOut> InOuts { get; set; } = new List<InOut>();

    public virtual AccountClub StrFrAccountclubNavigation { get; set; }

    public virtual Contract StrFrContractNavigation { get; set; }

    public virtual SystemUser StrFrCreateByNavigation { get; set; }

    public virtual ContinuouseServicesPlaning StrFrCspNavigation { get; set; }

    public virtual SystemUser StrFrModifiedByNavigation { get; set; }

    public virtual Product StrFrProductNavigation { get; set; }

    public virtual CardRechage StrFrRechargeNavigation { get; set; }

    public virtual Salon StrFrSalonNavigation { get; set; }

    public virtual TicketDetail StrFrTicketDetailNavigation { get; set; }
}
