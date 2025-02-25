using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace NetCoreDemo
{
    class BookEntityConfig:EntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("T_Books");
            builder.Property(b => b.Title).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Price).IsRequired();
            //配置一对多关系：HasOne(...).WithMany(...)
            builder.HasOne(b => b.Author).WithMany(a => a.Books).IsRequired();
        }
    }
   
}
