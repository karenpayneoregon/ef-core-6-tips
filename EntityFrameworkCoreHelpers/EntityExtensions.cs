#nullable disable

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreHelpers;

public static class EntityExtensions
{
    /// <summary>
    /// Test connection with exception handling
    /// </summary>
    /// <param name="context"><see cref="DbContext"/></param>
    /// <returns></returns>
    public static async Task<(bool success, Exception exception)> CanConnectAsync(this DbContext context)
    {
        try
        {
            var result = await Task.Run(async () => await context.Database.CanConnectAsync());
            return (result, null);
        }
        catch (Exception e)
        {
            return (false, e);
        }
    }
}