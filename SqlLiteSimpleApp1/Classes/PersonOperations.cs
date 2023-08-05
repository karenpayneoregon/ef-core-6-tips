using Microsoft.EntityFrameworkCore;
using Serilog;
using SqlLiteSimpleApp1.Data;
using SqlLiteSimpleApp1.Models;

namespace SqlLiteSimpleApp1.Classes;
public class PersonOperations
{
    public static async Task<List<Person>> GetAll()
    {
        await using var context = new Context();
        return await context.Person.ToListAsync().ConfigureAwait(false);
    }

    public static async Task<List<Person>> GetAll(OrderColumn ordering, OrderingDirection direction)
    {
        await using var context = new Context();
        return await context.Person.OrderByColumn(ordering.Column).ToListAsync().ConfigureAwait(false);
    }

    
    public static async Task<(List<Person> list, Exception exception)> GetAllSafe()
    {
        try
        {
            await using var context = new Context();
            return (await context.Person.ToListAsync().ConfigureAwait(false), null);
        }
        catch (Exception localException)
        {
            Log.Error(localException,"Failed to get data\n");
            return (null, localException);
        }

    }

    public static async Task<Person> Get(int id)
    {
        await using var context = new Context();
        return await context.Person.FindAsync(id).ConfigureAwait(false);
    }

    public static async Task<int> Add(Person person)
    {
        await using var context = new Context();
        context.Add(person);
        return await context.SaveChangesAsync().ConfigureAwait(false);
    }

    public static async Task<int> Update(Person person)
    {
        await using var context = new Context();
        var trackedPerson = await context.Person.FindAsync(person.Id).ConfigureAwait(false);

        context.Entry(trackedPerson!).CurrentValues.SetValues(person);
        var affected = await context.SaveChangesAsync().ConfigureAwait(false);
        return affected;
    }

    public static async Task<int> Remove(Person person)
    {
        await using var context = new Context();

        context.Attach(person).State = EntityState.Deleted;
        return await context.SaveChangesAsync().ConfigureAwait(false);
    }
}
