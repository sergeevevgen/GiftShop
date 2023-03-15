using GiftShopContracts.ViewModels;
using System.Collections.Generic;


namespace GiftShopBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportGiftComponentViewModel> GiftComponents { get; set; }

    }
}
