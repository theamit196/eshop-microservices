using BuildingBlocks.CQRS;
using Catalog_API.Models;
using MediatR;
using System.Windows.Input;

namespace Catalog_API.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Cretate product entity from command object
            //Save to database
            //return CreateProductResult result
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };
            //TODO:Save to database
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
