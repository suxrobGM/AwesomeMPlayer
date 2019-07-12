using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeMPlayer.Api.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            SubscribedPlaylists = new List<UserPlaylist>();
            SubscribedAlbums = new List<UserAlbum>();
            OwnPlaylists = new List<Playlist>();
        }

        public virtual List<Playlist> OwnPlaylists { get; set; }
        public virtual List<UserPlaylist> SubscribedPlaylists { get; set; }
        public virtual List<UserAlbum> SubscribedAlbums { get; set; }     
    }
}
