using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using SZ.GerenciadorEstoque.Dominio.Interfaces.Repositorios;
using SZ.GerenciadorEstoque.Infra.Dados.Context;

namespace SZ.GerenciadorEstoque.Infra.Dados.Repositorios;

public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : class
{
    private readonly AppDbContext _context;

    public RepositorioBase(AppDbContext context)
    {
        _context = context;
        _context.Database.GetDbConnection();
    }

    public async Task AdicionarAsync(TEntidade entidade)
    {
        await _context.Set<TEntidade>().AddAsync(entidade);
        await CommitAsync();
    }

    public void Atualizar(TEntidade entidade)
    {
        _context.Set<TEntidade>().Update(entidade);
        Commit();
    }

    public async Task<IEnumerable<TEntidade>> BuscarAsync(Expression<Func<TEntidade, bool>> exp)
    {
        var entidades = await _context.Set<TEntidade>()
            .AsNoTracking()
            .Where(exp)
            .ToListAsync();

        return entidades;
    }

    public int Commit() => _context.SaveChanges();

    public Task<int> CommitAsync() => _context.SaveChangesAsync();

    public async Task<TEntidade> ObterPorIdAsync(Guid id)
    {
        var entidade = await _context.Set<TEntidade>().FindAsync(id);

        return entidade;
    }

    public async Task<IEnumerable<TEntidade>> ObterTodosAsync()
    {
        var entidades = await _context.Set<TEntidade>().ToListAsync();

        return entidades;
    }

    public async Task<IEnumerable<TEntidade>> ObterTodosPaginadoAsync(int skip, int take)
    {
        var entidades = await _context.Set<TEntidade>()
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        return entidades;
    }

    public async Task Remover(Guid id)
    {
        var obj = await ObterPorIdAsync(id);
        _context.Set<TEntidade>().Remove(obj);

        Commit();
    }

    public void Dispose() => _context.Dispose();
}
