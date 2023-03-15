using System.Collections.Generic;
using GiftShopContracts.BindingModels;
using GiftShopContracts.ViewModels;

namespace GiftShopContracts.StoragesContracts
{
    public interface IGiftStorage
    {
        List<GiftViewModel> GetFullList();

        List<GiftViewModel> GetFilteredList(GiftBindingModel model);

        GiftViewModel GetElement(GiftBindingModel model);

        void Insert(GiftBindingModel model);

        void Update(GiftBindingModel model);

        void Delete(GiftBindingModel model);
    }
}
