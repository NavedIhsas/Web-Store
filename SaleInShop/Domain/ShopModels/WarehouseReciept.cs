
using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class WarehouseReciept
{
    public Guid WarHosRecUid { get; set; }

    public Guid? WarHosRecParentUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? SalCatUid { get; set; }

    public Guid? AccUid { get; set; }

    public Guid? OrdUid { get; set; }

    public Guid? QutUid { get; set; }

    public Guid? CstCtrUid { get; set; }

    public string WarHosRecNumber { get; set; }

    public decimal? WarHosRecTotalAmount { get; set; }

    public decimal? WarHosRecTotalDiscount { get; set; }

    public decimal? WarHosRecTotalTax { get; set; }

    public decimal? WarHosRecTotalCost { get; set; }

    public decimal? WarHosRecExtendedAmount { get; set; }

    public DateTime? WarHosRecDate { get; set; }

    public DateTime? WarHosRecDueDate { get; set; }

    public string WarHosRecReference { get; set; }

    public string WarHosRecDescribtion { get; set; }

    public bool? WarHosRecStatusControl { get; set; }

    public bool? WarHosRecStatus { get; set; }

    public bool? WarHosRecFinalStatusControl { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Account AccU { get; set; }

    public virtual BusinessUnit BusUnitU { get; set; }

    public virtual Order OrdU { get; set; }

    public virtual ICollection<PaymentRecieptSheet> PaymentRecieptSheets { get; set; } = new List<PaymentRecieptSheet>();

    public virtual Quote QutU { get; set; }

    public virtual SalesCategory SalCatU { get; set; }
}
