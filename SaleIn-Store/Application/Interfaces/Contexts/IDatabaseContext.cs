namespace Application.Interfaces.Contexts
{
    public interface IDatabaseContext
    {
      //  public DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
    }
}
