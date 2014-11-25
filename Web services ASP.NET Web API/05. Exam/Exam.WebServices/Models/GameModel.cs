using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;

namespace Exam.WebServices.Models
{
    public class GameModel
    {
        //TODO : solve parsing exception and refactor

        public static Expression<Func<Game, GameModel>> FromGame
        {
            get
            {
                return g => new GameModel
                {
                    Blue = g.BluePlayer.UserName,
                    DateCreated = g.DateCreated,
                    GameState = g.State.ToString(),
                    Id = g.Id,
                    Name = g.Name,
                    Red = g.RedPlayer.UserName,
                };
            }
        }

        public GameModel()
        {
            this.Blue = "No blue player yet";
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }

        public string Blue { get; set; }
        public string Red { get; set; }
        public string GameState { get; set; }
        public DateTime DateCreated { get; set; }


    }
}