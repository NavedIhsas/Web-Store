namespace Domain.ShopModels;

public class Tab
{
    public Guid TabUid { get; set; }

    public byte? TabType { get; set; }

    public string TabName { get; set; }

    public int? TabOrder { get; set; }
}