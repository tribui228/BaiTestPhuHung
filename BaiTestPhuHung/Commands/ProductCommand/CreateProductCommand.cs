using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaiTestPhuHung.Commands.ProductCommand
{
    public class CreateProductCommand : IRequest<JsonResult>
    {
        public int ID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
