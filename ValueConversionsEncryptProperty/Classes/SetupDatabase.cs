using Microsoft.EntityFrameworkCore;

namespace ValueConversionsEncryptProperty.Classes;

internal class SetupDatabase
{

    public static void CleanDatabase(DbContext context)
    {

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

    }

}