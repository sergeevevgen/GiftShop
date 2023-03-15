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
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new GiftShopDatabase();
            return context.Orders
                .Include(rec => rec.Gift)
                .Include(rec => rec.Client)
                .Select(CreateModel).ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GiftShopDatabase();
            return context.Orders
                .Include(rec => rec.Gift)
                .Include(rec => rec.Client)
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
            (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) ||
            (model.ClientId.HasValue && rec.ClientId == model.ClientId))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GiftShopDatabase();
            var order = context.Orders
                .Include(rec => rec.Gift)
                .Include(rec => rec.Client)
                .FirstOrDefault(rec => rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }

        public void Insert(OrderBindingModel model)
        {
            using var context = new GiftShopDatabase();
            context.Orders.Add(CreateModel(model, new Order()));
            context.SaveChanges();
        }

        public void Update(OrderBindingModel model)
        {
            using var context = new GiftShopDatabase();
            var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Item not found");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(OrderBindingModel model)
        {
            using var context = new GiftShopDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Item not found");
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order)
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

        private static OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ClientFIO = order.Client.ClientFIO,
                GiftId = order.GiftId,
                GiftName = order.Gift.GiftName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status.ToString(),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
