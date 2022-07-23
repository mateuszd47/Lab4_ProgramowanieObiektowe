using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace WpfAppProject.View
{
    /// <summary>
    /// Logika interakcji dla klasy LoginView.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class LoginView : Window
    {
        /// <summary>
        /// Inicjuje nową instancję <see cref="LoginView" /> class.
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obsługuje zdarzenie MouseDown kontrolki Window.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e"> <see cref="MouseButtonEventArgs" /> instancja zawierająca dane zdarzenia.</param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        /// <summary>
        /// Obsługuje zdarzenie Click kontrolki BtnClose.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e"> <see cref="RoutedEventArgs" /> instancja zawierająca dane zdarzenia.</param>
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Obsługuje zdarzenie Click kontrolki BtnMinimize.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e"> <see cref="RoutedEventArgs" /> instancja zawierająca dane zdarzenia.</param>
        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Obsługuje zdarzenie Click kontrolki BtnLogin.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e"> <see cref="RoutedEventArgs" /> instancja zawierająca dane zdarzenia.</param>
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=MATEUSZ;Initial Catalog=SkelpAkwarystyczny;Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = "SELECT COUNT(1) FROM Users WHERE login=@login AND password=@password";
                SqlCommand sqlCMD = new SqlCommand(query, sqlCon)
                {
                    CommandType = CommandType.Text
                };
                sqlCMD.Parameters.AddWithValue("@login", txtUser.Text);
                sqlCMD.Parameters.AddWithValue("@password", txtPassword.Password);
                int count = Convert.ToInt32(sqlCMD.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow dashbord = new MainWindow();
                    dashbord.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password is iscorrent");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
