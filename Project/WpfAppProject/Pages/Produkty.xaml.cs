using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        /// <summary>Initializes a new instance of the <see cref="Produkty" /> class.</summary>
        public Produkty()
        {   
            InitializeComponent();
            LoadGrid();
        }

        SqlConnection con = new SqlConnection(@"Data Source=MATEUSZ;Initial Catalog=SkelpAkwarystyczny;Integrated Security=True");

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from Produkt", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            ProduktTab.ItemsSource = dt.DefaultView;
        }

        public void ClearData()
        {
            nazwaProduktu.Clear();
            IDkategoria.Clear();
            cennaNetto.Clear();
            ilosc.Clear();
            idProdukt.Clear();
        }

        private bool Validation()
        {
            if(nazwaProduktu.Text == "" || nazwaProduktu.Text == null)
                return false;
            if (IDkategoria.Text == "" || IDkategoria.Text == null)
                return false;
            if (cennaNetto.Text == "" || cennaNetto.Text == null)
                return false;
            if (ilosc.Text == "" || ilosc.Text == null)
                return false;

            return true;
        }

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

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Produkt WHERE id_produktu = " +idProdukt.Text+" ", con);
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
                MessageBox.Show("Nie usunięto rekordu"+ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            decimal cenaBrutto = decimal.Parse(cennaNetto.Text) * (decimal)1.27;
            bool dos = false;
            if (decimal.Parse(ilosc.Text) > 0)
                dos = true;
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Produkt set " +
                "nazwa_produktu = " + nazwaProduktu.Text +
                ", id_kategoria = " + IDkategoria.Text +
                ", cena_netto = " + cennaNetto.Text +
                ", cena_brutto = " + cenaBrutto +
                ", dostepnych_sztuk = " + ilosc.Text +
                ", dostepny = " + dos + "" +
                idProdukt.Text+"", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Aktualizacja rekordu wykonana pomyslnie");
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Nie aktualizowano rekordu" + ex.Message);
            }
            finally
            {
                con?.Close();
                ClearData();
                LoadGrid();
            }
        }
    }
}
