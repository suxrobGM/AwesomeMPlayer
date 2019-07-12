using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeMPlayer.Api.Models
{
    public class Album : BaseModel
    {       
        public Album() : base()
        {
            Tracks = new List<Track>();
            SubscribedUsers = new List<UserAlbum>();
        }

        public string Title { get; set; }
        public string Artist { get; set; }
        public int LikeCount { get; set; }
        public int? ReleaseYear { get; set; }
        public virtual List<Track> Tracks { get; set; }
        public virtual List<UserAlbum> SubscribedUsers { get; set; }
    }
}
