using System;
using GiftShopContracts.Enums;

namespace GiftShopContracts.BindingModels
{
    public class OrderBindingModel
    {
        /// <summary>
        /// Заказ
        /// </summary>

        public int? Id { get; set; }
        public int? ClientId { get; set; }
        public int GiftId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
