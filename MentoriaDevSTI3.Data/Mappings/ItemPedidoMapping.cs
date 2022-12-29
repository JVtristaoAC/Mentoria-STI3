using MentoriaSTI3.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoriaSTI3.Data.Mappings
{
    public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Valor).HasColumnType("decimal(15,2)").IsRequired();
            builder.Property(x => x.Quantidade).HasColumnType("int").IsRequired();
        }
    }
}
