﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopContracts.BindingModels
{
    public class MailSendInfoBindingModel
    {
        public string MailAddress { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
