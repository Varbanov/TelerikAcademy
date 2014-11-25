using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Data;
using TicTacToe.Models;

namespace TicTacToe.Tests.Fakes
{
    public class FakeData : ITicTacToeData
    {
        FakeRepository<ApplicationUser> users;
        FakeRepository<Game> games;


        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.users;
            }
        }

        public IRepository<Game> Games
        {
            get
            {
                return this.games;
            }
        }

        public int SaveChanges()
        {
            var usersChanged = this.Users.SaveChanges();
            var gamesChanged = this.Games.SaveChanges();
            return gamesChanged + usersChanged;
        }
    }
}
