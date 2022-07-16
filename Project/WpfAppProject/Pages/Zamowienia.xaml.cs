using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppProject.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Zamowienia.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Page" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class Zamowienia : Page
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Zamowienia"/> class.
        /// </summary>
        public Zamowienia()
        {
            InitializeComponent();
            LoadGrid();
        }
        /// <summary>
        /// The con
        /// </summary>
        SqlConnection con = new SqlConnection(@"Data Source=MATEUSZ;Initial Catalog=SkelpAkwarystyczny;Integrated Security=True");

        /// <summary>
        /// Loads the grid.
        /// </summary>
        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from Zamowienia", con);
            DataTable dt = new System.Data.DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            ZamowieniaTab.ItemsSource = dt.DefaultView;
        }


        /// <summary>
        /// Clears the data.
        /// </summary>
        public void ClearData()
        {
            idPeoduktu.Clear();
            ilosc.Clear();
            odebior.Clear();
        }

        /// <summary>
        /// Validations this instance.
        /// </summary>
        /// <returns></returns>
        private bool Validation()
        {
            if (idPeoduktu.Text == "" || idPeoduktu.Text == null)
                return false;
            if (ilosc.Text == "" || ilosc.Text == null)
                return false;
            if (odebior.Text == "" || odebior.Text == null || int.Parse(odebior.Text) > 1 || int.Parse(odebior.Text) < 0)
                return false;

            return true;
        }


        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!Validation())
            {
                MessageBox.Show("Puste pola danych / {Id}");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Zamowienia VALUES(@id_produktu, @sztuk, @czy_odebrano)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_produktu", idPeoduktu.Text);
                cmd.Parameters.AddWithValue("@sztuk", ilosc.Text);
                cmd.Parameters.AddWithValue("@czy_odebrano", odebior.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LoadGrid();
                MessageBox.Show("Udało sie wysłać");
                ClearData();
            }

        }


        /// <summary>
        /// Handles the Delete event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Zamowienia WHERE id_zamowienia = " + idZamowienia.Text + " ", con);
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
        /// Handles the Update event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            con.Open();
            int ID = int.Parse(idPeoduktu.Text);
            int I = int.Parse(ilosc.Text);
            int T = int.Parse(odebior.Text);
            int KOD = int.Parse(idZamowienia.Text);
            SqlCommand cmd = new SqlCommand("UPDATE Zamowienia SET id_produktu = '" + ID + "' , sztuk = " + I + " , czy_odebrano = '" + T + "' WHERE id_zamowienia = '" + KOD + "' ", con);
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
                con?.Close();
                ClearData();
                LoadGrid();
            }
        }

    }


}
