using Faker;
using IntroJS.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace IntroJS.Controllers
{
    public class UserProfileController : ApiController
    {
        private readonly IList<UserProfile> _userProfiles;

        public UserProfileController()
        {
            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 8
            };

            _userProfiles = CreateUserProfileList();

            Parallel.For(0, 10, options, i =>
            {
                for (int j = 0; j < 10; ++j)
                {
                    var userProfile = CreateUserProfile();
                    _userProfiles.Add(userProfile);
                }
            });
        }

        // GET api/<controller>
        public async Task<IHttpActionResult> Get()
        {
            var userProfiles = await Task.FromResult(_userProfiles);
            return Ok(userProfiles);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] UserDto userDto)
        {
            return Ok();
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody] UserDto userDto)
        {
            return Ok();
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }

        private IList<User> CreateUserList()
        {
            return new SynchronizedList<User>();
        }

        private IList<UserProfile> CreateUserProfileList()
        {
            return new SynchronizedList<UserProfile>();
        }

        private UserProfile CreateUserProfile()
        {
            var userProfile = new UserProfile();

            userProfile.Name = Faker.Name.FullName(NameFormats.WithPrefix);
            // "Mrs. Jerod Nader"

            userProfile.Followers = Faker.RandomNumber.Next(0, 10000);
            // 3452

            userProfile.Area = $"{Faker.Address.Country()}, {Faker.Address.City()}";
            // "Fiji, Wavaland"

            userProfile.Bio = String.Join(" ", Faker.Lorem.Sentences(3));
            // "Ea voluptas maiores nihil quia et eum. Vel et eos est architecto rerum est. Eum esse voluptatem ab necessitatibus."

            userProfile.Visibility = Faker.Enum.Random<Visibility>();
            // Visibility.Private

            return userProfile;
        }
    }
}