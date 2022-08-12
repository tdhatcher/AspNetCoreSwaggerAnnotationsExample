using SwaggerAnnotationsExample.Enums;

namespace SwaggerAnnotationsExample.DTOs
{
    public class StockDto
    {
        /// <summary>
        /// This is the share price of the stock.
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// This is the ticker symbol listed a stock exchange. (eg. TSLA is Tesla)
        /// </summary>
        public string? Symbol { get; set; }

        /// <summary>
        /// This is a meaningless field to test out how Swashbuckle generates enums for Swagger. It has been configured to display inline like this 
        /// using options.UseInlineDefinitionsForEnums(). And 
        /// It is displaying the enum names instead of integer values because we have configured the JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        /// </summary>
        public LifetimeAge? Age { get; set; } 
    }
}
