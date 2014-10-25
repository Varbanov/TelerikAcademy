using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Web.Controllers;
using TicTacToe.Data;
using TicTacToe.Tests.Fakes;
using TicTacToe.Web.DataModels;

namespace TicTacToe.Tests
{
    [TestClass]
    public class GameControllerTests
    {

        GameController controller = new GameController(new FakeData());

        [TestInitialize]
        public void GetData()
        {
            this.controller = new GameController(new FakeData());
        }

        [TestMethod]
        public void FirstRowWins()
        {
            var result = controller.CheckGameResult("OOOXOXOXX");
            Assert.AreEqual(GameResult.OWins, result);
        }

        [TestMethod]
        public void SecondRowWins()
        {
            var result = controller.CheckGameResult("OXOXXXOXX");
            Assert.AreEqual(GameResult.XWins, result);
        }

        [TestMethod]
        public void ThirdRowWins()
        {
            var result = controller.CheckGameResult("OXOOXXXXX");
            Assert.AreEqual(GameResult.XWins, result);
        }

        [TestMethod]
        public void SecondColWins()
        {
            var result = controller.CheckGameResult("OXXOXOOXX");
            Assert.AreEqual(GameResult.OWins, result);
        }

        [TestMethod]
        public void DiagonalFromTopLeftWins()
        {
            var result = controller.CheckGameResult("OXOXOXOXO");
            Assert.AreEqual(GameResult.OWins, result);
        }

    }
}
