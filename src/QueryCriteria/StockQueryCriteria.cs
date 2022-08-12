using SwaggerAnnotationsExample.Enums;

namespace SwaggerAnnotationsExample.QueryCriteria
{
    public class StockQueryCriteria : AbstractQueryCriteria
    {
        /// <summary>
        /// This is the ticker symbol listed a stock exchange. (eg. TSLA is Tesla).
        /// If options.DescribeAllParametersInCamelCase(); was not configured this would appear uppercase as defined in the class.
        /// This comment is defined directly on the StockQueryCriteria class and not in the controller where it is being specifed as [FromQuery] StockQueryCriteria.
        /// </summary>
        public string? Symbol { get; set; }
        /// <summary>
        /// This is an enum and seeing how Swagger handles complex query parameters defined by a class instead of primitives.
        /// It has been configured with options.UseInlineDefinitionsForEnums(). And 
        /// It is displaying the enum names instead of integer values because we have configured the JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        /// </summary>
        /// <remarks>
        /// These remarks are not used for Swagger?
        ///     
        ///     Is this in a code block
        /// </remarks>
        public LifetimeAge Lifetime { get; set; }
    }
}
