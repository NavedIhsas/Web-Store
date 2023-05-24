using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class Chequ
{
    public Guid CheqUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? AccUid { get; set; }

    public string CheqSerialNo { get; set; }

    public string CheqFromSerialNo { get; set; }

    public string CheqToSerialNo { get; set; }

    public DateTime? CheqReceiptDate { get; set; }

    public bool? CheqStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Account AccU { get; set; }

    public virtual BusinessUnit BusUnitU { get; set; }

    public virtual ICollection<ChequSheet> ChequSheets { get; set; } = new List<ChequSheet>();

    public virtual FiscalPeriod FisPeriodU { get; set; }
}
