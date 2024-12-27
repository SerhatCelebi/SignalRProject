using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.OrderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;

        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }
        
        [HttpGet]
        public IActionResult OrderList()
        {
            var values = _OrderService.TGetListAll();
            return Ok(values);
        }
        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            
            return Ok(_OrderService.TTotalOrderCount());
        }
        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {

            return Ok(_OrderService.TActiveOrderCount());
        }
        [HttpGet("LastOrder")]
        public IActionResult LastOrder()
        {

            return Ok(_OrderService.TLastOrder());
        }
        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {

            return Ok(_OrderService.TTodayTotalPrice());
        }
        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDto createOrderDto)
        {
            Order Order = new Order()
            {
                
            };
            _OrderService.TAdd(Order);
            return Ok("Hakkında Kısmı Başarılı Bir Şekilde Eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var value = _OrderService.TGetByID(id);
            _OrderService.TDelete(value);
            return Ok("Hakkında Alanı Silindi");
        }
        [HttpPut]
        public IActionResult UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            Order Order = new Order()
            {
                
            };
            _OrderService.TUpdate(Order);
            return Ok("Hakkımda Alanı Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var value = _OrderService.TGetByID(id);
            return Ok(value);
        }
    }
}
