using System.Collections.Generic;

namespace Tennis.DataAcces
{
    public partial class Ground
    {
        public Ground()
        {
            Game = new HashSet<Game>();
        }

        public int Id { get; set; }
        public int SurfaceId { get; set; }
        public string Name { get; set; }

        public virtual Surface Surface { get; set; }
        public ICollection<Game> Game { get; set; }
    }
}
