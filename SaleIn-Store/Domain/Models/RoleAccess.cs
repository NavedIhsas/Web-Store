using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class RoleAccess
{
    public Guid AcsUid { get; set; }

    public Guid? RolUid { get; set; }

    public bool? AcsWrite { get; set; }

    public bool? AcsRead { get; set; }

    public bool? AcsDelete { get; set; }

    public bool? AcsUpdate { get; set; }

    public bool? AcsFull { get; set; }

    public bool? AcsPrdPriceEdit { get; set; }

    public bool? AcsInvoiceDiscount { get; set; }

    public bool? AcsPrdPercentDiscountEdit { get; set; }

    public bool? AcsInvoiceDateEdit { get; set; }

    public bool? AcsCash { get; set; }

    public bool? AcsPosBank { get; set; }

    public bool? AcsBon { get; set; }

    public bool? AcsClub { get; set; }

    public bool? AcsCrediting { get; set; }

    public bool? AcsReturn { get; set; }

    public bool? AcsExchange { get; set; }

    public bool? AcsTempWrite { get; set; }

    public bool? AcsTempRead { get; set; }

    public bool? AcsTempDelete { get; set; }

    public bool? AcsTempUpdate { get; set; }

    public int? AcsAppSection { get; set; }

    public bool? AcsPreInvoice { get; set; }

    public virtual Role RolU { get; set; }
}
