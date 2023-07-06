using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using ZURU.Demo.Domain;

namespace ZURU.Demo.EntityFrameworkCore
{
    public static class UserModelBuilder
    {
        public static void ConfigureUserModel(this ModelBuilder builder)
        {
            builder.Entity<User>(b => {

                //自动配置基类中的一些属性
                b.ConfigureByConvention();

                //配置扩展字段(ExtraProperties)
                b.ApplyObjectExtensionMappings();

                b.ToTable($"{DemoConsts.DbTablePrefix}Users", DemoConsts.DbSchema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd();

                b.Property(p => p.UserName)
                .IsRequired()
                .HasMaxLength(DemoConsts.Len64)
                .HasComment("用户名");

                b.Property(p => p.Password)
                .HasMaxLength(DemoConsts.Len256)
                .HasComment("密码");

                b.OwnsOne(s => s.Profile, (p) => {

                    p.Property(p => p.Mobile)
                    .HasColumnName("Mobile")
                    .HasComment("手机号")
                    .IsRequired()
                    .HasMaxLength(DemoConsts.Len32);

                    p.Property(p => p.Email)
                    .HasColumnName("Email")
                    .HasComment("邮箱")
                    .IsRequired(false)
                    .HasMaxLength(DemoConsts.Len64);

                    p.Property(p => p.Address)
                    .HasColumnName("Address")
                    .HasComment("联系地址")
                    .IsRequired(false)
                    .HasMaxLength(DemoConsts.Len256);
                });

                b.HasIndex(p => p.UserName);
            });

            builder.Entity<UserRole>(b => {

                //自动配置基类中的一些属性
                b.ConfigureByConvention();

                b.ToTable($"{DemoConsts.DbTablePrefix}UserRoles", DemoConsts.DbSchema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd();

                b.HasIndex(p => p.UserId);
            });
        }
    }
}
