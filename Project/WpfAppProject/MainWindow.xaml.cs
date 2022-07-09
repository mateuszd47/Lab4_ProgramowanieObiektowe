using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppProject.Pages;
using WpfAppProject.View;

namespace WpfAppProject
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginView LoginPage = new LoginView();
            LoginPage.Show();
            this.Close();
        }

        private void BtnKlienci_Click(object sender, RoutedEventArgs e)
        {
            MainPages.Content = new Klienci();
        }

        private void BtnZamowienia_Click(object sender, RoutedEventArgs e)
        {
            MainPages.Content = new Zamowienia();

        }

        private void BtnProdukty_Click(object sender, RoutedEventArgs e)
        {
            MainPages.Content = new Produkty();

        }
    }
}
