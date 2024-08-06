using BaiTestPhuHung.Commands.ProductCommand;
using BaiTestPhuHung.Models;
using BaiTestPhuHung.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaiTestPhuHung.Handlers.Products
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, JsonResult>
    {
        private readonly IProductRepository<Product> _repository;

        public DeleteProductHandler(IProductRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<JsonResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.ID);

            return new JsonResult("Delete Success");
        }
    }
}
