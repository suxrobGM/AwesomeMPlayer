using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeMPlayer.Api.Models
{
    public class Playlist : BaseModel
    {
        public Playlist() : base()
        {
            Tracks = new List<TrackPlaylist>();
        }

        public string Name { get; set; }
        public int LikeCount { get; set; }
        public virtual User Author { get; set; }
        public string AuthorId { get; set; }
        public virtual List<TrackPlaylist> Tracks { get; set; }
        public virtual List<UserPlaylist> SubscribedUsers { get; set; }
    }
}
