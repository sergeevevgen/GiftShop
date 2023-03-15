using System.Collections.Generic;

namespace GiftShopContracts.BindingModels
{
    public class GiftBindingModel
    {
        /// <summary>
        /// Изделие, изготавливаемое в магазине
        /// </summary>

        public int? Id { get; set; }

        public string GiftName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> GiftComponents { get; set; }
    }
}
