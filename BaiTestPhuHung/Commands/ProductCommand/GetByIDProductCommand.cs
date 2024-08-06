using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaiTestPhuHung.Commands.ProductCommand
{
    public class GetByIDProductCommand : IRequest<JsonResult>
    {
        public int ID { get; set; }
    }
}
