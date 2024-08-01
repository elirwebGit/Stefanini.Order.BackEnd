using Microsoft.AspNetCore.Mvc;
using Stefanini.Order.Application.Interfaces;
using Stefanini.Order.Application.Request;

namespace Stefanini.Order.API.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderApp _orderApp;

        public OrderController(IOrderApp orderApp)
        {
            _orderApp = orderApp;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderRequest orderRequest)
        {
            var result = await _orderApp.AddOrder(orderRequest);
            return new ObjectResult(orderRequest) {StatusCode = result.StatusCode, Value = result.Message };
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Delete([FromRoute]int orderId)
        {
            var result = await _orderApp.DeleteOrder(orderId);
            return new ObjectResult(orderId) { StatusCode = result.StatusCode, Value = result.Message };
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var orderLists = await _orderApp.GetAllOrder();
            return Ok(orderLists);
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> Update(int orderId, [FromBody] OrderRequest orderRequest)
        {
            var result = await _orderApp.UpdateOrder(orderId, orderRequest);
            return new ObjectResult(result) { StatusCode = result.StatusCode, Value = result.Message };
        }

    }
}
