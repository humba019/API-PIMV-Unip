using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Models
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Senha { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public IList<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
        public IList<Professor> Professores { get; set; } = new List<Professor>();
    }
}
