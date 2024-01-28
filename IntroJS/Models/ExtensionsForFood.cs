using Bogus.Premium;
using TheFaker = Bogus.Faker;

namespace IntroJS.Models
{
    /// <summary>
    /// The following shows how to create a dedicated DataSet accessible via C# extension method.
    /// </summary>
    public static class ExtensionsForFood
    {
        public static Food Food(this TheFaker faker)
        {
            return ContextHelper.GetOrSet(faker, () => new Food());
        }
    }
}