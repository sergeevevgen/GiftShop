using System;
using System.Collections.Generic;
using System.Linq;
using GiftShopContracts.BindingModels;
using GiftShopContracts.StoragesContracts;
using GiftShopContracts.ViewModels;
using GiftShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace GiftShopDatabaseImplement.Implements
{
    public class GiftStorage : IGiftStorage
    {
        public List<GiftViewModel> GetFullList()
        {
            using var context = new GiftShopDatabase();
            return context.Gifts
                .Include(rec => rec.GiftComponents)
                .ThenInclude(rec => rec.Component)
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public List<GiftViewModel> GetFilteredList(GiftBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GiftShopDatabase();
            return context.Gifts
                .Include(rec => rec.GiftComponents)
                .ThenInclude(rec => rec.Component)
                .Where(rec => rec.GiftName.Contains(model.GiftName))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public GiftViewModel GetElement(GiftBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GiftShopDatabase();
            var gift = context.Gifts
                .Include(rec => rec.GiftComponents)
                .ThenInclude(rec => rec.Component)
                .FirstOrDefault(rec => rec.GiftName == model.GiftName || rec.Id == model.Id);
            return gift != null ? CreateModel(gift) :  null;
        }

        public void Insert(GiftBindingModel model)
        {
            using var context = new GiftShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Gift gift = new Gift
                {
                    GiftName = model.GiftName,
                    Price = model.Price
                };
                context.Gifts.Add(gift);
                context.SaveChanges();
                CreateModel(model, gift, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(GiftBindingModel model)
        {
            using var context = new GiftShopDatabase();
            using (var transaction = context.Database.BeginTransaction())
            try
            {
                var element = context.Gifts.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Delete(GiftBindingModel model)
        {
            using  var context = new GiftShopDatabase();
            Gift element = context.Gifts.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Gifts.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Gift CreateModel(GiftBindingModel model, Gift gift) 
        {
            gift.GiftName = model.GiftName;
            gift.Price = model.Price;
            return gift;
        }

        private static Gift CreateModel(GiftBindingModel model, Gift gift, GiftShopDatabase context)
        {
            gift.GiftName = model.GiftName;
            gift.Price = model.Price;
            if (model.Id.HasValue)
            {
                var giftComponents = context.GiftComponents.Where(rec => rec.GiftId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.GiftComponents.RemoveRange(giftComponents.Where(rec => !model.GiftComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in giftComponents)
                {
                    updateComponent.Count = model.GiftComponents[updateComponent.ComponentId].Item2;
                    model.GiftComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.GiftComponents)
            {
                context.GiftComponents.Add(new GiftComponent
                {
                    GiftId = gift.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return gift;
        }

        private static GiftViewModel CreateModel(Gift gift)
        {
            return new GiftViewModel
            {
                Id = gift.Id,
                GiftName = gift.GiftName,
                Price = gift.Price,
                GiftComponents = gift.GiftComponents
                .ToDictionary(recPC => recPC.ComponentId,
                recPC => (recPC.Component?.ComponentName, recPC.Count))
            };
        }
    }
}
