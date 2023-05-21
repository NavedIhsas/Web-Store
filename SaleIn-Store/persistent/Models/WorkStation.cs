using System;
using System.Collections.Generic;

namespace persistent.Models;

public partial class WorkStation
{
    public Guid WrkSttUid { get; set; }

    public string WrkSttCode { get; set; }

    public string WrkSttName { get; set; }

    public string WrkSttDatabase { get; set; }

    public string WrkSttIpAddress { get; set; }

    public Guid? WrkSttBranchuid { get; set; }

    public int? WrkSttStatus { get; set; }

    public string WrkSttPrinter { get; set; }

    public string WrkSttPrinter2 { get; set; }

    public string WrkSttIpMellat { get; set; }

    public string WrkSttPortMellat { get; set; }

    public string WrkSttReadTimeoutMellat { get; set; }

    public Guid? WrkSttMellatBank { get; set; }

    public bool? WrkSttActivePosMellat { get; set; }

    public bool? WrkSttFormalPosMellat { get; set; }

    public string WrkSttPcPosSerialNoMelli { get; set; }

    public string WrkSttPcPosIpMelli { get; set; }

    public string WrkSttPcPosPortMelli { get; set; }

    public Guid? WrkSttMelliBank { get; set; }

    public bool? WrkSttActivePosMelli { get; set; }

    public bool? WrkSttFormalPosMelli { get; set; }

    public string WrkSttPosPortParsian { get; set; }

    public Guid? WrkSttParsianBank { get; set; }

    public bool? WrkSttActivePosParsian { get; set; }

    public bool? WrkSttFormalPosParsian { get; set; }

    public string WrkSttConnectionTypeParsian { get; set; }

    public string WrkSttPcPosTcpIpParsian { get; set; }

    public string WrkSttPcPosTcpPortParsian { get; set; }

    public string WrkSttConnectionTypeSamanKish { get; set; }

    public string WrkSttPcPosTcpIpSamanKish { get; set; }

    public string WrkSttPosPortSamanKish { get; set; }

    public Guid? WrkSttSamanKishBank { get; set; }

    public bool? WrkSttActivePosSamanKish { get; set; }

    public bool? WrkSttFormalPosSamanKish { get; set; }

    public string WrkSttConnectionTypeIranKish { get; set; }

    public string WrkSttSerialPortIranKish { get; set; }

    public string WrkSttPcPosTcpIpIranKish { get; set; }

    public string WrkSttPcPosTcpPortIranKish { get; set; }

    public Guid? WrkSttIranKishBank { get; set; }

    public bool? WrkSttActivePosIranKish { get; set; }

    public bool? WrkSttFormalPosIranKish { get; set; }

    public bool? WrkSttIsConnected { get; set; }

    public string WrkSttPcPosSerialNoIranKish { get; set; }

    public string WrkSttPcPosTerminalIdIranKish { get; set; }

    public string WrkSttPcPosAcceptorIdIranKish { get; set; }

    public string WrkSttConnectionTypeEghtesad { get; set; }

    public string WrkSttSerialPortEghtesad { get; set; }

    public string WrkSttPcPosTcpIpEghtesad { get; set; }

    public string WrkSttPcPosTcpPortEghtesad { get; set; }

    public Guid? WrkSttEghtesadBank { get; set; }

    public bool? WrkSttActivePosEghtesad { get; set; }

    public bool? WrkSttFormalPosEghtesad { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public bool? WrkSttActiveCallerid { get; set; }

    public int? WrkSttCalleridNumber { get; set; }

    public int? WrkSttCalleridLine { get; set; }
}
