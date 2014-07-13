using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        private string GetFace()
        {
            string face;
            if ((int)this.Face <= 10)
            {
                face = ((int)this.Face).ToString();
            }
            else
            {
                char letter = this.Face.ToString()[0];
                face = letter.ToString();
            }
            return face;
        }

        private string GetResult()
        {
            char suit;
            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    {
                        suit = '♣';
                        break;
                    }
                case CardSuit.Diamonds:
                    {
                        suit = '♦';
                        break;
                    }
                case CardSuit.Hearts:
                    {
                        suit = '♥';
                        break;
                    }
                case CardSuit.Spades:
                    {
                        suit = '♠';
                        break;
                    }
                default:
                    throw new ArgumentException(this.Suit + " is not a valid card suit");
            }
            return suit.ToString();
        }

        public override string ToString()
        {
            string face = GetFace();
            string suit = GetResult();
            string result = face + suit;
            return result;

        }
    }
}
