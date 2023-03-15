using System.Collections.Generic;
using System.ComponentModel;

namespace GiftShopContracts.ViewModels
{
    public class GiftViewModel
    {
        /// <summary>
        /// Изделие, изготавливаемое в магазине
        /// </summary>


        public int Id { get; set; }
        [DisplayName("Название изделия")]

        public string GiftName { get; set; }
        [DisplayName("Цена")]

        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> GiftComponents { get; set; }
    }
}
