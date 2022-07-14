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

            SkelpAkwarystycznyEntities1 db = new SkelpAkwarystycznyEntities1();
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
            SkelpAkwarystycznyEntities1 db = new SkelpAkwarystycznyEntities1();
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

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nazwaProduktu.Text == "" || IDkategoria.Text == "" || cennaNetto.Text == "" || cennaBrutto.Text == "" || ilosc.Text == "")
            {
                MessageBox.Show("Empty Data");
            }
            else
            {
                MessageBox.Show("Dziala do if");
                if (int.TryParse(IDkategoria.Text, out int idK))
                {
                    if (idK > 0 && idK <= 9)
                    {
                        int cN = Int32.Parse(cennaNetto.Text);
                        int cB = Int32.Parse(cennaBrutto.Text);
                        int DS = Int32.Parse(ilosc.Text);
                        SkelpAkwarystycznyEntities db = new SkelpAkwarystycznyEntities();
                        Produkt produkty = new Produkt()
                        {
                            nazwa_produktu = nazwaProduktu.Text,
                            id_kategoria = idK,
                            cena_netto = cN,
                            cena_brutto = cB,
                            dostepnych_sztuk = DS,
                        };

                        db.Produkts.Add(produkty);
                        db.SaveChanges();
                        MessageBox.Show("Dziala");
                    }
                }
            }

        }*/
    }
}
