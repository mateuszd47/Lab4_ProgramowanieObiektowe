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

namespace WpfAppProject.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Klienci.xaml
    /// </summary>
    public partial class Klienci : Page
    {
        /// <summary>Initializes a new instance of the <see cref="Klienci" /> class.</summary>
        public Klienci()
        {
            InitializeComponent();

            SkelpAkwarystycznyEntities db = new SkelpAkwarystycznyEntities();
            var conDB = from a in db.Kliencis
                        select new
                        {
                            a.imie,
                            a.nazwisko,
                            a.telefon,
                            a.adres_email,
                            a.kodpocztowy,
                            a.miejscowośc,
                            a.klient_staly,
                        };
            this.KlienciTab.ItemsSource = conDB.ToList();

        }


        /// <summary>Handles the Refresh event of the Button_Click control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void Button_Click_Refresh(object sender, RoutedEventArgs e)
        {
            SkelpAkwarystycznyEntities db = new SkelpAkwarystycznyEntities();
            var conDB = from a in db.Kliencis
                        select new
                        {
                            a.imie,
                            a.nazwisko,
                            a.telefon,
                            a.adres_email,
                            a.kodpocztowy,
                            a.miejscowośc,
                            a.klient_staly,
                        };
            this.KlienciTab.ItemsSource = conDB.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
