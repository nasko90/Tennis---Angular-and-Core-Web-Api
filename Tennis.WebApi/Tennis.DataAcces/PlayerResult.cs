using System;
using System.Collections.Generic;

namespace Tennis.DataAcces
{
    public partial class PlayerResult
    {
        public PlayerResult()
        {
            GamePlayerOneResult = new HashSet<Game>();
            GamePlayerTwoResult = new HashSet<Game>();
        }

        public int Id { get; set; }
        public int? PlayerId { get; set; }
        public int Set1 { get; set; }
        public int? Set2 { get; set; }
        public int? Set3 { get; set; }
        public int? Set4 { get; set; }
        public int? Set5 { get; set; }

        public Player Player { get; set; }
        public ICollection<Game> GamePlayerOneResult { get; set; }
        public ICollection<Game> GamePlayerTwoResult { get; set; }
    }
}
