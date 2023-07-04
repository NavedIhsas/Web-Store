using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class Contract
{
    public Guid CntId { get; set; }

    public string CntTitle { get; set; }

    public DateTime CntStartDate { get; set; }

    public DateTime CntEndDate { get; set; }

    public Guid CntFrCreatedby { get; set; }

    public Guid? CntFrModifiedby { get; set; }

    public DateTime CntCreateon { get; set; }

    public DateTime? CntModifiedon { get; set; }

    public short CntType { get; set; }

    public string CntContractNum { get; set; }

    public Guid? CntFrContract { get; set; }

    public virtual ICollection<AccountClub> AccountClubs { get; set; } = new List<AccountClub>();

    public virtual ICollection<Calender> Calenders { get; set; } = new List<Calender>();

    public virtual ICollection<CardRechage> CardRechages { get; set; } = new List<CardRechage>();

    public virtual Contract CntFrContractNavigation { get; set; }

    public virtual SystemUser CntFrCreatedbyNavigation { get; set; }

    public virtual SystemUser CntFrModifiedbyNavigation { get; set; }

    public virtual ICollection<ContractDetail> ContractDetails { get; set; } = new List<ContractDetail>();

    public virtual ICollection<Contract> InverseCntFrContractNavigation { get; set; } = new List<Contract>();

    public virtual ICollection<ServiceTransaction> ServiceTransactions { get; set; } = new List<ServiceTransaction>();
}
