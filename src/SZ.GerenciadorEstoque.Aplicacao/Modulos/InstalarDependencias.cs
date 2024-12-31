using Microsoft.Extensions.DependencyInjection;
using SZ.GerenciadorEstoque.Aplicacao.Conversores;
using SZ.GerenciadorEstoque.Aplicacao.Interfaces;
using SZ.GerenciadorEstoque.Aplicacao.Servicos;

namespace SZ.GerenciadorEstoque.Aplicacao.Modulos;

public static class InstalarDependencias
{
	public static IServiceCollection RegistrarServicosAppService(this IServiceCollection servicos)
	{
		servicos.AddScoped<IProdutoConversor, ProdutoConversor>();

		servicos.AddScoped<IAccountAppService, AccountAppService>();
		servicos.AddScoped<IProdutoAppService, ProdutoAppService>();

		return servicos;
	}
}
