using System;
using System.Collections.Generic;

namespace Tennis.DataAcces
{
    public partial class Player
    {
        public Player()
        {
            PlayerResult = new HashSet<PlayerResult>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PlayerResult> PlayerResult { get; set; }
    }
}
