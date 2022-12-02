using SqlLiteSimpleApp.Classes;
using SqlLiteSimpleApp.Data;
using SqlLiteSimpleApp.Models;

namespace SqlLiteSimpleApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        using (var context = new Context())
        {

            BuildData(context);
            ShowData(context);
            UpdateOneRecord(context);
            ShowData(context);
        }

        Console.ReadLine();
    }

    /// <summary>
    /// First two lines create the db each time the app runs
    /// Once created feel free to remove the first line to keep existing data
    /// </summary>
    private static void BuildData(Context context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.FileContainers.Add(new FileContainer() { Path1 = "A1", Path2 = "A2", Path3 = "A3" });
        context.FileContainers.Add(new FileContainer() { Path1 = "B1", Path2 = "B2", Path3 = "B3" });
        context.FileContainers.Add(new FileContainer() { Path1 = "C1", Path2 = "C2", Path3 = "C3" });

        context.SaveChanges();
    }

    /// <summary>
    /// Update a record
    /// </summary>
    private static void UpdateOneRecord(Context context)
    {
        var item = context.FileContainers.FirstOrDefault(x => x.Id == 2);
        Console.WriteLine();
        item!.Path1 = Prompts.GetPath();
        context.SaveChanges();
    }

    private static void ShowData(Context context)
    {
        Console.WriteLine();
        var items = context.FileContainers.ToList();
        foreach (var container in items)
        {
            Console.WriteLine($"{container.Id,-3}{container.Path1,-20}{container.Path2,-13}{container.Path3,-13}");
        }
    }
}