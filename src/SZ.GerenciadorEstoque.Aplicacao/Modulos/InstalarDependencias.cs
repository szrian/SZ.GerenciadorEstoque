using Microsoft.Extensions.DependencyInjection;
using SZ.GerenciadorEstoque.Aplicacao.Interfaces;
using SZ.GerenciadorEstoque.Aplicacao.Servicos;

namespace SZ.GerenciadorEstoque.Aplicacao.Modulos;

public static class InstalarDependencias
{
	public static IServiceCollection RegistrarServicosAppService(this IServiceCollection servicos)
	{
		servicos.AddScoped<IAccountAppService, AccountAppService>();

		return servicos;
	}
}
