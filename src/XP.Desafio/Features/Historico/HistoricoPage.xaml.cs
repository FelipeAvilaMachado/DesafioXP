using System.Windows.Controls;

namespace XP.Desafio.Features.Historico
{
    /// <summary>
    /// Interaction logic for HistoricoPage.xaml
    /// </summary>
    public partial class HistoricoPage : Page
    {
        public HistoricoPage()
        {
            InitializeComponent();
            DataContext = new HistoricoViewModel();
        }
    }
}
