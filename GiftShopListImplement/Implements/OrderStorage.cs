﻿using System;
using System.Collections.Generic;
using GiftShopContracts.BindingModels;
using GiftShopContracts.StoragesContracts;
using GiftShopContracts.ViewModels;
using GiftShopListImplement.Models;

namespace GiftShopListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton source;

        public OrderStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Заказ не найден");
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id)
                {
                    return CreateModel(order);
                }
            }
            return null;
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if (order.Id.Equals(model.Id) || (!model.DateFrom.HasValue && !model.DateTo.HasValue && order.DateCreate.Date == model.DateCreate.Date) ||
                 (model.DateFrom.HasValue && model.DateTo.HasValue && order.DateCreate.Date >= model.DateFrom.Value.Date && order.DateCreate.Date <= model.DateTo.Value.Date) ||
                 (model.ClientId.HasValue && order.ClientId == model.ClientId) ||
                 (model.SearchStatus.HasValue && model.SearchStatus.Value == order.Status) ||
                 (model.ImplementerId.HasValue && order.ImplementerId == model.ImplementerId && model.Status == order.Status))
                {
                    result.Add(CreateModel(order));
                }
            }
            return result;
        }

        public List<OrderViewModel> GetFullList()
        {
            var result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                result.Add(CreateModel(order));
            }
            return result;
        }

        public void Insert(OrderBindingModel model)
        {
            var tempOrder = new Order
            {
                Id = 1
            };
            foreach (var order in source.Orders)
            {
                if (order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
            }
            source.Orders.Add(CreateModel(model, tempOrder));
        }

        public void Update(OrderBindingModel model)
        {
            Order tempOrder = null;
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id)
                {
                    tempOrder = order;
                }
            }
            if (tempOrder == null)
            {
                throw new Exception("Заказ не найден");
            }
            CreateModel(model, tempOrder);
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.GiftId = model.GiftId;
            order.ClientId = model.ClientId.Value;
            order.ImplementerId = model.ImplementerId.Value;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }

        private OrderViewModel CreateModel(Order order)
        {
            string giftName = null;
            foreach (var gift in source.Gifts)
            {
                if (gift.Id == order.GiftId)
                {
                    giftName = gift.GiftName;
                    break;
                }
            }

            string clientFIO = null;
            foreach (var client in source.Clients)
            {
                if (client.Id == order.ClientId)
                {
                    clientFIO = client.ClientFIO;
                    break;
                }
            }

            string implementerFIO = null;
            foreach (var implementer in source.Implementers)
            {
                if (implementer.Id == order.ImplementerId.Value)
                {
                    implementerFIO = implementer.FIO;
                    break;
                }
            }

            return new OrderViewModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ClientFIO = clientFIO,
                GiftId = order.GiftId,
                GiftName = giftName,
                ImplementerId = order.ImplementerId,
                ImplementerFIO = implementerFIO,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status.ToString(),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
