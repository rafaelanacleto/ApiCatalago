using System.Collections.ObjectModel;

namespace ApiCatalago.Models
{
    public class Categoria
    {

        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? ImagemPath { get; set; }
        public ICollection<Produto>? Produtos { get; set; }

    }
}
