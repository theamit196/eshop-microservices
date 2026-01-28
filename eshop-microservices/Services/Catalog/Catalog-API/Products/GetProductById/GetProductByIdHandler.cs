namespace Catalog_API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);//Mapster is case senstive will accept param in this format only

    internal class GetProductByIdQueryHandler(IDocumentSession documentSession) :
        IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await documentSession.LoadAsync<Product>(query.Id, cancellationToken);
            return product == null ? throw new ProductNotFoundException(query.Id) : new GetProductByIdResult(product);
        }
    }
}
