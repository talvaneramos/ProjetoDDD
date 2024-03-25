using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Data.Mappings
{
    internal class DependenteMap : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            builder.ToTable("Dependente");

            builder.HasKey(d => d.IdDependente);

            builder.Property(d => d.IdDependente)
                .HasColumnName("IdDependente");

            builder.Property(d => d.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(d => d.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(d => d.IdFuncionario)
                .HasColumnName("IdFuncionario")
                .IsRequired();

            builder.HasOne(d => d.Funcionario)
                .WithMany(f => f.Dependentes)
                .HasForeignKey(d => d.IdFuncionario);
        }
    }
}
