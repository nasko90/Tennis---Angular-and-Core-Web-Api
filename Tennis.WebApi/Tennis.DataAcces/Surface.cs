using System;
using System.Collections.Generic;

namespace Tennis.DataAcces
{
    public partial class Surface
    {
        public Surface()
        {
            Ground = new HashSet<Ground>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Ground> Ground { get; set; }
    }
}
