using System;
using System.Collections.Generic;
using GiftShopContracts.Enums;
using GiftShopContracts.BindingModels;
using GiftShopContracts.StoragesContracts;
using GiftShopContracts.BusinessLogicsContracts;
using GiftShopContracts.ViewModels;
using GiftShopBusinessLogic.MailWorker;

namespace GiftShopBusinessLogic.BusinessLogic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly AbstractMailWorker _mailWorker;
        private readonly IClientStorage _clientStorage;

        public OrderLogic(IOrderStorage orderStorage, AbstractMailWorker mailWorker, IClientStorage clientStorage)
        {
            _orderStorage = orderStorage;
            _mailWorker = mailWorker;
            _clientStorage = clientStorage;
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }

        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                GiftId = model.GiftId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = model.ClientId
                })?.Email,
                Subject = "Ваш заказ был создан",
                Text = $"Заказ от {DateTime.Now} на сумму {model.Sum} был создан"
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            if (order.Status != Enum.GetName(typeof(OrderStatus), 0))
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ImplementerId = model.ImplementerId,
                GiftId = order.GiftId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = OrderStatus.Выполняется
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = order.ClientId
                })?.Email,
                Subject = $"Ваш заказ #{order.Id} был принят в работу",
                Text = $"Заказ от {order.DateCreate} на сумму {order.Sum} был принят в работу"
            });
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            if (order.Status != Enum.GetName(typeof(OrderStatus), 1))
            {
                throw new Exception("Заказ не в статусе  \"Выполняется\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                GiftId = order.GiftId,
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = order.ClientId
                })?.Email,
                Subject = $"Ваш заказ #{order.Id} был закончен",
                Text = $"Заказ от {order.DateCreate} на сумму {order.Sum} был закончен"
            });
        }

        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            if (order.Status != Enum.GetName(typeof(OrderStatus), 2))
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            _orderStorage.Update(new OrderBindingModel 
            {
                Id = order.Id,
                ClientId = order.ClientId,
                GiftId = order.GiftId,
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Выдан
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = order.ClientId
                })?.Email,
                Subject = $"Ваш заказ #{order.Id} был доставлен",
                Text = $"Заказ от {order.DateCreate} на сумму {order.Sum} был доставлен в {DateTime.Now}"
            });
        }
    }
}
