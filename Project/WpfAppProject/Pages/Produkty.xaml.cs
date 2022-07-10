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
    /// Logika interakcji dla klasy Produkty.xaml
    /// </summary>
    public partial class Produkty : Page
    {
        public Produkty()
        {   
            InitializeComponent();

            SkelpAkwarystycznyEntities db = new SkelpAkwarystycznyEntities();
            var conDB = from a in db.Produkts
                        join b in db.Kategorias
                        on a.id_kategoria equals b.id_kategoria
                        select new
                        {
                            a.nazwa_produktu,
                            b.nazwa_kategori,
                            a.cena_netto,
                            a.cena_brutto,
                            a.dostepnych_sztuk,
                            a.dostepny,
                        };
            this.ProduktTab.ItemsSource = conDB.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idK;

            if (nazwaProduktu.Text == "" || IDkategoria.Text == "" || cennaNetto.Text == "" || cennaBrutto.Text == "" || ilosc.Text == "")
            {
                MessageBox.Show("Empty Data");
            }
            else
            {
                MessageBox.Show("Dziala do if");
                if (int.TryParse(IDkategoria.Text, out idK))
                {
                    if(idK>0 && idK <= 9)
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

        }

        private void Button_Click_Refresh(object sender, RoutedEventArgs e)
        {
            SkelpAkwarystycznyEntities db = new SkelpAkwarystycznyEntities();
            var conDB = from a in db.Produkts
                        join b in db.Kategorias
                        on a.id_kategoria equals b.id_kategoria
                        select new
                        {
                            a.nazwa_produktu,
                            b.nazwa_kategori,
                            a.cena_netto,
                            a.cena_brutto,
                            a.dostepnych_sztuk,
                            a.dostepny,
                        };
            this.ProduktTab.ItemsSource = conDB.ToList();
        }
    }
}
