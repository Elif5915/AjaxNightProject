using AjaxNightProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace AjaxNightProject.Context;

public class AjaxContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=NETCADYAZ;initial catalog=AjaxNightDb;integrated Security=true");

    }

    public DbSet<Customer> Customers { get; set; } //Bu bizim entitymiz tek tablo ile çalışacağız
}
