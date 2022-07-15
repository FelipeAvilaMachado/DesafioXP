using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XP.Desafio.Models;

namespace XP.Desafio.Features.Historico
{
    [ObservableObject]
    public partial class HistoricoViewModel
    {
        [ObservableProperty]
        IList<OrdemList> _ordems;

        public HistoricoViewModel()
        {
            var orderns = new List<OrdemList>();
            for (int i = -10; i < 11; i++)
            {
                orderns.Add(new OrdemList(i));
            }
            //ordem aleatoria
            _ordems = orderns.OrderBy(_ => Guid.NewGuid()).ToList();
        }

        [CommunityToolkit.Mvvm.Input.RelayCommand]
        async Task ToggleTest()
        {
            await Task.Delay(100);
        }
    }
}
