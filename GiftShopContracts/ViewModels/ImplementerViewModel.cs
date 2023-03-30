﻿using GiftShopContracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopContracts.ViewModels
{
    public class ImplementerViewModel
    {
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }

        [Column(title: "ФИО сборщика", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string FIO { get; set; }

        [Column(title: "Время отдыха", width: 50)]
        public int PauseTime { get; set; }

        [Column(title: "Время работы", width: 50)]
        public int WorkingTime { get; set; }
    }
}
