using System.Collections.Generic;
using GiftShopContracts.BindingModels;
using GiftShopContracts.ViewModels;

namespace GiftShopContracts.BusinessLogicsContracts
{
    public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);
        void CreateOrder(CreateOrderBindingModel model);
        void TakeOrderInWork(ChangeStatusBindingModel model);
        void FinishOrder(ChangeStatusBindingModel model);
        void PayOrder(ChangeStatusBindingModel model);

    }
}
