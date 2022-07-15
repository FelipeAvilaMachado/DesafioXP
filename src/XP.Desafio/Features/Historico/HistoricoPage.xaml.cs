using System.Windows;
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

        private void ToggleButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var isVisible = listOrdernsAberto.Visibility == Visibility.Visible;
            listOrdernsAberto.Visibility = isVisible ? Visibility.Hidden : Visibility.Visible;
            textBlockOrdemAbertoToggleIcon.Text = isVisible ? "" : "";
        }
    }
}
