using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeMPlayer.Api.Models
{
    public class Genre : BaseModel
    {
        public Genre() : base()
        {
            Tracks = new List<Track>();
        }

        public string Name { get; set; }
        public virtual List<Track> Tracks { get; set; }
    }
}
