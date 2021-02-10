using System;
using Microsoft.EntityFrameworkCore;
namespace Biblioteca_Core.Models
{
    public class ObraContext : DbContext
    {
        public ObraContext(DbContextOptions<ObraContext> options) : base(options)
        {
        }

        public DbSet<ObraModel> obraModel { get; set; }
    }
}
