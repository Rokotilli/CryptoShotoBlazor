using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Follower
    {
        public int Id { get; set; }

        public int FollowerId { get; set; }
        public User follower { get; set; }

        public int IdleId { get; set; }
        public User idle { get; set; }
    }
}