using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaiTestPhuHung.Commands.ProductCommand
{
    public class DeleteProductCommand : IRequest<JsonResult>
    {
        public int ID{ get; set; }
    }
}
