using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutilsFormels
{
    public class Card
    {
        public int cardID { get; set; }
        public string number { get; set; }
        public DateTime expiration { get; set; }
        public int type { get; set; }
        public int fk_userID { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cardID">the card's ID</param>
        /// <param name="number">the card's number</param>
        /// <param name="expiration">the expiry date of the credit card</param>
        /// <param name="type">the type of the card</param>
        /// <param name="fk_userID">the card holder</param>
        public Card(int cardID, string number, DateTime expiration, int type, int fk_userID)
        {
            this.cardID = cardID;
            this.number = number;
            this.expiration = expiration;
            this.type = type;
            this.fk_userID = fk_userID;
        }

        public override string ToString()
        {
            return this.number;
        }
    }
}
