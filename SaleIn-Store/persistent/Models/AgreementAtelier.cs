using System;
using System.Collections.Generic;

namespace persistent.Models;

public partial class AgreementAtelier
{
    public Guid AgtAtlUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? AccUid { get; set; }

    public Guid? AccClbUid { get; set; }

    public Guid? InvUidFilm { get; set; }

    public Guid? InvUidPhoto { get; set; }

    public string AgtAtlSerialNumber { get; set; }

    public DateTime? AgtAtlCelebrationDate { get; set; }

    public string AgtAtlCelebrationType { get; set; }

    public string AgtAtlMajlesAddress { get; set; }

    public string AgtAtlFlowerShopAddress { get; set; }

    public string AgtAtlBrideHairdresserAddress { get; set; }

    public string AgtAtlGroomHomeAddress { get; set; }

    public string AgtAtlBrideHomeAddress { get; set; }

    public string AgtAtlGroomHomePhone { get; set; }

    public string AgtAtlBrideHomePhone { get; set; }

    public string AgtAtlGroomHomeMobile { get; set; }

    public string AgtAtlBrideHomeMobile { get; set; }

    public string AgtAtlStartTime { get; set; }

    public string AgtAtlEndTime { get; set; }

    public decimal? AgtAtlAdditionalAmount { get; set; }

    public DateTime? AgtAtlCurrentDate { get; set; }

    public string AgtAtlDescribtion { get; set; }

    public string AgtAtlCustomerFilmOk { get; set; }

    public int? AgtAtlType { get; set; }

    public int? AgtAtlKind { get; set; }

    public bool? AgtAtlStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public string AgtAtlName { get; set; }

    public DateTime? AgtAtlDateOfBirthChild { get; set; }

    public string AgtAtlPhotographer { get; set; }

    public string AgtAtlSelectionAnswerable { get; set; }

    public DateTime? AgtAtlDesigningDueDate { get; set; }

    public string AgtAtlDesigner { get; set; }

    public DateTime? AgtAtlDesigningEndDate { get; set; }

    public string AgtAtlDesigningOkAnswerable { get; set; }

    public DateTime? AgtAtlFinalDeliveryDate { get; set; }

    public string AgtAtlPrintSender { get; set; }

    public DateTime? AgtAtlPrintSendDate { get; set; }

    public string AgtAtlDeliverer { get; set; }

    public int? AgtAtlPhotoCount { get; set; }

    public string AgtAtlBuyer { get; set; }

    public DateTime? AgtAtlDesignedDate { get; set; }

    public string AgtAtlDesignedBuyer { get; set; }

    public string AgtAtlCustomerOk { get; set; }

    public DateTime? AgtAtlDeliveryDate { get; set; }

    public bool? AgtAtlArchive { get; set; }

    public decimal? AgtAtlArchiveAmount { get; set; }

    public Guid? AgtAtlPayRciptSheetUid { get; set; }

    public Guid? AgtAtlPhotographerUid { get; set; }

    public Guid? AgtAtlSelectionAnswerableUid { get; set; }

    public Guid? AgtAtlDesignerUid { get; set; }

    public Guid? AgtAtlDesigningOkAnswerableUid { get; set; }

    public Guid? AgtAtlPrintSenderUid { get; set; }

    public Guid? AgtAtlDelivererUid { get; set; }

    public Guid? AtlCatUid { get; set; }

    public Guid? InvUidService { get; set; }
}
