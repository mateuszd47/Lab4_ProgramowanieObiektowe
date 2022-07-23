using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppProject.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Produkty.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Page" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class Produkty : Page
    {
        /// <summary>
        /// Inicjuje nową instancję <see cref="Produkty" /> class.
        /// </summary>
        public Produkty()
        {
            InitializeComponent();
            LoadGrid();
        }

        /// <summary>
        /// Połączenie
        /// </summary>
        SqlConnection con = new SqlConnection(@"Data Source=MATEUSZ;Initial Catalog=SkelpAkwarystyczny;Integrated Security=True");

        /// <summary>
        /// Ładowanie bazy
        /// </summary>
        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT id_produktu, nazwa_produktu, cena_netto, cena_brutto, Kategoria.nazwa_kategori, dostepnych_sztuk, dostepny FROM Produkt LEFT JOIN Kategoria ON Produkt.id_kategoria = Kategoria.id_kategoria", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            ProduktTab.ItemsSource = dt.DefaultView;
        }

        /// <summary>
        /// Czyszczenie danych.
        /// </summary>
        public void ClearData()
        {
            nazwaProduktu.Clear();
            IDkategoria.Clear();
            cennaNetto.Clear();
            ilosc.Clear();
            idProdukt.Clear();
        }

        /// <summary>
        /// Walidacje tej instancji.
        /// </summary>
        /// <returns></returns>
        private bool Validation()
        {
            if (nazwaProduktu.Text == "" || nazwaProduktu.Text == null)
                return false;
            if (IDkategoria.Text == "" || IDkategoria.Text == null || int.Parse(IDkategoria.Text) < 0 || int.Parse(IDkategoria.Text) > 9)
                return false;
            if (cennaNetto.Text == "" || cennaNetto.Text == null)
                return false;
            if (ilosc.Text == "" || ilosc.Text == null)
                return false;

            return true;
        }

        /// <summary>
        /// Obsługuje zdarzenie Click kontrolki Button.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e"> <see cref="RoutedEventArgs" /> instancja zawierająca dane zdarzenia.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!Validation())
            {
                MessageBox.Show("Puste pola danych / {Id}");
            }
            else
            {
                bool Dost()
                {
                    decimal i = decimal.Parse(ilosc.Text);
                    if (i > 0)
                        return true;
                    return false;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Produkt VALUES(@nazwa_produktu, @cena_netto, @cena_brutto, @id_kategoria, @dostepnych_sztuk, @dostepny)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nazwa_produktu", nazwaProduktu.Text);
                cmd.Parameters.AddWithValue("@cena_netto", cennaNetto.Text);
                decimal cenaBrutto = decimal.Parse(cennaNetto.Text) * (decimal)1.27;
                cmd.Parameters.AddWithValue("@cena_brutto", cenaBrutto);
                cmd.Parameters.AddWithValue("@id_kategoria", IDkategoria.Text);
                cmd.Parameters.AddWithValue("@dostepnych_sztuk", ilosc.Text);
                cmd.Parameters.AddWithValue("@dostepny", Dost());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LoadGrid();
                MessageBox.Show("Udało sie wysłać");
                ClearData();
            }

        }

        /// <summary>
        /// Obsługuje zdarzenie Delete kontrolki Button_Click.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e"> <see cref="RoutedEventArgs" /> instancja zawierająca dane zdarzenia.</param>
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Produkt WHERE id_produktu = " + idProdukt.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usunięto Rekord");
                con.Close();
                ClearData();
                LoadGrid();
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Nie usunięto rekordu" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Obsługuje zdarzenie Update kontrolki Button_Click..
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e"> <see cref="RoutedEventArgs" /> instancja zawierająca dane zdarzenia.</param>
        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            con.Open();
            decimal cenaBrutto = decimal.Parse(cennaNetto.Text) * (decimal)1.27;
            int dos = 0;
            if (decimal.Parse(ilosc.Text) > 0)
                dos = 1;
            int K = int.Parse(IDkategoria.Text);
            decimal CN = decimal.Parse(cennaNetto.Text);
            int I = int.Parse(ilosc.Text);

            int IDP = int.Parse(idProdukt.Text);
            SqlCommand cmd = new SqlCommand("UPDATE Produkt set nazwa_produktu = '" + nazwaProduktu.Text + "', id_kategoria = " + K + ", cena_netto = " + CN + ", cena_brutto = " + cenaBrutto + ", dostepnych_sztuk = " + I + ", dostepny = " + dos + " WHERE id_produktu = " + IDP + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Aktualizacja rekordu wykonana pomyslnie");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Nie aktualizowano rekordu" + ex.Message);
            }
            finally
            {
                con.Close();
                ClearData();
                LoadGrid();
            }
        }

    }
}
