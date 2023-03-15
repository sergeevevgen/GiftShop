using GiftShopContracts.BindingModels;
using GiftShopContracts.ViewModels;
using System.Collections.Generic;


namespace GiftShopContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        /// <summary>
        /// Получение списка подарков с указанием, какие компоненты в них находятся
        /// </summary>
        /// <returns></returns>
        List<ReportGiftComponentViewModel> GetGiftComponent();

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);

        /// <summary>
        /// Сохранение подарков в файл-Word
        /// </summary>
        /// <param name="model"></param>
        void SaveGiftsToWordFile(ReportBindingModel model);

        /// <summary>
        /// Сохранение подарков с указанием компонентов, которые в них находятся, в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        void SaveGiftComponentsToExcelFile(ReportBindingModel model);

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        void SaveOrdersToPdfFile(ReportBindingModel model);
    }
}
