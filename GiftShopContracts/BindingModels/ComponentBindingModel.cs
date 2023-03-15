namespace GiftShopContracts.BindingModels
{
    public class ComponentBindingModel
    {
        /// <summary>
        /// Компонент, требуемый для изготовления изделия
        /// </summary>

        public int? Id { get; set; }

        public string ComponentName { get; set; }
    }
}
