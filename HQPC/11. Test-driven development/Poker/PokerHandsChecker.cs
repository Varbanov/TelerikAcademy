using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int handCardNum = 5;

        public bool IsValidHand(IHand hand)
        {
            if (!CheckHandForRepeatingCards(hand) && hand.Cards.Count == handCardNum)
            {
                return true;
            }

            return false;
        }

        public bool IsStraightFlush(IHand hand)
        {
            bool isStraightFlush = false;
            if (IsValidHand(hand))
            {
                IHand orderedHand = OrderHand(hand);
                bool isSameSuit = IsSameSuit(orderedHand);


                if (isSameSuit && IsOrdered(orderedHand, 5))
                {
                    isStraightFlush = true;
                }
            }
            return isStraightFlush;

        }

        private bool IsOrdered(IHand hand, int count)
        {
            bool isOrdered = true;
            int currentCard = (int)hand.Cards[0].Face;
            for (int i = 1; i < count; i++)
            {
                currentCard = currentCard + 1;
                int checkingCard = (int)hand.Cards[i].Face;
                if (currentCard != checkingCard)
                {
                    isOrdered = false;
                    break;
                }
            }
            return isOrdered;

        }

        private IHand OrderHand(IHand hand)
        {
            IList<ICard> orderedCards = new List<ICard>();
            IList<ICard> checkCards = hand.Cards.ToList();
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var minCard = checkCards.Min();
                checkCards.Remove(minCard);
                orderedCards.Add(minCard);
            }
            IHand newHand = new Hand(orderedCards.ToArray());
            return newHand;

        }

        private bool IsSameSuit(IHand hand)
        {
            bool isSameSuit = true;
            CardSuit baseSuit = hand.Cards[0].Suit;
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Suit != baseSuit)
                {
                    isSameSuit = false;
                    break;
                }
            }
            return isSameSuit;

        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (IsValidHand(hand))
            {
                var cardsFound = hand.Cards.ToList().FindAll(x => x.Face == hand.Cards[0].Face);
                if (cardsFound.Count == 4)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            bool result = false;
            if (IsValidHand(hand) && IsSameSuit(hand))
            {
                result = true;
            }
            return result;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }






        private bool CheckHandForRepeatingCards(IHand hand)
        {
            bool result = false;
            IList<ICard> availableCards = hand.Cards.ToList();
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                ICard currentCard = availableCards[i];
                availableCards.Remove(currentCard);
                if (availableCards.Contains(currentCard))
                {
                    return result;
                }

                availableCards.Add(currentCard);
            }

            return result;
        }
    }
}
