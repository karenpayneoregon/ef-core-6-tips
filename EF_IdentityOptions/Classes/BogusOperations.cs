using SelectiveUpdatesApp.Models;

namespace EF_IdentityOptions.Classes;

public class BogusOperations
{
    public static List<Person> People(int count = 10)
    {
        var fakePerson = new Bogus.Faker<Person>()
            .RuleFor(c => c.FirstName, f => f.Person.FirstName)
            .RuleFor(c => c.LastName, f => f.Person.LastName)
            .RuleFor(c => c.Title, f => f.Name.JobTitle())
            .RuleFor(c => c.BirthDate, f => f.Person.DateOfBirth);

        return fakePerson.Generate(count);

    }
}