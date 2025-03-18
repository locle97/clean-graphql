using System.Linq.Expressions;
using System.Reflection;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Language;

namespace CleanGraphQL.GraphQL;

public static class CustomOperations
{
    public const int Like = 1025;
}

public class CustomConvention : FilterConvention
{
    protected override void Configure(IFilterConventionDescriptor descriptor)
    {
        // This is needed when you are deriving from FilterConvention
        descriptor.AddDefaults();
        descriptor.Configure<StringOperationFilterInputType>(x =>
        {
            x.Operation(CustomOperations.Like).Type<StringType>();
        }).Operation(CustomOperations.Like).Name("like");

        descriptor.AddProviderExtension(new QueryableFilterProviderExtension(x => x.AddFieldHandler<LikeOperationHandler>()));
    }
}

/// <summary>
/// Implements case insensitive Like operation: "like"
/// It produces lower(<field>) like '%<lower_cased_value>%' in query
/// </summary>
public class LikeOperationHandler : QueryableStringOperationHandler
{
    public LikeOperationHandler(InputParser inputParser) : base(inputParser) {}

    // This is specifies that to match the handler for this operation: `like` 
    protected override int Operation => CustomOperations.Like;

    // Get method info
    // For creating a expression tree we need the `MethodInfo` of the `ToLower` method of string
    private static readonly MethodInfo _toLower = typeof(string)
        .GetMethods()
        .Single(
            x => x.Name == nameof(string.ToLower) &&
            x.GetParameters().Length == 0);

    // Operation method for string.Contains(string)
    private static readonly MethodInfo _contains = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;

    public override Expression HandleOperation(
        QueryableFilterContext context,
        IFilterOperationField field,
        IValueNode value,
        object? parsedValue)
    {
        // Example: where: { or: { name: { like: "sof" } } }

        // We get the instance of the context. This is the expression path to the property
        // e.g. property: x.Name
        Expression property = context.GetInstance();

        // the parsed value is what was specified in the query
        // e.g. like: "sof"
        if (parsedValue is string str)
        {
            // Apply lower() to the property and convert the constant value to lower to make case insensitive comparison
            // provides Contains method which will be converted to LIKE %..% in query
            // Example Query result : WHERE lower(p.name) LIKE '%sof%'
            return Expression.Call(Expression.Call(property, _toLower), _contains, Expression.Constant(str.ToLower()));
        }

        // Something went wrong ...
        throw new InvalidOperationException();
    }
}
