using System;
using System.ComponentModel.DataAnnotations; // stringlength
using System.ComponentModel.DataAnnotations.Schema;//Columnnamespace Biblioteca.Models



namespace Biblioteca.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        [StringLength(100)] //dataanotation define o tipo de dado como varchar  e determina um limite de caractere para  100
        public string NomeUsuario { get; set; }

        [StringLength(100)] //dataanotation define o tipo de dado como varchar  e determina um limite de caractere para  100
        public string Telefone { get; set; }
        
        [Column(TypeName ="INT")]//dataanotation.Schema converte o campo longtext criado pela migrations para Text
        public bool Devolvido { get; set; }

        
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}