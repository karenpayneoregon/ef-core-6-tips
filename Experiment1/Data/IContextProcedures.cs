﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Experiment1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Experiment1.Data
{
    public partial interface IContextProcedures
    {
        Task<List<uspProductsByCategoryAndSupplierResult>> uspProductsByCategoryAndSupplierAsync(int? CategoryId, int? SupplierId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
