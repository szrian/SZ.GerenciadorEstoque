using System.Linq.Expressions;

namespace SZ.GerenciadorEstoque.Dominio.Interfaces.Repositorios;

public interface IRepositorioBase<TEntidade> : IDisposable where TEntidade : class
{
    Task AdicionarAsync(TEntidade entidade);
    void Atualizar(TEntidade entidade);
    Task<IEnumerable<TEntidade>> ObterTodosAsync();
    Task<IEnumerable<TEntidade>> ObterTodosPaginadoAsync(int skip, int take);
    Task<IEnumerable<TEntidade>> BuscarAsync(Expression<Func<TEntidade, bool>> exp);
    Task<TEntidade> ObterPorIdAsync(Guid id);
    Task Remover(Guid id);
    Task<int> CommitAsync();
    int Commit();
}
