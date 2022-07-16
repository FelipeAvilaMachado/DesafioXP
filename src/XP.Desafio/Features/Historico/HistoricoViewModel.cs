using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using XP.Desafio.Models;
using XP.Desafio.Services;
using XP.Desafio.Services.Models;

namespace XP.Desafio.Features.Historico
{
    [ObservableObject]
    public partial class HistoricoViewModel : IDisposable, IBaseViewModel
    {
        private readonly IDisposable _cleanUp;
        private readonly ReadOnlyObservableCollection<OrdemList> _itemsSource;

        [ObservableProperty]
        bool _paused;

        private SourceCache<Ordem, int> _sourceCache = new SourceCache<Ordem, int>(_ => _.Id);

        public HistoricoViewModel()
        {
            _cleanUp = _sourceCache.Connect()
                .ObserveOn(RxApp.TaskpoolScheduler)
                .BatchIf(this.WhenValueChanged(_ => _.Paused), null, null)
                .Transform(_ => new OrdemList(_))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _itemsSource)
                .DisposeMany()
                .Subscribe(_ =>
                {
                    OnPropertyChanged(nameof(TotalQtd));
                    OnPropertyChanged(nameof(TotalQtdDisponivel));
                });
        }

        public async Task InitializeAsync()
        {
            var ordensService = Ioc.Default.GetRequiredService<IOrdensService>();

            await foreach (var item in ordensService.GetOrdens())
            {
                _sourceCache.AddOrUpdate(item);
            }
        }

        public ReadOnlyObservableCollection<OrdemList> ItemsSource => _itemsSource;
        public int TotalQtd => ItemsSource?.Sum(_ => _.Quantidade) ?? 0;
        public int TotalQtdDisponivel => ItemsSource?.Sum(_ => _.QuantidadeDisponivel) ?? 0;

        [CommunityToolkit.Mvvm.Input.RelayCommand]
        void ToggleTest() => Paused = !Paused;

        public void Dispose() => _cleanUp.Dispose();
    }
}
