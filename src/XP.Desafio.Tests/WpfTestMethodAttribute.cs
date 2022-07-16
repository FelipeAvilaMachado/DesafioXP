using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using XP.Desafio.Services;

namespace XP.Desafio.Tests
{
    public class WpfTestMethodAttribute : TestMethodAttribute
    {
        // Configura os servicos e threads
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IOrdensService, OrdensServiceMock>();
            Ioc.Default.ConfigureServices(services.BuildServiceProvider());

            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
                return Invoke(testMethod);

            TestResult[] result = null;
            var thread = new Thread(() => result = Invoke(testMethod));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return result;
        }

        private TestResult[] Invoke(ITestMethod testMethod)
        {
            return new[] { testMethod.Invoke(null) };
        }
    }
}
