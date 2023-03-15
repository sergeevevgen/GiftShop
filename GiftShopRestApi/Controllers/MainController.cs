using GiftShopContracts.BindingModels;
using GiftShopContracts.BusinessLogicsContracts;
using GiftShopContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GiftShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IGiftLogic _gift;
        public MainController(IOrderLogic order, IGiftLogic gift)
        {
            _order = order;
            _gift = gift;
        }

        [HttpGet]
        public List<GiftViewModel> GetGiftList() => _gift.Read(null)?.ToList();

        [HttpGet]
        public GiftViewModel GetGift(int giftId) => _gift
            .Read(new GiftBindingModel { Id = giftId })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order
            .Read(new OrderBindingModel { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _order.CreateOrder(model);
    }
}
