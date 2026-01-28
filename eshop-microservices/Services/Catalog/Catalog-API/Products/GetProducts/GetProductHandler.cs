namespace Catalog_API.Products.GetProducts
{
    public record GetProductQuery() : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    internal class GetProductsQueryHandler
        (IDocumentSession documentSession)
        : IQueryHandler<GetProductQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductQuery getProductQuery, CancellationToken cancellationToken)
        {
            var products = await documentSession.Query<Product>().ToListAsync(cancellationToken);
            return new GetProductsResult(products);
        }
    }
}
