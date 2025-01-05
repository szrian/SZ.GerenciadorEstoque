using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SZ.GerenciadorEstoque.Aplicacao.Configuracoes;
using SZ.GerenciadorEstoque.Aplicacao.Conversores;
using SZ.GerenciadorEstoque.Aplicacao.Interfaces;
using SZ.GerenciadorEstoque.Aplicacao.Servicos;

namespace SZ.GerenciadorEstoque.Aplicacao.Modulos;

public static class InstalarDependencias
{
	public static IServiceCollection RegistrarServicosAppService(this IServiceCollection servicos)
	{
		servicos.AddScoped<IProdutoConversor, ProdutoConversor>();
		servicos.AddScoped<IImagemProdutoConversor, ImagemProdutoConversor>();

		servicos.AddScoped<IAccountAppService, AccountAppService>();
		servicos.AddScoped<IProdutoAppService, ProdutoAppService>();
		servicos.AddScoped<IImagemProdutoAppService, ImagemProdutoAppService>();

		return servicos;
	}

    public static IServiceCollection AdicionarConfiguracaoImagem(this IServiceCollection servicos, IConfiguration configuracoes)
    {
        var imagemConfig = new ImagemConfiguracao();
        configuracoes.Bind("ConfiguracaoImagem", imagemConfig);

        servicos.AddSingleton(imagemConfig);

        return servicos;
    }
}
