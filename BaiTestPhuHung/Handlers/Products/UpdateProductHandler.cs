using BaiTestPhuHung.Commands.ProductCommand;
using BaiTestPhuHung.Models;
using BaiTestPhuHung.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaiTestPhuHung.Handlers.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, JsonResult>
    {
        private readonly IProductRepository<Product> _repository;

        public UpdateProductHandler(IProductRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<JsonResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ID);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {request.ID} not found.");
            }

            product.ProductID = request.ProductID;
            product.ProductName = request.ProductName;
            product.Price = request.Price;

            await _repository.UpdateAsync(product);

            return new JsonResult ("Update success");
        }
    }
}
