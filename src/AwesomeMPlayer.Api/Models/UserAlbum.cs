namespace AwesomeMPlayer.Api.Models
{
    public class UserAlbum
    {
        public virtual User User { get; set; }
        public string UserId { get; set; }

        public virtual Album Album { get; set; }
        public string AlbumId { get; set; }
    }
}