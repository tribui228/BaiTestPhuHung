using BaiTestPhuHung.Attributes;
using BaiTestPhuHung.Commands.ProductCommand;
using BaiTestPhuHung.Models;
using BaiTestPhuHung.Queries.ProductsQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaiTestPhuHung.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<JsonResult> GetProducts()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);
            return new JsonResult(products);
        }
        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<int>> PostProduct(CreateProductCommand command)
        {
           /* if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized("User is not authenticated.");
            }*/
            var productId = await _mediator.Send(command);
            return Ok(productId);
        }

        // PUT: api/Products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, UpdateProductCommand command)
        {
            /*if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized("User is not authenticated.");
            }*/
            if (id != command.ID)
            {
                return BadRequest();
            }

            var message= await _mediator.Send(command);
            return Ok(message);
        }
        
        // DELETE: api/Products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand { ID = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
