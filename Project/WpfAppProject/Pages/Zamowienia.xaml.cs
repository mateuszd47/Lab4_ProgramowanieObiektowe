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
    /// Logika interakcji dla klasy Zamowienia.xaml
    /// </summary>
    public partial class Zamowienia : Page
    {
        /// <summary>Initializes a new instance of the <see cref="Zamowienia" /> class.</summary>
        public Zamowienia()
        {
            InitializeComponent();
            using (SkelpAkwarystycznyEntities1 db = new SkelpAkwarystycznyEntities1())
            {
                var conDB = from a in db.Zamowienias
                            join b in db.Produkts
                            on a.id_produktu equals b.id_produktu
                            select new
                            {
                                b.nazwa_produktu,
                                a.sztuk,
                                a.czy_odebrano,
                            };
                this.ZamowieniaTab.ItemsSource = conDB.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (idZamowienia.Text == "" || ilosc.Text == "" || odebior.Text == "")
            {
                MessageBox.Show("Empty Data");
            }
            else
            {
                if (int.TryParse(idZamowienia.Text, out int idZ))
                {
                    using (SkelpAkwarystycznyEntities1 db = new SkelpAkwarystycznyEntities1())
                    {
                        Zamowienia zamowienia = new Zamowienia()
                        {
                            
                        };
                    }
                }
            }
        }


        /// <summary>Handles the Refresh event of the Button_Click control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void Button_Click_Refresh(object sender, RoutedEventArgs e)
        {
            using (SkelpAkwarystycznyEntities1 db = new SkelpAkwarystycznyEntities1())
            {
                var conDB = from a in db.Zamowienias
                            join b in db.Produkts
                            on a.id_produktu equals b.id_produktu
                            select new
                            {
                                b.nazwa_produktu,
                                a.sztuk,
                                a.czy_odebrano,
                            };
                this.ZamowieniaTab.ItemsSource = conDB.ToList();
            }
        }

       
    }

    
}
