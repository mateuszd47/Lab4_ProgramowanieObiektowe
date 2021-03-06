using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppProject.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Klienci.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Page" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class Klienci : Page
    {
        /// <summary>
        /// Inicjuje nową instancję <see cref="Klienci" /> class.
        /// </summary>
        public Klienci()
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM Klienci", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            KlienciTab.ItemsSource = dt.DefaultView;
        }

        /// <summary>
        /// Czyszczenie danych.
        /// </summary>
        public void ClearData()
        {
            imie.Clear();
            nazwsiko.Clear();
            telefon.Clear();
            adrese.Clear();
            kodPoczatowy.Clear();
            adres.Clear();
            stalyKlient.Clear();
        }

        /// <summary>
        /// Walidacje tej instancji.
        /// </summary>
        /// <returns></returns>
        private bool Validation()
        {
            if (imie.Text == "" || imie.Text == null)
                return false; 
            if (nazwsiko.Text == "" || nazwsiko.Text == null)
                return false;
            if (telefon.Text == "" || telefon.Text == null )
                return false;
            if (adrese.Text == "" || adrese.Text == null)
                return false;
            if (kodPoczatowy.Text == "" || kodPoczatowy.Text == null)
                return false;
            if (adres.Text == "" || adres.Text == null)
                return false;
            if (stalyKlient.Text == "" || stalyKlient.Text == null || int.Parse(stalyKlient.Text) < 0 || int.Parse(stalyKlient.Text) > 1)
                return false;

            return true;
        }

        /// <summary>
        /// Obsługuje zdarzenie Click kontrolki Button.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e"> <see cref="RoutedEventArgs"/> instancja zawierająca dane zdarzenia.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!Validation())
            {
                MessageBox.Show("Puste pola danych / {Id}");
            }
            else
            {
                bool Stal()
                {
                    decimal i = decimal.Parse(stalyKlient.Text);
                    if (i > 0)
                        return true;
                    return false;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Klienci VALUES(@imie, @nazwisko, @telefon, @adres_email, @adres, @kodpocztowy, @klient_staly)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@imie", imie.Text);
                cmd.Parameters.AddWithValue("@nazwisko", nazwsiko.Text);
                cmd.Parameters.AddWithValue("@telefon", telefon.Text);
                cmd.Parameters.AddWithValue("@adres_email", adrese.Text);
                cmd.Parameters.AddWithValue("@kodpocztowy", kodPoczatowy.Text);
                cmd.Parameters.AddWithValue("adres", adres.Text);
                cmd.Parameters.AddWithValue("@klient_staly", Stal());
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
        /// <param name="e"> <see cref="RoutedEventArgs" /> Instancja zawierająca dane zdarzenia.</param>
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Klienci WHERE id_klient = " + idKlient.Text + " ", con);
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
        /// Obsługuje zdarzenie Update kontrolki Button_Click.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e"><see cref="RoutedEventArgs" /> Instancja zawierająca dane zdarzenia.</param>
        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            con.Open();
            int T = int.Parse(telefon.Text);
            int KS = 0;
            if (decimal.Parse(stalyKlient.Text) > 0)
                KS = 1;

            int IDP = int.Parse(idKlient.Text);
            SqlCommand cmd = new SqlCommand("UPDATE Klienci SET imie = '" + imie.Text + "', nazwisko = '" + nazwsiko.Text + "', telefon = '" + T + "', adres_email = '" + adrese.Text + "', kodpocztowy = '" + kodPoczatowy.Text + "', adres = '" + adres.Text + "', klient_staly= '" + KS + "' WHERE id_klient = '" + idKlient.Text + "'", con);
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
