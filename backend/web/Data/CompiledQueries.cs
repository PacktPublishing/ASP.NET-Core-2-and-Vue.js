using System;
using System.Linq;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public static class CompiledQueries
    {
        public static Func<ApplicationDbContext, int, Order> OrderById =
                EF.CompileQuery((ApplicationDbContext db, int id) =>
                    db.Orders
                        .Single(c => c.Id == id));
    }
}