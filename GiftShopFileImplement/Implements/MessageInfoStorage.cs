using GiftShopContracts.BindingModels;
using GiftShopContracts.StoragesContracts;
using GiftShopContracts.ViewModels;
using GiftShopFileImplement.Models;
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
            if (model == null)
            {
                return null;
            }
            return source.Messages.Where(rec => rec.SenderName.Contains(model.FromMailAddress)).Select(CreateModel).ToList();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            return source.Messages.Select(CreateModel).ToList();
        }

        public void Insert(MessageInfoBindingModel model)
        {
            source.Messages.Add(CreateModel(model, new MessageInfo { MessageId = model.MessageId }));
        }

        private MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo messageInfo)
        {
            messageInfo.ClientId = model.ClientId.HasValue ? model.ClientId.Value : null;
            messageInfo.DateDelivery = model.DateDelivery;
            messageInfo.SenderName = model.FromMailAddress;
            messageInfo.Body = model.Body;
            messageInfo.Subject = model.Subject;
            return messageInfo;
        }

        private MessageInfoViewModel CreateModel(MessageInfo messageInfo)
        {
            return new MessageInfoViewModel
            {
                MessageId = messageInfo.MessageId,
                SenderName = messageInfo.SenderName,
                Body = messageInfo.Body,
                DateDelivery = messageInfo.DateDelivery,
                Subject = messageInfo.Subject
            };
        }
    }
}
