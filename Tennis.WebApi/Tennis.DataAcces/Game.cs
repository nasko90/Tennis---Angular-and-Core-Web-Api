using System;
using System.Collections.Generic;

namespace Tennis.DataAcces
{
    public partial class Game
    {
        public int Id { get; set; }
        public int? GroundId { get; set; }
        public int? PlayerOneResultId { get; set; }
        public int? PlayerTwoResultId { get; set; }
        public DateTime DatePlayed { get; set; }

        public virtual Ground Ground { get; set; }
        public virtual PlayerResult PlayerOneResult { get; set; }
        public virtual PlayerResult PlayerTwoResult { get; set; }
    }
}
