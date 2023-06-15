namespace Domain.SaleInModels;

public class Role
{
    public Guid RolUid { get; set; }

    public string RolName { get; set; }

    /// <summary>
    ///     1- admin 2 - supervisor 3 - user
    /// </summary>
    public int? RolType { get; set; }

    public virtual ICollection<RoleAccess> RoleAccesses { get; set; } = new List<RoleAccess>();

    public virtual ICollection<SystemUser> SystemUsers { get; set; } = new List<SystemUser>();
}