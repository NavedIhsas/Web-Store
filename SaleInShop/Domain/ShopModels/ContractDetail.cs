using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class ContractDetail
{
    public Guid CdId { get; set; }

    public Guid CdFrContract { get; set; }

    public Guid CdFrProduct { get; set; }

    public decimal? CdDiscountPercent { get; set; }

    public decimal? CdDiscountRial { get; set; }

    public decimal? CdCreditLimit { get; set; }

    public short? CdBaseTime { get; set; }

    public decimal? CdBaseTimeCost { get; set; }

    public short? CdExtraTime { get; set; }

    public decimal? CdExtraCost { get; set; }

    public virtual Contract CdFrContractNavigation { get; set; }

    public virtual Product CdFrProductNavigation { get; set; }
}
