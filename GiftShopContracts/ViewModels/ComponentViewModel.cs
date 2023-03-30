using GiftShopContracts.Attributes;
using System.ComponentModel;

namespace GiftShopContracts.ViewModels
{
    public class ComponentViewModel
    {
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }

        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
    }
}
