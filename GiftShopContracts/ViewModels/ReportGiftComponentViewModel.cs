using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopContracts.ViewModels
{
    public class ReportGiftComponentViewModel
    {
        public string ComponentName { get; set; }
        public string GiftName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}
