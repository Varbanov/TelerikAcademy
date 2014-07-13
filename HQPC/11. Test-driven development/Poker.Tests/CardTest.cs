using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void ToStringAceSpades()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            var excpected = "A♠";
            var actual = card.ToString();
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void ToStringTwoClubs()
        {
            Card card = new Card(CardFace.Two, CardSuit.Clubs);
            var excpected = "2♣";
            var actual = card.ToString();
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void ToStringJackHearts()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Hearts);
            var excpected = "J♥";
            var actual = card.ToString();
            Assert.AreEqual(excpected, actual);
        }

    }
}
