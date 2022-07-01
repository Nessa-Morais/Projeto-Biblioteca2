using System.ComponentModel.DataAnnotations; // stringlength
using System.ComponentModel.DataAnnotations.Schema;//Columnnamespace Biblioteca.Models


namespace Biblioteca.Models
{
    public class Usuario
    {
        public static int ADMIN = 0;
        public static int PADRAO = 1;

        public int Id{get; set;}
        
        [StringLength(100)] //dataanotation define o tipo de dado como varchar  e determina um limite de caractere para  100

        public string Nome{get; set;}

        [StringLength(100)] //dataanotation define o tipo de dado como varchar  e determina um limite de caractere para  100

        public string Login {get; set;}

        [StringLength(100)] //dataanotation define o tipo de dado como varchar  e determina um limite de caractere para  100

        public string Senha{get; set;}

        
        [Column(TypeName ="INT")]//dataanotation.Schema converte o campo longtext criado pela migrations para Text

        public int Tipo {get; set;}

        public Usuario(){
            
        }
        
    }
}