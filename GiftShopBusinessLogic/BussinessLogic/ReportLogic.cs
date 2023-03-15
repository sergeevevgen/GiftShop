using GiftShopBusinessLogic.OfficePackage;
using GiftShopBusinessLogic.OfficePackage.HelperModels;
using GiftShopContracts.BindingModels;
using GiftShopContracts.BusinessLogicsContracts;
using GiftShopContracts.StoragesContracts;
using GiftShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiftShopBusinessLogic.BussinessLogic
{
    public class ReportLogic : IReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly IGiftStorage _giftStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;
        public ReportLogic(IGiftStorage giftStorage, IComponentStorage
        componentStorage, IOrderStorage orderStorage,
        AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord,
        AbstractSaveToPdf saveToPdf)
        {
            _giftStorage = giftStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        /// <summary>
        /// Получение списка подарков с указанием, какие компоненты в них используются
        /// </summary>
        /// <returns></returns>
        public List<ReportGiftComponentViewModel> GetGiftComponent()
        {
            var gifts = _giftStorage.GetFullList();
            var list = new List<ReportGiftComponentViewModel>();

            foreach (var gift in gifts)
            {
                var record = new ReportGiftComponentViewModel
                {
                    GiftName = gift.GiftName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in gift.GiftComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1,
                    component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                GiftName = x.GiftName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }

        /// <summary>
        /// Сохранение подарков в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveGiftsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список подарков",
                Gifts = _giftStorage.GetFullList()
            });
        }

        /// <summary>
        /// Сохранение подарков с указанием компанентов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveGiftComponentsToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список подарков",
                GiftComponents = GetGiftComponent()
            });
        }

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
