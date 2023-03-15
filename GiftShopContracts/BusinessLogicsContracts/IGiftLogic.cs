using System.Collections.Generic;
using GiftShopContracts.BindingModels;
using GiftShopContracts.ViewModels;

namespace GiftShopContracts.BusinessLogicsContracts
{
    public interface IGiftLogic
    {
        List<GiftViewModel> Read(GiftBindingModel model);
        void CreateOrUpdate(GiftBindingModel model);
        void Delete(GiftBindingModel model);
    }
}
