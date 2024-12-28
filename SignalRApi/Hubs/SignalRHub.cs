using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;

        public SignalRHub(ICategoryService categoryService, IProductService productService,IOrderService orderService
            , IMoneyCaseService moneyCaseService, IMenuTableService menuTableService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
        }

        public async Task SendStatistic()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);

            var value2 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value2);

            var value3 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value3);

            var value4 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value4);

            var value5= _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value5);

            var value6=_productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value6);

            var value7=_productService.TProductAvgPriceByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductAvgPriceByCategoryNameHamburger", value7.ToString("0.00")+ "₺");

            var value8=_productService.TProductPriveAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg",value8.ToString("0.00")+ "₺");

            var value9 = _productService.TProductByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductByMaxPrice", value9);

            var value10 = _productService.TProductByMinPrice();
            await Clients.All.SendAsync("ReceiveProductByMinPrice", value10);

            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);

            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);
            
            var value13 = _orderService.TLastOrder();
            await Clients.All.SendAsync("ReceiveLastOrder", value13);
            
            var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.ToString("0.00") + "₺");
            
            var value15 = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", value15.ToString("0.00") + "₺");

            var value16 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value16);
        }
        public async Task SendProgress()
        {
            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0,00")+ "₺");
            var value2 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value2);
            var value3 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value3);
            var value4 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value4);
            var value5 = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount2", value5);
            var value6 = _menuTableService.TActiveMenuTableCount();
            await Clients.All.SendAsync("ReceiveActiveMenuTableCount", value6);
            var value7 = _menuTableService.TPassiveMenuTableCount();
            await Clients.All.SendAsync("ReceivePassiveMenuTableCount", value7);


        }
       
    }
}
