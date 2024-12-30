using Microsoft.Extensions.DependencyInjection;
using SZ.GerenciadorEstoque.Dominio.Interfaces.Servicos;
using SZ.GerenciadorEstoque.Dominio.Servicos;

namespace SZ.GerenciadorEstoque.Dominio.Modulos;

public static class InstalarDependencias
{
    public static IServiceCollection RegistrarServicosDeDominio(this IServiceCollection servicos)
    {
        servicos.AddScoped<IProdutoServico, ProdutoServico>();

        return servicos;
    }
}
