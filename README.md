# Swagger Annotations Example

What started as experimenting with In-Memory Entity Framework Core and FluentValidation turned into a Swashbuckly Swagger crash course.

## Why
I came across a variety of approaches for setting up annotations for what most probably expect and want. I couldn't easily find any resources that compiled this all together. I tried all sorts of combinations to see which metadata in the code would be used to generate Swagger. Discovered some helpful configuration that was needed to produce the most detailed documentation from code.

## Metadata To Generate Swagger Docs
When it comes to documentation we have a variety of options:
- standard C# XML comments
- ASP.NET Core attributes such as [Produces] and [ProducesResponse]
- Swagger Annotations such as [SwaggerOperation], [SwaggerParameter], [SwaggerResponse]

## Which Take Precedence?
I found that Swagger Annotations take a backseat to most of the other documentation metadata if it exists. Take a look at the StockController and read the comments to discover the combinations that were tried.

## And
If it helps anyone else... cool. But I push it here for my own reference in the future if I forget.

## Other Links
- [Swashbuckle.AspNetCore.Annotations](https://github.com/domaindrivendev/Swashbuckle.AspNetCore/tree/master/src/Swashbuckle.AspNetCore.Annotations)
- [Microsoft Article - Get Started With Swashbuckle](https://docs.microsoft.com/en-us/samples/dotnet/aspnetcore.docs/getstarted-swashbuckle-aspnetcore/?tabs=visual-studio)