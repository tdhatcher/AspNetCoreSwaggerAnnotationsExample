using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwaggerAnnotationsExample.DTOs;

namespace SwaggerAnnotationsExample.Data.Config
{
    public class StockDtoConfiguration : IEntityTypeConfiguration<StockDto>
    {
        public void Configure(EntityTypeBuilder<StockDto> builder)
        {
            builder.Property(s => s.Symbol);
            builder.Property(s => s.Price);
            builder.HasKey(s => s.Symbol);
        }
    }
}
