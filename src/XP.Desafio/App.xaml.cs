using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using XP.Desafio.Services;

namespace XP.Desafio
{
    public partial class App : Application
    {
        public static bool IsTestMode { get; set; } = false;

        public App()
        {
            //Permite rodar em teste mesmo fora do debug
            if (Environment.GetEnvironmentVariable(nameof(IsTestMode)) == "True")
                IsTestMode = true;

#if DEBUG
            //Forca modo test em debug, apenas para facilitar o demo
            IsTestMode = true;
#endif

            ConfigureServices();
            InitializeComponent();
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            //Implementacoes diferentes baseadas em teste
            if (IsTestMode)
            {
                services.AddSingleton<IOrdensService, OrdensServiceMock>();
            }
            else
            {
                services.AddSingleton<IOrdensService, OrdensService>();
            }

            Ioc.Default.ConfigureServices(services.BuildServiceProvider());
        }
    }
}
