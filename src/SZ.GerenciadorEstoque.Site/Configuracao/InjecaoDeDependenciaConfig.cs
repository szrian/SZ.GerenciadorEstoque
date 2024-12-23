﻿using SZ.GerenciadorEstoque.Infra.Dados.Modulos;

namespace SZ.GerenciadorEstoque.Site.Configuracao;

public static class InjecaoDeDependenciaConfig
{
	public static IServiceCollection ResolverDependencias(this IServiceCollection servicos, IConfiguration configuracao)
	{
		servicos.AdicionarBancoDeDados(configuracao);

		return servicos;
	}
}
