using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class BankPose
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Ip { get; set; }

    public string Serial { get; set; }

    public string Port { get; set; }

    public bool ConnectionType { get; set; }

    public int? SerialNumber { get; set; }

    public int? TerminalNumber { get; set; }

    public int? AcceptorNumber { get; set; }

    public Guid BankId { get; set; }

    public virtual Bank Bank { get; set; }
}
