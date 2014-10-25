namespace Exam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Game
    {
        private User secondPlayer;

        public Game()
        {
            this.State = GameState.WaitingForOpponent;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        public GameState State { get; set; }

        [Required]
        public int RedPlayerId { get; set; }

        public User RedPlayer { get; set; }

        public User BluePlayer
        {
            get
            {
                return this.secondPlayer;
            }
            set
            {
                this.secondPlayer = value;
             
                //choose randomly whos turn it is
                //var random = new Random();
                //int startPlayerGuess = random.Next(1, 3);
                //if (startPlayerGuess == 1)
                //{
                //    this.State = GameState.RedInTurn;
                //}
                //else
                //{
                //    this.State = GameState.BlueInTurn;
                //}
            }
        }

        public int BluePlayerId { get; set; }

        public string RedPlayerGuess { get; set; }
        public string BluePlayerGuess { get; set; }


    }
}
