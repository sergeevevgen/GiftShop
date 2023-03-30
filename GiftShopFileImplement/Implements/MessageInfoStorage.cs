using GiftShopContracts.BindingModels;
using GiftShopContracts.StoragesContracts;
using GiftShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopFileImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly FileDataListSingleton source;

        public MessageInfoStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            return source.MessageInfos.Select(CreateModel).ToList();
        }

        public void Insert(MessageInfoBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
