using System;
using System.Threading.Tasks;
using System.Windows;

namespace XP.Desafio
{
    public partial class MainWindow : Window
    {
        private const string Home = nameof(Home);
        private const string Historico = nameof(Historico);
        public MainWindow()
        {
            InitializeComponent();
            RootNavigation.PaneTitle = Home;
            RootNavigation.SelectedItem = RootNavigation.MenuItems[0];
            RootFrame.Navigate(new Uri("Features/Home/HomePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private async void RootNavigation_ItemInvoked(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewItemInvokedEventArgs args)
        {
            if(args.InvokedItem is string invokedItem)
            {
                if (invokedItem == Home)
                {
                    if (RootNavigation.PaneTitle == Home) return;
                    RootNavigation.PaneTitle = Home;
                    RootFrame.Navigate(new Uri("Features/Home/HomePage.xaml", UriKind.RelativeOrAbsolute));
                    await Task.Delay(5);
                    RootFrame.RemoveBackEntry();
                    return;
                }
                if (invokedItem == Historico)
                {
                    if (RootNavigation.PaneTitle == Historico) return;
                    RootNavigation.PaneTitle = Historico;
                    RootFrame.Navigate(new Uri("Features/Historico/HistoricoPage.xaml", UriKind.RelativeOrAbsolute));
                    await Task.Delay(5);
                    RootFrame.RemoveBackEntry();
                    return;
                }
            }
        }
    }
}
