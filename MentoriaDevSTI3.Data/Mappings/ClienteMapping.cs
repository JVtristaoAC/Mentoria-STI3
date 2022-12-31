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
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(255)").IsRequired();
            builder.Property(x => x.Cep).HasColumnType("char(8)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("char(255)").IsRequired();
            builder.Property(x => x.Cidade).HasColumnType("char(100)").IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnType("date").IsRequired();
            
        }
    }
}
