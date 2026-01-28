namespace Catalog_API.Products.GetProducts
{
    // public record GetProductsRequest();
    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        void ICarterModule.AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("products", async (ISender sender, CancellationToken cancellationToken) =>
                {
                    var query = new GetProductQuery();
                    var result = await sender.Send(query, cancellationToken);
                    var response = result.Adapt<GetProductsResponse>();
                    return Results.Ok(response);
                }).WithName("GetProducts")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product")
        .WithDescription("Get Product"); ;
        }
    }
}
