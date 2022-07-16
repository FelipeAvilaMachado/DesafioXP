using XP.Desafio.Services.Models;

namespace XP.Desafio.Services
{
    public interface IOrdensService
    {
        IAsyncEnumerable<Ordem> GetOrdens();
    }
}
