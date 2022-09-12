using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities
{
    public class UserSocialMediaAddress : Entity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public UserSocialMediaAddress()
        {

        }

        public UserSocialMediaAddress(int id, string name, string url, int userId) : this()
        {
            Id = id;
            Name = name;
            Url = url;
            UserId = userId;
        }
    }
}
