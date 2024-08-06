using BaiTestPhuHung.Models;
using BaiTestPhuHung.Queries.ProductsQuery;
using BaiTestPhuHung.Repositories;
using MediatR;

namespace BaiTestPhuHung.Handlers.Products
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository<Product> _repository;

        public GetAllProductsHandler(IProductRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
