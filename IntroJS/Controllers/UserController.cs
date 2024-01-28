using Bogus;
using IntroJS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace IntroJS.Controllers
{
    public class UserController : ApiController
    {
        private readonly IList<User> _users;

        public UserController()
        {
            _users = CreateUserList();
            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 8
            };

            Parallel.For(0, 10, options, i =>
            {
                for (int j = 0; j < 10; ++j)
                {
                    var user = CreateUser();
                    _users.Add(user);
                }
            });
        }

        // GET api/<controller>
        public async Task<IHttpActionResult> Get()
        {
            var users = await Task.FromResult(_users);
            return Ok(users);
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

        private User CreateUser()
        {
            var userFaker = new Faker<User>()
            //Extend Bogus with a 'new' Food data set; see FoodDataSet.cs
            .RuleFor(p => p.FaveCandy, f => f.Food().Candy())
            .RuleFor(p => p.FaveDrink, f => f.Food().Drink())
            //Extend the existing Address data set with a custom C# extension method; see ExtensionsForAddress.cs
            .RuleFor(p => p.PostCode, f => f.Address.DowntownTorontoPostalCode());

            var user = userFaker.Generate();
            user.Dump();
            return user;
        }
    }
}