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
    public class ImplementerStorage : IImplementerStorage
    {
        public void Delete(ImplementerBindingModel model)
        {
            using var context = new GiftShopDatabase();
            Implementer element = context.Implementers
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Implementers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GiftShopDatabase();
            var implementer = context.Implementers
            .FirstOrDefault(rec => rec.FIO == model.FIO ||
            rec.Id == model.Id);
            return implementer != null ? CreateModel(implementer) : null;
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GiftShopDatabase();
            return context.Implementers
            .Where(rec => rec.FIO.Contains(model.FIO))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public List<ImplementerViewModel> GetFullList()
        {
            using var context = new GiftShopDatabase();
            return context.Implementers
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public void Insert(ImplementerBindingModel model)
        {
            using var context = new GiftShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Implementers.Add(CreateModel(model, new Implementer()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(ImplementerBindingModel model)
        {
            using var context = new GiftShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Implementers.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private static Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.FIO = model.FIO;
            implementer.WorkingTime = model.WorkingTime;
            implementer.PauseTime = model.PauseTime;

            return implementer;
        }

        private static ImplementerViewModel CreateModel(Implementer implementer)
        {
            return new ImplementerViewModel
            {
                Id = implementer.Id,
                FIO = implementer.FIO,
                WorkingTime = implementer.WorkingTime,
                PauseTime = implementer.PauseTime
            };
        }
    }
}
