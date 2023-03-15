using System.Collections.Generic;
using GiftShopContracts.ViewModels;

namespace GiftShopBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<GiftViewModel> Gifts { get; set; }
    }
}
