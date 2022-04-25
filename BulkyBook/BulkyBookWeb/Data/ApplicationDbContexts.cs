using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContexts:DbContext
    {
        public ApplicationDbContexts(DbContextOptions<ApplicationDbContexts>options):base(options)
        {

        }
        public DbSet<Category>Categories { get; set; }
    }
}
