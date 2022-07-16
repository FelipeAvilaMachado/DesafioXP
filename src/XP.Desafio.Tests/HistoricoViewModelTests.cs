using XP.Desafio.Features.Historico;
using XP.Desafio.Models;

namespace XP.Desafio.Tests
{
    [TestClass]
    public class HistoricoViewModelTests
    {
        [WpfTestMethod]
        public async Task TestMethod1()
        {
            var vm = new HistoricoViewModel();
            //executa sem esperar o resultado, pois o metodo roda 'sem fim'
            Task.Run(async () => await vm.InitializeAsync());

            await Task.Delay(100);
            vm.Paused = true;
            var items1 = vm.ItemsSource.ToList();
            await Task.Delay(100);
            vm.Paused = false;
            await Task.Delay(100);
            vm.Paused = true;
            var items2 = vm.ItemsSource.ToList();
            Assert.IsNotNull(items1);
            Assert.IsFalse(items1 == new List<OrdemList>());
            Assert.AreNotEqual(items1, items2);
        }
    }
}