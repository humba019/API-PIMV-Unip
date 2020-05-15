using APIpimv_unip.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Advertencia> Advertencia { get; set; }
        public DbSet<Aula> Aula { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Periodo> Periodo { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public object Emprestismo { get; internal set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Advertencia>().ToTable("ADVERTENCIA");
            builder.Entity<Advertencia>().HasKey(a => a.Id);
            builder.Entity<Advertencia>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Advertencia>().Property(a => a.Descricao).IsRequired().HasMaxLength(100); 
            builder.Entity<Advertencia>().Property(a => a.Nivel).IsRequired().HasMaxLength(2);

            builder.Entity<Advertencia>().HasData(
                new Advertencia { Id = 1, Descricao = "RISCO", Nivel = 12 }
            );

            builder.Entity<Aula>().ToTable("AULA");
            builder.Entity<Aula>().HasKey(a => a.Id);
            builder.Entity<Aula>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Aula>().Property(a => a.Descricao).IsRequired().HasMaxLength(100);
            builder.Entity<Aula>().Property(a => a.Andar).IsRequired().HasMaxLength(2);
            builder.Entity<Aula>().Property(a => a.DataHora).IsRequired();

            builder.Entity<Aula>().HasData(
                new Aula { Id = 1, Descricao = "SALA 23", Andar = 1, IdDisciplina = 1 }
            );

            builder.Entity<Disciplina>().ToTable("DISCIPLINA");
            builder.Entity<Disciplina>().HasKey(d => d.Id);
            builder.Entity<Disciplina>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Disciplina>().Property(d => d.Descricao).IsRequired().HasMaxLength(100);
            builder.Entity<Disciplina>().Property(d => d.CargaHora).IsRequired();
            builder.Entity<Disciplina>().Property(d => d.AreaAcademica).IsRequired();
            builder.Entity<Disciplina>().Property(d => d.AtividadeDisciplina).IsRequired().HasMaxLength(4);
            builder.Entity<Disciplina>().HasMany(d => d.Aulas).WithOne(d => d.Disciplina).HasForeignKey(d => d.IdDisciplina);
            builder.Entity<Disciplina>().HasMany(d => d.Professores).WithOne(d => d.Disciplina).HasForeignKey(d => d.IdDisciplina);

            builder.Entity<Disciplina>().HasData(
                new Disciplina { Id = 1, Descricao = "Filosofia", CargaHora = "30H", AreaAcademica = "Ciencias Humanas", IdPeriodo = 1, AtividadeDisciplina = true}
            );

            builder.Entity<Emprestimo>().ToTable("EMPRESTIMO");
            builder.Entity<Emprestimo>().HasKey(e => e.Id);
            builder.Entity<Emprestimo>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Emprestimo>().Property(e => e.DataEmprestimo).IsRequired();
            builder.Entity<Emprestimo>().Property(e => e.DataDevolucao);
            builder.Entity<Emprestimo>().Property(e => e.RelatorioDevolucao).IsRequired().HasMaxLength(100);
            builder.Entity<Emprestimo>().Property(e => e.AtividadeEmprestimo).IsRequired().HasMaxLength(4);

            builder.Entity<Emprestimo>().HasData(
                new Emprestimo { Id = 1, RelatorioDevolucao = "Perfeito estado.", IdEquipamento = 1, Login = "humba", AtividadeEmprestimo = true }
            );

            builder.Entity<Equipamento>().ToTable("EQUIPAMENTO");
            builder.Entity<Equipamento>().HasKey(e => e.Id);
            builder.Entity<Equipamento>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Equipamento>().Property(e => e.Descricao).IsRequired().HasMaxLength(100);
            builder.Entity<Equipamento>().Property(e => e.Quantidade).IsRequired().HasMaxLength(3);
            builder.Entity<Equipamento>().HasMany(e => e.Emprestimos).WithOne(e => e.Equipamento).HasForeignKey(e => e.IdEquipamento);

            builder.Entity<Equipamento>().HasData(
                new Equipamento { Id = 1, Descricao = "Microfone", Quantidade = 12, IdSetor = 1 }
            );

            builder.Entity<Periodo>().ToTable("PERIODO");
            builder.Entity<Periodo>().HasKey(p => p.Id);
            builder.Entity<Periodo>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Periodo>().Property(p => p.Descricao).IsRequired().HasMaxLength(100);
            builder.Entity<Periodo>().Property(p => p.HoraInicio).IsRequired();
            builder.Entity<Periodo>().Property(p => p.HoraFim).IsRequired();
            builder.Entity<Periodo>().Property(p => p.AtividadePeriodo).IsRequired().HasMaxLength(4);
            builder.Entity<Periodo>().HasMany(p => p.Disciplinas).WithOne(p => p.Periodo).HasForeignKey(p => p.IdPeriodo);

            builder.Entity<Periodo>().HasData(
                new Periodo { Id = 1, Descricao = "NOTURNO", HoraInicio = "22:00", HoraFim = "24:00", AtividadePeriodo = true }
            );

            builder.Entity<Professor>().ToTable("PROFESSOR");
            builder.Entity<Professor>().HasKey(p => p.Id);
            builder.Entity<Professor>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<Professor>().HasData(
                new Professor { Id = 1, IdDisciplina = 1, Login = "humba" }
            );

            builder.Entity<Setor>().ToTable("SETOR");
            builder.Entity<Setor>().HasKey(s => s.Id);
            builder.Entity<Setor>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Setor>().Property(s => s.Descricao).IsRequired().HasMaxLength(100);
            builder.Entity<Setor>().Property(s => s.AtividadeSetor).IsRequired().HasMaxLength(4);
            builder.Entity<Setor>().HasMany(s => s.Equipamentos).WithOne(s => s.Setor).HasForeignKey(s => s.IdSetor);

            builder.Entity<Setor>().HasData(
                new Setor { Id = 1, Descricao = "Audio", AtividadeSetor = true }   
            );

            builder.Entity<Usuario>().ToTable("USUARIO");
            builder.Entity<Usuario>().HasKey(u => u.Login);
            builder.Entity<Usuario>().Property(u => u.Login).IsRequired().ValueGeneratedNever();
            builder.Entity<Usuario>().Property(u => u.Nome);
            builder.Entity<Usuario>().Property(u => u.Sobrenome);
            builder.Entity<Usuario>().Property(u => u.Senha);
            builder.Entity<Usuario>().Property(u => u.Rg);
            builder.Entity<Usuario>().Property(u => u.Cpf);
            builder.Entity<Usuario>().HasMany(u => u.Emprestimos).WithOne(u => u.Usuario).HasForeignKey(u => u.Login);
            builder.Entity<Usuario>().HasMany(u => u.Professores).WithOne(u => u.Usuario).HasForeignKey(u => u.Login);

            builder.Entity<Usuario>().HasData(
                new Usuario { Login = "humba", Nome = "Humberto", Sobrenome = "Barreto", Senha = "1212", Rg = "1221212", Cpf = "122122"}
            );

        }
    }
}
