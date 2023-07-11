using Experiment1.Data;
using Experiment1.Models;

namespace Experiment1;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        int categoryId = 1;
        int supplierId = 16;
        await using var context = new Context();
        List<uspProductsByCategoryAndSupplierResult> products = 
            await context.GetProcedures()
                .uspProductsByCategoryAndSupplierAsync(categoryId, supplierId);

        AnsiConsole.MarkupLine($"[yellow]Products: category {categoryId} supplier {supplierId}[/]");

        foreach (var product in products)
        {
            Console.WriteLine($"Id {product.ProductID,-3} Name: {product.ProductName}");
        }

        Console.ReadLine();
    }
}