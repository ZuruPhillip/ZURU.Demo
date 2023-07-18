using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using ZURU.Demo.Domain;
using ZURU.Demo.Domain.Books;

namespace ZURU.Demo.EntityFrameworkCore.EntityFrameworkCore.ModelBuilders
{
    public static class BookModelBuilder
    {
        public static void ConfigureBookModel(this ModelBuilder builder)
        {
            builder.Entity<Book>(b =>
            {

                b.ToTable($"{DemoConsts.DbTablePrefix}Books", DemoConsts.DbSchema).HasKey(p => p.Id);

                b.Property(p => p.Id).ValueGeneratedOnAdd();

                b.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(DemoConsts.Len128)
                .HasComment("书名");

                //自动配置基类中的一些属性
                b.ConfigureByConvention();
            });
        }
    }
}
