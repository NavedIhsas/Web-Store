using Domain.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Application.Common
{
    public static class SaveChange
    {
        public static int SaveChanges(ShopContext context)
        {
            var modifiedEntries = context.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Deleted || x.State == EntityState.Added);
            foreach (var entry in modifiedEntries)
            {
                var getEntityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());
                if (getEntityType != null)
                {
                    //shodow property
                    var insert = getEntityType.FindProperty("SysUsrCreatedon");
                    var insertBy = getEntityType.FindProperty("SysUsrCreatedby");
                    var updateBy = getEntityType.FindProperty("SysUsrModifiedby");
                    var updateDate = getEntityType.FindProperty("SysUsrModifiedon");


                    if (entry.State == EntityState.Added && insert != null) entry.Property("SysUsrCreatedon").CurrentValue = DateTime.Now;
                    if (entry.State == EntityState.Added && insertBy != null) entry.Property("SysUsrCreatedby").CurrentValue = new Guid();//TODO current user

                    if (entry.State == EntityState.Modified && updateBy != null) entry.Property("SysUsrModifiedon").CurrentValue = DateTime.Now;
                    if (entry.State == EntityState.Modified && updateDate != null)
                        entry.Property("SysUsrModifiedby").CurrentValue = entry.Property("SysUsrCreatedby").CurrentValue = new Guid();//TODO current user
                }
            }
            return context.SaveChanges();
        }
    }
}
