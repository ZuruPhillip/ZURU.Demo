using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZURU.Demo.Domain;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ZURU.Demo.Domain.Books;
using ZURU.Demo.EntityFrameworkCore.EntityFrameworkCore.ModelBuilders;

namespace ZURU.Demo.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class DemoDbContext : AbpDbContext<DemoDbContext>
{
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }

    public DemoDbContext(DbContextOptions<DemoDbContext> options)
        : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

#if DEBUG
        //在输出窗口显示Ef生成的sql
        optionsBuilder.LogTo(
            (msg)=>System.Diagnostics.Trace.WriteLine(msg), 
            new[] { RelationalEventId.CommandExecuting },
            Microsoft.Extensions.Logging.LogLevel.Debug
            );
#endif

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePermissionModel();
        builder.ConfigureRoleModel();
        builder.ConfigureUserModel();
        builder.ConfigureBookModel();
    }
}
