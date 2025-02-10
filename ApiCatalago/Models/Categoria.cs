using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalago.Models
{
    public class Categoria
    {

        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string? ImagemPath { get; set; }

        public ICollection<Produto>? Produtos { get; set; }

    }
}
