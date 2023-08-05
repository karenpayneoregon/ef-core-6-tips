﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Experiment1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Experiment1.Data;

public partial class Context
{
    private IContextProcedures _procedures;

    public virtual IContextProcedures Procedures
    {
        get
        {
            if (_procedures is null) _procedures = new ContextProcedures(this);
            return _procedures;
        }
        set
        {
            _procedures = value;
        }
    }

    public IContextProcedures GetProcedures()
    {
        return Procedures;
    }

    protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<uspProductsByCategoryAndSupplierResult>().HasNoKey().ToView(null);
    }
}

public partial class ContextProcedures : IContextProcedures
{
    private readonly Context _context;

    public ContextProcedures(Context context)
    {
        _context = context;
    }

    public virtual async Task<List<uspProductsByCategoryAndSupplierResult>> uspProductsByCategoryAndSupplierAsync(int? CategoryId, int? SupplierId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
    {
        var parameterreturnValue = new SqlParameter
        {
            ParameterName = "returnValue",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Int,
        };

        var sqlParameters = new []
        {
            new SqlParameter
            {
                ParameterName = "CategoryId",
                Value = CategoryId ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            },
            new SqlParameter
            {
                ParameterName = "SupplierId",
                Value = SupplierId ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            },
            parameterreturnValue,
        };

        var _ = 
            await _context.SqlQueryAsync<uspProductsByCategoryAndSupplierResult>(
                "EXEC @returnValue = [dbo].[uspProductsByCategoryAndSupplier] @CategoryId, @SupplierId", 
                sqlParameters, cancellationToken);

        returnValue?.SetValue(parameterreturnValue.Value);

        return _;
    }
}