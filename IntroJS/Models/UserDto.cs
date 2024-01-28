using System.Collections.Generic;

namespace IntroJS.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public IList<User> Users { get; set; }
        public IList<UserProfile> Profiles { get; set; }

        public UserDto()
        {
            Users = new List<User>();
            Profiles = new List<UserProfile>();
        }
    }
}