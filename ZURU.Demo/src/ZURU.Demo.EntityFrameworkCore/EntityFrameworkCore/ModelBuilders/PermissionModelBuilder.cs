using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using ZURU.Demo.Domain;

namespace ZURU.Demo.EntityFrameworkCore
{
    public static class PermissionModelBuilder
    {
        public static void ConfigurePermissionModel(this ModelBuilder builder)
        {
            builder.Entity<Permission>(b => {

                b.ToTable($"{DemoConsts.DbTablePrefix}Permissions", DemoConsts.DbSchema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd();

                b.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(DemoConsts.Len64)
                .HasComment("权限名称,具有唯一性");

                b.Property(p => p.Desc)
                .HasMaxLength(DemoConsts.Len128)
                .HasComment("描述");

                //自动配置基类中的一些属性
                b.ConfigureByConvention();
            });
        }
    }
}
