using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SZ.GerenciadorEstoque.Infra.Dados.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext(options)
{
	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		base.OnModelCreating(builder);

		foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.EnableSensitiveDataLogging();
	}
}
