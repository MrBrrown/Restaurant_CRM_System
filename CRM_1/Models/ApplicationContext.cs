using System;
using Microsoft.EntityFrameworkCore;

namespace CRM_1.Models
{
    public class ApplicationContext : DbContext
    {
        DbSet<Component> Components { get; set; } = null!;

        DbSet<Product> Products { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
    }
}

