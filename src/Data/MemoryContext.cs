using Microsoft.EntityFrameworkCore;
using SwaggerAnnotationsExample.Data.Config;
using SwaggerAnnotationsExample.DTOs;

namespace SwaggerAnnotationsExample.Data
{
    public class MemoryContext : DbContext
    {
        public DbSet<StockDto> Stocks { get; set; }
        public MemoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new StockDtoConfiguration());
        }
    }
}
