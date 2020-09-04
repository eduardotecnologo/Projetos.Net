using System.ComponentModel.DataAnnotations;

namespace lyssamarket.DTO
{
    public class CategoryDTO
    {
        [Required]
        public int Id{get;set;}

        [Required(ErrorMessage="O nome da Categoria é Obrigatório!")]
        [StringLength(20,ErrorMessage="Número grande para categoria, temte um número menor!")]
        [MinLength(3, ErrorMessage="O nome está muito pequeno, tente um nome maior!")]
        public string Name{get;set;}
    }
}