using XP.Desafio.Services.Models;

namespace XP.Desafio.Services
{
    public class OrdensService : IOrdensService
    {
        public async IAsyncEnumerable<Ordem> GetOrdens()
        {
            // Para demo, apenas foi implementado o Mock, esta classe foi criada apenas para demostracao
            yield return new Ordem(0,0,0);
            throw new NotImplementedException();
        }
    }
}