using Microsoft.EntityFrameworkCore;
using TaxpayerEvents.Classes;
using TaxpayerLibraryEntityVersion.Data;

namespace TaxpayerEvents
{
    internal partial class Program
    {
        static void Main(string[] args)
        {

            using var context = new OedContext();

            var list = context.Taxpayer.Include(tp => tp.Category).ToList();
            for (int index = 0; index < list.Count; index++)
            {
                Console.WriteLine($"{list[index].FullName} {list[index].StartDate:d}");
                if (index.IsOdd())
                {
                    list[index].StartDate = list[index].StartDate!.Value.AddDays(1);
                    Console.WriteLine($"\t{list[index].StartDate:d}");
                }
            }

            context.Entry(list.FirstOrDefault()).State = EntityState.Deleted;
            context.SaveChanges();

            ExitPrompt();
            Console.ReadLine();
        }
    }
}