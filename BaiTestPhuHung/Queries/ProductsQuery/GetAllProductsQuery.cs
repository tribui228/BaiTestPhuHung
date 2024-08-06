using BaiTestPhuHung.Models;
using MediatR;

namespace BaiTestPhuHung.Queries.ProductsQuery
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }

}
