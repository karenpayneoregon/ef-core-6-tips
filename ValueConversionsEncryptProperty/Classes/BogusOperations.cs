using Bogus;
using ValueConversionsEncryptProperty.Models;

namespace ValueConversionsEncryptProperty.Classes;
internal class BogusOperations
{
    public static List<User> MockedUsers(int count = 10)
    {
        Faker<User> fakeTaxpayer = new Faker<User>()
            .RuleFor(t => t.Name, f =>
                f.Person.FirstName)

            .RuleFor(t => t.Password, f =>
                f.Internet.Password());


        return fakeTaxpayer.Generate(count);
    }
}
