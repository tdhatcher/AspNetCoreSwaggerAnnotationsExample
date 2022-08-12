using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerAnnotationsExample.Data;
using SwaggerAnnotationsExample.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using SwaggerAnnotationsExample.Enums;
using SwaggerAnnotationsExample.QueryCriteria;
using System.Collections.Generic;
using System.Linq;

namespace SwaggerAnnotationsExample.Controllers
{
    /// <summary>
    /// Stock Api. This description is defined as an XML comment using "summary" directly on the controller class.
    /// </summary>
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IValidator<StockDto> _validator;
        private readonly MemoryContext _context;
        public StockController(IValidator<StockDto> validator, MemoryContext context)
        {
            _validator = validator;
            _context = context;
        }

        /// <summary>
        /// This is the summary defined in the XML comment and will be overriden by the summary of a SwaggerOperation attribute if it exists (an exception where it takes precedence).
        /// </summary>
        /// 
        /// <remarks>
        /// THE FILTER PARAMETERS DON'T ACTUALLY WORK -- It's a feature, or a slapped together demo to evaluate how Swagger docs are generated from code ;)
        /// 
        /// This description is pulled from the XML comment under "remarks". This will override the description of a SwaggerOpertaion attribute.
        /// 
        /// Example Usage:
        ///     
        ///     // As long as you indent 4 spaces after an empty newline
        ///     // the literal text is rendered as a code block. Nice!
        ///     GET /stock
        ///     {
        ///     "symbol": "TSLA",
        ///     "name": "Item1",
        ///     "isComplete": true
        ///     }
        ///     
        /// Nothing prevents us from creatings another code block
        /// 
        ///     You.WinAgain();
        /// </remarks>
        /// 
        /// <param name="queryCriteria">This is the XML description for the "queryCriteria" parameter but is ignored when used with [FromQuery]. With [FromBody] (the default for complex parameters) it will be displayed.</param>
        /// <returns>This seems to be ignored and shouldn't be seen in Swagger output.</returns>
        /// <response code="400">If the criteria is invalid. This XML comment overrides description of the SwaggerResponse attribute using the same status code of 400.</response>
        [SwaggerOperation(Summary = "Get a list of stocks and their prices.", Description = "You can filter based on specific criteria.")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type:typeof(IEnumerable<StockDto>), description: "A result set matching the provided query criteria. This is from the SwaggerResponse attribute and provides a meaningful type instead of the IActionResult defined on the controller method. It was only defined by the SwaggerResponse attribute so it doesn't get suppressed by other annotation metadata.")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, type:typeof(ProblemDetails), description: "This description is ignored because XML comment's matching \"response\" takes precedence.")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))] // This type overrides the type property of the SwaggerResponse attribute.
        [HttpGet]
        public IActionResult ListStock(
            [FromQuery]
            StockQueryCriteria queryCriteria, // Description on this parameter is useless because it isn't the request body or isn't a primitive type when used with [FromQuery]
            [FromQuery]
            [SwaggerParameter(Description = "This is the SwaggerParameter attribute description for the \"max\" parameter. It would be ignored if this was a complex type or if an XML comment \"param\" existed.")]
            int max
        )
        {
            if (_context.Stocks.Count() <= 0)
            {
                _context.Stocks.AddRange(new StockDto[] {
                    new StockDto { Symbol = "voo", Price = 425.50m, Age = LifetimeAge.Archive },
                    new StockDto { Symbol = "hii", Price = 221.75m, Age = LifetimeAge.Current },
                    new StockDto { Symbol = "lmt", Price = 426.89m, Age = LifetimeAge.Archive },
                    new StockDto { Symbol = "ui", Price = 317.34m, Age = LifetimeAge.Archive },
                    new StockDto { Symbol = "voog", Price = 376.32m, Age = LifetimeAge.Current },
                    new StockDto { Symbol = "exr", Price = 197.89m, Age = LifetimeAge.Current },
                    new StockDto { Symbol = "oxy", Price = 63.45m, Age = LifetimeAge.Archive },
                    new StockDto { Symbol = "vlo", Price = 106.12m, Age = LifetimeAge.Archive }
                });
                _context.SaveChanges();
            }

            ICollection<StockDto> stocks = _context.Stocks.AsQueryable().ToList();
            return Ok(stocks);
        }

        /// <summary>
        /// Add stock data. This one is not documented except for this summary. The GET is thoroughly decorated with annotations.
        /// </summary>
        /// <param name="stockDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateStock(StockDto stockDto)
        {
            if (_context.Stocks.Contains(stockDto))
            {
                return new ObjectResult(new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    {"Symbol", new string[] {$"{stockDto.Symbol} already exists."}}
                })
                {
                    Detail = $"{stockDto.Symbol} already exists.",
                    Status = StatusCodes.Status409Conflict
                });
            }

            _context.Add(stockDto);
            _context.SaveChanges();
            return Ok(stockDto);
        }
    }
}
