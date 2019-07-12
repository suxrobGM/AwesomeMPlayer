using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeMPlayer.Api.Models
{
    public class TrackPlaylist
    {
        public virtual Track Track { get; set; }
        public string TrackId { get; set; }

        public virtual Playlist Playlist { get; set; }
        public string PlaylistId { get; set; }
    }
}
