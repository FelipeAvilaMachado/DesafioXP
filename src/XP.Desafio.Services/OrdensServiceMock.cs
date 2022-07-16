using XP.Desafio.Services.Models;

namespace XP.Desafio.Services
{
    public class OrdensServiceMock : IOrdensService
    {
        readonly Random r = new Random();
        readonly int X = 100;

        //Gera/Atualiza uma ordem a cada X milisegundos
        public async IAsyncEnumerable<Ordem> GetOrdens()
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                var maxFor = r.Next(10, 51);
                for (int j = 1; j < maxFor; j++)
                {
                    var reducao = r.Next(-10, 10);
                    var qtdDisp = r.Next(0, 10);
                    yield return new Ordem(j, reducao, qtdDisp);
                }

                await Task.Delay(X);
            }
        }
    }
}