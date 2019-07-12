using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeMPlayer.Api.Models
{
    public class Track : BaseModel
    {
        public Track() : base()
        {
            TrackPlaylists = new List<TrackPlaylist>();
        }

        public string Title { get; set; }
        public string Artist { get; set; }
        public string ContentPath { get; set; }
        public long Duration { get; set; }
        public int? ReleaseYear { get; set; } 

        public virtual Genre Genre { get; set; }
        public string GenreId { get; set; }

        public virtual Album Album { get; set; }
        public string AlbumId { get; set; }

        public virtual List<TrackPlaylist> TrackPlaylists { get; set; }
    }
}
