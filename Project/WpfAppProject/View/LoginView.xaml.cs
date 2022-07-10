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
using System.Windows.Shapes;

namespace WpfAppProject.View
{
    /// <summary>
    /// Logika interakcji dla klasy LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
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
                if(count == 1)
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
            catch(Exception ex)
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
