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

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Gift> Gifts { get; set; }

        public List<Client> Clients { get; set; }

        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Gifts = LoadGifts();
            Clients = LoadClients();
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
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    OrderStatus orderStatus = 0;
                    DateTime? dateImplement = null;

                    if (elem.Element("DateImplement").Value != "")
                    {
                        dateImplement = Convert.ToDateTime(elem.Element("DateImplement").Value);
                    }

                    switch (elem.Element("Status").Value)
                    {
                        case "Accepted":
                            orderStatus = OrderStatus.Принят;
                            break;
                        case "Performed":
                            orderStatus = OrderStatus.Выполняется;
                            break;
                        case "Ready":
                            orderStatus = OrderStatus.Готов;
                            break;
                        case "Paid":
                            orderStatus = OrderStatus.Выдан;
                            break;
                    }

                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        GiftId = Convert.ToInt32(elem.Element("GiftId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = orderStatus,
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = dateImplement
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
                    new XElement("GiftId", order.GiftId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
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
    }
}
