using Microsoft.EntityFrameworkCore;
using Serilog;
using SqlLiteSimpleApp1.Data;
using SqlLiteSimpleApp1.Models;

namespace SqlLiteSimpleApp1.Classes;
public class PersonOperations
{
    public static async Task<List<Person>> GetAll()
    {
        var context = new Context();
        await using var _ = context;
        return await context.Person.ToListAsync();
    }

    public static async Task<List<Person>> GetAll(OrderColumn ordering, OrderingDirection direction)
    {
        var context = new Context();
        await using var _ = context;
        return await context.Person.OrderByColumn(ordering.Column).ToListAsync();
    }

    
    public static async Task<(List<Person> list, Exception exception)> GetAllSafe()
    {
        try
        {
            var context = new Context();
            await using var _ = context;
            return (await context.Person.ToListAsync(), null);
        }
        catch (Exception localException)
        {
            Log.Error(localException,"Failed to get data\n");
            return (null, localException);
        }

    }

    public static async Task<Person> Get(int id)
    {
        var context = new Context();
        await using var _ = context;
        return await context.Person.FindAsync(id);
    }

    public static async Task<int> Add(Person person)
    {
        var context = new Context();
        await using var _ = context;
        context.Add(person);
        return await context.SaveChangesAsync();
    }

    public static async Task<int> Update(Person person)
    {
        var context = new Context();
        await using var _ = context;

        var trackedPerson = await context.Person.FindAsync(person.Id);

        context.Entry(trackedPerson!).CurrentValues.SetValues(person);
        var affected = await context.SaveChangesAsync();
        return affected;
    }

    public static async Task<int> Remove(Person person)
    {
        var context = new Context();
        await using var _ = context;

        context.Attach(person).State = EntityState.Deleted;
        return await context.SaveChangesAsync();
    }
}
