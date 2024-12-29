using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SZ.GerenciadorEstoque.Dominio.Interfaces.Repositorios;
using SZ.GerenciadorEstoque.Infra.Dados.Context;
using SZ.GerenciadorEstoque.Infra.Dados.Repositorios;

namespace SZ.GerenciadorEstoque.Infra.Dados.Modulos;

public static class InstalarDependencias
{
	public static IServiceCollection AdicionarBancoDeDados(this IServiceCollection servicos, IConfiguration configuration)
	{
		servicos.AddDbContext<AppDbContext>(options =>
		options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

		servicos.AddDefaultIdentity<IdentityUser>()
			.AddEntityFrameworkStores<AppDbContext>()
			.AddDefaultTokenProviders();

		return servicos;
	}

	public static IServiceCollection RegistrarRepositorios(this IServiceCollection servicos)
	{
		servicos.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));

		return servicos;
	}
}
