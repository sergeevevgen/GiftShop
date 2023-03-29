using GiftShopContracts.BindingModels;
using GiftShopContracts.StoragesContracts;
using GiftShopContracts.ViewModels;
using GiftShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopDatabaseImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GiftShopDatabase();
            return context.MessageInfos
                .Where(rec => (model.ClientId.HasValue && 
                rec.ClientId == model.ClientId) ||
                (!model.ClientId.HasValue && rec.DateDelivery.Date == model.DateDelivery.Date))
                .Select(CreateModel)
                .ToList();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            using var context = new GiftShopDatabase();
            return context.MessageInfos
                .Select(CreateModel)
                .ToList();
        }

        public void Insert(MessageInfoBindingModel model)
        {
            using var context = new GiftShopDatabase();
            MessageInfo element = context.MessageInfos
                .FirstOrDefault(rec => rec.MessageId == model.MessageId);
            if (element != null)
            {
                return;
            }
            context.MessageInfos.Add(new MessageInfo
            {
                MessageId = model.MessageId,
                ClientId = model.ClientId,
                SenderName = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body
            });
            context.SaveChanges();
        }

        public static MessageInfoViewModel CreateModel(MessageInfo messageInfo)
        {
            return new MessageInfoViewModel
            {
                MessageId = messageInfo.MessageId,
                SenderName = messageInfo.SenderName,
                DateDelivery = messageInfo.DateDelivery,
                Subject = messageInfo.Subject,
                Body = messageInfo.Body
            };
        }
    }
}
