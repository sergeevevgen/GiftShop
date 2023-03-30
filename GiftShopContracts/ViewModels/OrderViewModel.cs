using System;
using GiftShopContracts.Enums;
using System.ComponentModel;
using GiftShopContracts.Attributes;
using System.Runtime.Serialization;

namespace GiftShopContracts.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>

    public class OrderViewModel
    {
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int? ImplementerId { get; set; }

        public int GiftId { get; set; }

        [Column(title: "Клиент", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFIO { get; set; }

        [Column(title: "Исполнитель", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string ImplementerFIO { get; set; }

        [Column(title: "Подарок", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string GiftName { get; set; }

        [Column(title: "Количество", width: 50)]
        public int Count { get; set; }

        [Column(title: "Сумма", width: 100)]
        public decimal Sum { get; set; }

        [Column(title: "Статус", width: 100)]
        public string Status { get; set; }

        [Column(title: "Дата создания", width: 100)]
        public DateTime DateCreate { get; set; }

        [Column(title: "Дата выполнения", width: 100)]
        public DateTime? DateImplement { get; set; }
    }
}
