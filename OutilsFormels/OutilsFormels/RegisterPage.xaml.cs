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
using OutilsFormels;
using System.Text.RegularExpressions;

namespace OutilsFormels
{
    /// <summary>
    /// Logique d'interaction pour RegisterForm.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btRegister_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                //test des différents champs
                if (!RegexFunction.isValidstring(tbLogin.Text, 1, 30)) { throw new Exception("Login invalid"); }
                if (!RegexFunction.isValidPassword(passwordBox1.Password) && passwordBox1.Password== passwordBox2.Password) { throw new Exception("Password invalid"); }
                if (!RegexFunction.isValidstring(tbFirstName.Text, 1, 40)) { throw new Exception("FirstName invalid"); }
                if (!RegexFunction.isValidstring(tbLastName.Text, 1, 40)) { throw new Exception("LastName invalid"); }
                if (!RegexFunction.isValidEmail(tbEmail.Text)) { throw new Exception("Email invalid"); }

                //verification du login 
                BDD mybdd = new BDD();
                User user = new User();
                if (mybdd.getUser(tbLogin.Text, ref user) == 1)
                {
                    throw new Exception("Login already exist in the database");
                }
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(passwordBox1.Password);
                user = new User(0, tbFirstName.Text, tbLastName.Text, tbEmail.Text, hashedPassword, tbLogin.Text);
                mybdd.addUser(user);
                this.Close();    
            }
            catch(Exception ex)
            {
                lblErrorMsg.Content = ex.Message;
            }
        }
    }
}
