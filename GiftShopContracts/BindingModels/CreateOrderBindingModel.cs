namespace GiftShopContracts.BindingModels
{
    public class CreateOrderBindingModel
    {
        /// <summary>
        /// Данные от клиента, для создания заказа
        /// </summary>

        public int GiftId { get; set; }
        public int ClientId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
