using System.ComponentModel;

namespace GiftShopContracts.ViewModels
{
    public class ComponentViewModel
    {
        /// <summary>
        /// Компонент, требуемый для изготовления изделия
        /// </summary>

        public int Id { get; set; }
        [DisplayName("Название компонента")]

        public string ComponentName { get; set; }
    }
}
