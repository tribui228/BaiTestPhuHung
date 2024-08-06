using BaiTestPhuHung.Commands.ProductCommand;
using BaiTestPhuHung.Commands.UserCommand;
using BaiTestPhuHung.Models;
using BaiTestPhuHung.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaiTestPhuHung.Handlers.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, JsonResult>
    {
        private readonly IRepository<Product> _repository;
        private readonly IConfiguration _configuration;

        public CreateProductHandler(IRepository<Product> repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }
        public async Task<JsonResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductID = request.ProductID,
                ProductName = request.ProductName,
                Price = request.Price
            };

            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync(cancellationToken);

            return new JsonResult("Create Success");
        }
    }

}
