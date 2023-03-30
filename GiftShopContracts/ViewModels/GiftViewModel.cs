using System.Collections.Generic;
using System.ComponentModel;
using GiftShopContracts.Attributes;

namespace GiftShopContracts.ViewModels
{
    public class GiftViewModel
    {
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }

        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]

        public string GiftName { get; set; }

        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> GiftComponents { get; set; }
    }
}
