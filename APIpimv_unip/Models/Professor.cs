using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public int IdDisciplina { get; set; }
        public Disciplina Disciplina { get; set; }
        public string Login { get; set; }
        public Usuario Usuario { get; set; }
    }
}
