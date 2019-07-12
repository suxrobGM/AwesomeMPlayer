using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeMPlayer.Api.Models
{
    public class UserPlaylist
    {
        public virtual User User { get; set; }
        public string UserId { get; set; }

        public virtual Playlist Playlist { get; set; }
        public string PlaylistId { get; set; }
    }
}
