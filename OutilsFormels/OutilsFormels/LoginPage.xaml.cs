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
using System.Windows.Shapes;

namespace OutilsFormels
{
    /// <summary>
    /// Logique d'interaction pour LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Test if the login and the password correspond to a user in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ValiderFunction(ref User user )
        {
            try
            {
                if (user.login == "" || user.password == "")
                {
                    throw new Exception("Login or Password is empty");
                }
                if(!RegexFunction.isValidstring(user.login,1,40))
                {
                    throw new Exception("Login doesn't correspond to the standard");
                }
                if(!RegexFunction.isValidPassword(user.password))
                {
                    throw new Exception("Password doesn't correspond to the standard");
                }

                BDD mybdd = new BDD();
                User userTest = new User();
                if (mybdd.getUser(user.login, ref userTest) != 1)
                {
                    throw new Exception("Login doesn't exist in the database");
                }
                string hashedPassword = user.password;
                user = userTest;
                return BCrypt.Net.BCrypt.Verify( hashedPassword, user.password);
               
            }
           catch
            {
                return false;
            }

        }

        private void btSignIn_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage Rpage = new RegisterPage();
            Rpage.ShowDialog();
        }

        private void btValider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               User user = new User(0, "", "", "", passwordBox.Password, txtLogin.Text);
               bool IsValid = ValiderFunction(ref user);
               if (IsValid)
                {
                    ViewPage viewPage = new ViewPage(user);
                    viewPage.Show();
                    this.Close();
                }
                else
                {
                    throw new Exception("Login or password incorrect");
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Content = ex.Message;
            }
        }
    }
}
