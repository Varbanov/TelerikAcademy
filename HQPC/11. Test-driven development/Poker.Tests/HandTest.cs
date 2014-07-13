using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void ToStringHand()
        {
            List<Card> cards = new List<Card>(){
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades)
            };

            Hand hand = new Hand(cards.ToArray());
            var excpected = "A♥Q♦K♣7♠4♠";
            var actual = hand.ToString();
            Assert.AreEqual(excpected, actual);
        }
    }
}
