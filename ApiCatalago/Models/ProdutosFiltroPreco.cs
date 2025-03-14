namespace ApiCatalago.Models;

public class ProdutosFiltroPreco
{
    public decimal? Preco { get; set; }
    public string? PrecoCriterio { get; set; } //maior, igual, menor
    
}