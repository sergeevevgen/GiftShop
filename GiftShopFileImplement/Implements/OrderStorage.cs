using GiftShopContracts.BindingModels;
using GiftShopContracts.StoragesContracts;
using GiftShopContracts.ViewModels;
using GiftShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiftShopFileImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly FileDataListSingleton source;

        public OrderStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void Delete(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Orders.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var order = source.Orders
                .FirstOrDefault(rec => rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return source.Orders
                .Where(rec => rec.Id.Equals(model.Id)
                || rec.DateCreate >= model.DateFrom
                && rec.DateCreate <= model.DateTo ||
                model.ClientId.HasValue && rec.ClientId == model.ClientId)
                .Select(CreateModel)
                .ToList();
        }

        public List<OrderViewModel> GetFullList()
        {
            return source.Orders
                .Select(CreateModel)
                .ToList();
        }

        public void Insert(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
            var element = new Order { Id = maxId + 1 };
            source.Orders.Add(CreateModel(model, element));
        }

        public void Update(OrderBindingModel model)
        {
            var element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        private static Order CreateModel(OrderBindingModel model, Order order)
        {
            order.GiftId = model.GiftId;
            order.ClientId = model.ClientId.Value;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }

        private OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ClientFIO = source.Clients.FirstOrDefault(rec => rec.Id == order.Id)?.ClientFIO,
                GiftId = order.GiftId,
                GiftName = source.Gifts.FirstOrDefault(rec => rec.Id == order.GiftId)?.GiftName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status.ToString(),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
