using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreCalculator
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public List<Player> FinalStandings { get; set; }

        public Game() { 
            Players = new List<Player>();
            FinalStandings = new List<Player>();
        }

        public void AddPlayer(string name) { 
            Players.Add(new Player(name));
        }
        public void CalculateStandings() {
            FinalStandings.AddRange(Players.OrderByDescending(p => p.FinalScore));
        }
    }
}
