namespace SwaggerAnnotationsExample.Enums
{
    /// <summary>
    /// This is an enum that should not be documented because Swagger is configured with options.UseInlineDefinitionsForEnums()
    /// </summary>
    public enum LifetimeAge
    {
        Current = 1,
        Archive = 2,
        Alltime = 3,
    }
}
