using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class CardRechage
{
    public Guid CrId { get; set; }

    public Guid CrFrAccountclub { get; set; }

    public long CrFrSalon { get; set; }

    public Guid? CrFrModifiedBy { get; set; }

    public Guid CrFrCreatedBy { get; set; }

    public DateTime CrCreatedOn { get; set; }

    public DateTime? CrModifiedOn { get; set; }

    public decimal CrRemaining { get; set; }

    public Guid CrFrContract { get; set; }

    public DateTime CrExpireDate { get; set; }

    public DateTime CrStartDate { get; set; }

    public long CrTransactionNum { get; set; }

    public short CrStatus { get; set; }

    public virtual AccountClub CrFrAccountclubNavigation { get; set; }

    public virtual Contract CrFrContractNavigation { get; set; }

    public virtual SystemUser CrFrCreatedByNavigation { get; set; }

    public virtual SystemUser CrFrModifiedByNavigation { get; set; }

    public virtual Salon CrFrSalonNavigation { get; set; }

    public virtual ICollection<ServiceTransaction> ServiceTransactions { get; set; } = new List<ServiceTransaction>();
}
