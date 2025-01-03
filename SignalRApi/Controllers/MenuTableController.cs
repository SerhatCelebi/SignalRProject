using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTableController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }
        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }
        [HttpGet("ActiveMenuTableCount")]
        public IActionResult ActiveMenuTableCount()
        {
            return Ok(_menuTableService.TActiveMenuTableCount());
        }
        [HttpGet("PassiveMenuTableCount")]
        public IActionResult PassiveMenuTableCount()
        {
            return Ok(_menuTableService.TPassiveMenuTableCount());
        }
		[HttpGet]
		public IActionResult MenuTableList()
		{
			var values = _menuTableService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			MenuTable menutable = new MenuTable()
			{
				Name= createMenuTableDto.Name,
				Status=false
			};
			_menuTableService.TAdd(menutable);
			return Ok("Masa Kısmı Başarılı Bir Şekilde Eklendi.");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menuTableService.TGetByID(id);
			_menuTableService.TDelete(value);
			return Ok("Masa Alanı Silindi");
		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			MenuTable menutable = new MenuTable()
			{
				Name = updateMenuTableDto.Name,
				Status=updateMenuTableDto.Status,
				MenuTableID=updateMenuTableDto.MenuTableID
			};
			_menuTableService.TUpdate(menutable);
			return Ok("Masa Alanı Güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetByID(id);
			return Ok(value);
		}
	}
}
