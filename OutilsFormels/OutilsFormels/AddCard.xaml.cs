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
    /// Logique d'interaction pour AddCard.xaml
    /// </summary>
    public partial class AddCard : Window
    {
        public int type { get; set; } = 0;
        public int month { get; set; } = 1;
        public User user { get; set; }
        public string number { get; set; }

        public AddCard(User _user)
        {
            InitializeComponent();
            user = _user;
        }

        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            type = cbType.SelectedIndex;
        }

        private void bValidate_Click(object sender, RoutedEventArgs e)
        {
            DateTime expiration = new DateTime(Int32.Parse(tbYear.Text), month, 1);
            number = StringCipher.Encrypt(tbNumber.Text, user.login);
            Card card = new Card(0, number, expiration, type, user.userID);

            BDD mybdd = new BDD();
            mybdd.addCard(card);
        }

        private void cbMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            month = cbMonth.SelectedIndex+1;
        }
    }
}
