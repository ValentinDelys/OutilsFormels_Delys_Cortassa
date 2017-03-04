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
    /// Logique d'interaction pour ViewPage.xaml
    /// </summary>
    public partial class ViewPage : Window
    {
        public User user;
        public Card selectedCard { get; set; }

        public ViewPage(User _user)
        {
            user = _user;
            
            InitializeComponent();
            showUserCards();
        }

        private void btAddCard_Click(object sender, RoutedEventArgs e)
        {

            AddCardView addCardView = new AddCardView(user);
            addCardView.ShowDialog();

            if (addCardView.DialogResult.HasValue && addCardView.DialogResult.Value)
            {
                showUserCards();
                MessageBox.Show("Your card has been successfully added ");
            }
        }

        private void showUserCards()
        {
            List<Card> listCards = new List<Card>();
            getUserCards(ref listCards);
            formatCardNumber(ref listCards);

            lvCards.ItemsSource = listCards;
        }

        private void getUserCards(ref List<Card> listCards)
        {
            BDD mybdd = new BDD();
            mybdd.getAllCards(ref user, ref listCards);
        }

        private void removeCard(int cardID)
        {
            BDD mybdd = new BDD();
            mybdd.deleteCard(cardID);
        }

        private void formatCardNumber(ref List<Card> listCards)
        {
            foreach (Card card in listCards)
            {
                card.number = StringCipher.Decrypt(card.number, user.login);
                card.number = "############" + card.number.Substring((card.number.Length - 4), 4);
            }
        }

        private void btRemoveCard_Click(object sender, RoutedEventArgs e)
        {

            if (selectedCard != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Remove Card Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    removeCard(selectedCard.cardID);
                    btRemoveCard.IsEnabled = false;
                    selectedCard = default(Card);
                    showUserCards();
                }
            }
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                selectedCard = (Card)item.Content;
                btRemoveCard.IsEnabled = true;
            }
        }
    }
}
