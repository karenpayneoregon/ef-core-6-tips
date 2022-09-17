using Bogus;
using Microsoft.EntityFrameworkCore;
using TaxpayerLibraryEntityVersion.Data;
using TaxpayerLibraryEntityVersion.Models;
using TaxpayerMocking.LanguageExtensions;

using static TaxpayerMocking.Classes.Helpers;
using B = Bogus.Extensions.UnitedStates.ExtensionsForUnitedStates;

namespace TaxpayerMocking.Classes;

internal class SetupDatabase
{

    public static List<Taxpayer> GetTaxpayers()
    {
        using var context = new OedContext();
        return context.Taxpayer.Include(tp => tp.Category).ToList();
    }

    /// <summary>
    /// Delete database if exists, create database then populate database with indicate record count.
    /// </summary>
    /// <param name="count">total records to generate</param>
    public static void Initialize(int count = 10)
    {
        using var context = new OedContext();
        CleanDatabase(context);
        PopulateData(context, count);
    }

    /// <summary>
    /// Remove database if exists
    /// Create new database
    ///   * Since there is a property named Id EF will make this a primary auto-incrementing column
    /// </summary>
    /// <param name="context"></param>
    public static void CleanDatabase(DbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
    public static void PopulateData(DbContext context, int count = 10)
    {
        /*
         * Add child table first as taxpayers is dependent on categories
         */
        context.AddRange(Categories());
        context.SaveChanges();

        /*
         * Add taxpayers in tangent with foreign keys to categories
         */
        context.AddRange(Taxpayers(count));
        context.SaveChanges();
    }

    /// <summary>
    /// Create records without a primary key as EF Core when saving to the database creates keys.
    /// If you were to examine the generated records directly after saving they all will have the
    /// keys generated.
    /// </summary>
    /// <param name="count">how many records to generate</param>
    /// <returns></returns>
    private static List<Taxpayer> Taxpayers(int count = 10)
    {

        Faker<Taxpayer> fakeTaxpayer = new Faker<Taxpayer>()
            .RuleFor(t => t.FirstName, f => 
                f.Person.FirstName)

            .RuleFor(t => t.LastName, f => 
                f.Person.LastName)

            .RuleFor(t => t.SSN, f => 
                f.Random.Replace("#########"))

            .RuleFor(t => t.Pin, f => 
                f.Random.Replace("####"))

            .RuleFor(t => t.CategoryId, f => 
                f.Random.Int(1, 4))
            
            .RuleFor(t => t.StartDate, f => 
                f.Date.Between(new DateTime(2021,1,1), DateTime.Now));


        return fakeTaxpayer.Generate(count);

    }

    /// <summary>
    /// Pre-defined categories
    /// </summary>
    /// <returns></returns>
    public static List<Category> Categories() =>
        new()
        {
            new () { Description = "Needs review" },
            new () { Description = "Incomplete" },
            new () { Description = "Rejected" },
            new () { Description = "Complete" }
        };

    /// <summary>
    /// Example for using <see cref="Bogus"/> to generate a random SSN, in this case with dashes.
    /// If using this way of generating SSN we need to use string.Replace to get rid of the dashes
    /// </summary>
    /// <remarks>
    /// Bogus does not show doing SSN but Karen Payne examined source to find it.
    /// https://github.com/bchavez/Bogus/blob/master/Source/Bogus/Extensions/UnitedStates/ExtensionsForUnitedStates.cs#L13
    /// Note there are different locales
    /// https://github.com/bchavez/Bogus/tree/master/Source/Bogus/Extensions
    /// </remarks>
    public static void StandardSocialSecurityNumber()
    {

        var list = Enumerable.Range(1, 12).Select(x => B.Ssn(new Person()));

        foreach (var ssn in list)
        {
            Console.WriteLine($"{ssn} is valid? {IsValidSocialSecurityNumber(ssn).ToYesNo()}");
        }
    }

}