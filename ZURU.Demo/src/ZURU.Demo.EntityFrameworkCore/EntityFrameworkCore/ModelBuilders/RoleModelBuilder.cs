using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using ZURU.Demo.Domain;

namespace ZURU.Demo.EntityFrameworkCore
{
    public static class RoleModelBuilder
    {
        public static void ConfigureRoleModel(this ModelBuilder builder)
        {
            builder.Entity<Role>(b => {

                //自动配置基类中的一些属性
                b.ConfigureByConvention();

                //配置扩展字段(ExtraProperties)
                b.ApplyObjectExtensionMappings();


                b.ToTable($"{DemoConsts.DbTablePrefix}Roles", DemoConsts.DbSchema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd();

                b.Property(p => p.IsDefault)
                .IsRequired()
                .HasComment("是否是默认角色");

                b.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(DemoConsts.Len64)
                .HasComment("角色名称");

                b.Property(p => p.Desc)
                .HasMaxLength(DemoConsts.Len128)
                .HasComment("描述");

                //b.HasMany<PermissionGrant>().WithOne().HasForeignKey(x => x.RoleId).IsRequired();

                b.HasIndex(p=>p.Name);
            });

            builder.Entity<PermissionGrant>(b => {

                //自动配置基类中的一些属性
                b.ConfigureByConvention();

                b.ToTable($"{DemoConsts.DbTablePrefix}PermissionGrants", DemoConsts.DbSchema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd();

                b.HasIndex(p => p.RoleId);
            });
        }
    }
}
