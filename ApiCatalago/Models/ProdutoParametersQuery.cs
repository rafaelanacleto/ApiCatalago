using System;

namespace ApiCatalago.Models;

public class ProdutoParametersQuery
{
    public int Pagina { get; set; } = 1;
    public int Quantidade { get; set; } = 10;
}
