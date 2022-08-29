using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace zdzapi.Models
{
    public class Fornecedor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [ForeignKey("Produto")]
        public int IdProduto{ get; set; }
    }
}
