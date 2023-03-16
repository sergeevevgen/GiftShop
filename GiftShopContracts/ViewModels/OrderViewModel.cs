using System;
using GiftShopContracts.Enums;
using System.ComponentModel;

namespace GiftShopContracts.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>

    public class OrderViewModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int? ImplementerId { get; set; }

        public int GiftId { get; set; }

        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }

        [DisplayName("Сборщик")]
        public string ImplementerFIO { get; set; }

        [DisplayName("Изделие")]
        public string GiftName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DisplayName("Статус")]
        public string Status { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
