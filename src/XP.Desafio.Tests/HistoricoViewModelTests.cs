using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using XP.Desafio.Features.Historico;
using XP.Desafio.Models;
using XP.Desafio.Services;

namespace XP.Desafio.Tests
{
    [TestClass()]
    public class HistoricoViewModelTests
    {
        //Inicializa o Ioc apenas 1 vez.
        private static bool isInitialized;
        private static void Initialize()
        {
            if (isInitialized) return;
            isInitialized = true;
            var services = new ServiceCollection();
            services.AddTransient<IOrdensService, OrdensServiceMock>();
            Ioc.Default.ConfigureServices(services.BuildServiceProvider());
        }

        //Testa se a lista esta alterando com os valores aleatorios
        [TestMethod()]
        public async Task TestListUpdating()
        {
            Initialize();
            var vm = new HistoricoViewModel();
            //executa sem esperar o resultado, pois o metodo roda 'sem fim'
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Task.Run(async () => await vm.InitializeAsync());
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            await Task.Delay(300);
            vm.Paused = true;
            var items1 = vm.ItemsSource.ToList();
            await Task.Delay(300);
            vm.Paused = false;
            await Task.Delay(300);
            vm.Paused = true;
            var items2 = vm.ItemsSource.ToList();
            Assert.IsNotNull(items1);
            Assert.IsFalse(items1 == new List<OrdemList>());
            Assert.AreNotEqual(items1, items2);
        }

        //Testa se o toggle no update esta funcionando
        [TestMethod()]
        public async Task TestListPaused()
        {
            Initialize();
            var vm = new HistoricoViewModel();
            //executa sem esperar o resultado, pois o metodo roda 'sem fim'
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Task.Run(async () => await vm.InitializeAsync());
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            await Task.Delay(300);
            vm.Paused = true;
            var items1 = vm.ItemsSource.ToList();
            await Task.Delay(300);
            await Task.Delay(300);
            var items2 = vm.ItemsSource.ToList();

            Assert.IsNotNull(items1);
            Assert.IsFalse(items1 == new List<OrdemList>());
            Assert.IsTrue(items1.SequenceEqual(items2));
        }
    }
}