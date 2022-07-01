using System.ComponentModel.DataAnnotations; // stringlength

namespace Biblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [StringLength(100)] //dataanotation define o tipo de dado como varchar  e determina um limite de caractere para  100
        public string Titulo { get; set; }

        [StringLength(100)] //dataanotation define o tipo de dado como varchar  e determina um limite de caractere para  100
        public string Autor { get; set; }
        public int Ano { get; set; }
       
    }
}