using System;
using System.Collections.Generic;
using GiftShopContracts.BindingModels;
using GiftShopContracts.StoragesContracts;
using GiftShopContracts.BusinessLogicsContracts;
using GiftShopContracts.ViewModels;

namespace GiftShopBusinessLogic.BusinessLogic
{
    public class GiftLogic : IGiftLogic
    {
        private readonly IGiftStorage _giftStorage;

        public GiftLogic(IGiftStorage giftStorage)
        {
            _giftStorage = giftStorage;
        }
        public List<GiftViewModel> Read(GiftBindingModel model)
        {
            if (model == null)
            {
                return _giftStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<GiftViewModel> { _giftStorage.GetElement(model) };
            }
            return _giftStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(GiftBindingModel model)
        {
            var element = _giftStorage.GetElement(new GiftBindingModel { GiftName = model.GiftName });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Подарок с таким именем уже есть");
            }
            if (model.Id.HasValue)
            {
                _giftStorage.Update(model);
            }
            else
            {
                _giftStorage.Insert(model);
            }
        }

        public void Delete(GiftBindingModel model)
        {
            var element = _giftStorage.GetElement(new GiftBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Товар не найден");
            }
            _giftStorage.Delete(model);
        }
    }
}
