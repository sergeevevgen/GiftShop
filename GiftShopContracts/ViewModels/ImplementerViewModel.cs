﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopContracts.ViewModels
{
    public class ImplementerViewModel
    {
        public int Id { get; set; }
        [DisplayName("ФИО сборщика")]
        public string FIO { get; set; }
        [DisplayName("Время отдыха")]
        public int PauseTime { get; set; }
        [DisplayName("Время работы")]
        public int WorkingTime { get; set; }
    }
}