﻿using GiftShopContracts.Enums;
using GiftShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace GiftShopFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;

        private readonly string ComponentFileName = "Component.xml";

        private readonly string OrderFileName = "Order.xml";

        private readonly string GiftFileName = "Gift.xml";

        private readonly string ClientFileName = "Client.xml";

        private readonly string ImplementerFileName = "Implementer.xml";

        private readonly string MessageFileName = "Message.xml";

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Gift> Gifts { get; set; }

        public List<Client> Clients { get; set; }

        public List<Implementer> Implementers { get; set; }

        public List<MessageInfo> Messages { get; set; }

        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Gifts = LoadGifts();
            Clients = LoadClients();
            Implementers = LoadImplementers();
            Messages = LoadMessages();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }

        public static void SaveData()
        {
            instance.SaveComponents();
            instance.SaveOrders();
            instance.SaveGifts();
            instance.SaveClients();
            instance.SaveImplementers();
            instance.SaveMessages();
        }

        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                var xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        GiftId = Convert.ToInt32(elem.Element("DishId").Value),
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        ImplementerId = elem.Element("ImplementerId").IsEmpty ? null : Convert.ToInt32(elem.Element("ImplementerId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = elem.Element("DateImplement").IsEmpty ? null : Convert.ToDateTime(elem.Element("DateImplement").Value)
                    });
                }
            }
            return list;
        }

        private List<Gift> LoadGifts()
        {
            var list = new List<Gift>();
            if (File.Exists(GiftFileName))
            {
                XDocument xDocument = XDocument.Load(GiftFileName);
                var xElements = xDocument.Root.Elements("Gift").ToList();
                foreach (var elem in xElements)
                {
                    var prodComp = new Dictionary<int, int>();
                    foreach (var component in elem.Element("GiftComponents").Elements("GiftComponent").ToList())
                    {
                        prodComp.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Gift
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        GiftName = elem.Element("GiftName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        GiftComponents = prodComp
                    });
                }
            }
            return list;
        }

        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                var xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Email = elem.Element("Email").Value,
                        Password = elem.Element("Password").Value
                    });
                }
            }
            return list;
        }

        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();
            if (File.Exists(ImplementerFileName))
            {
                var xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FIO = elem.Element("FIO").Value,
                        PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value),
                        WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value)
                    });
                }
            }
            return list;
        }

        private List<MessageInfo> LoadMessages()
        {
            var list = new List<MessageInfo>();
            if (File.Exists(MessageFileName))
            {
                var xDocument = XDocument.Load (MessageFileName);
                var xElements = xDocument.Root.Elements("Message").ToList();
                foreach(var elem in xElements)
                {
                    list.Add(new MessageInfo
                    {
                        MessageId = elem.Attribute("MessageId").Value,
                        ClientId = Convert.ToInt32(elem.Attribute("ClientId").Value),
                        Body = elem.Element("Body").Value,
                        DateDelivery = Convert.ToDateTime(elem.Element("DateDelivery").Value),
                        SenderName = elem.Element("SenderName").Value,
                        Subject = elem.Element("Subject").Value
                    });
                }
            }
            return list;
        }

        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                        new XAttribute("Id", order.Id),
                        new XElement("DishId", order.GiftId),
                        new XElement("ClientId", order.ClientId),
                        new XElement("ImplementerId", order.ImplementerId),
                        new XElement("Count", order.Count),
                        new XElement("Sum", order.Sum),
                        new XElement("Status", order.Status),
                        new XElement("DateCreate", order.DateCreate),
                        new XElement("DateImplement", order.DateImplement)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SaveGifts()
        {
            if (Gifts != null)
            {
                var xElement = new XElement("Gifts");
                foreach (var gift in Gifts)
                {
                    var compElement = new XElement("GiftComponents");
                    foreach (var component in gift.GiftComponents)
                    {
                        compElement.Add(new XElement("ProductComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Gift",
                    new XAttribute("Id", gift.Id),
                    new XElement("GiftName", gift.GiftName),
                    new XElement("Price", gift.Price),
                    compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(GiftFileName);


            }
        }

        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }

        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");
                foreach (var implementer in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                        new XAttribute("Id", implementer.Id),
                        new XElement("FIO", implementer.FIO),
                        new XElement("PauseTime", implementer.PauseTime),
                        new XElement("WorkingTime", implementer.WorkingTime)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }

        private void SaveMessages()
        {
            if (Messages != null)
            {
                var xElement = new XElement("Messages");
                foreach (var message in Messages)
                {
                    xElement.Add(new XElement("Message",
                        new XAttribute("MessageId", message.MessageId),
                        new XElement("ClientId", message.ClientId),
                        new XElement("DateDelivery", message.DateDelivery),
                        new XElement("SenderName", message.SenderName),
                        new XElement("Subject", message.Subject)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(MessageFileName);
            }
        }
    }
}
