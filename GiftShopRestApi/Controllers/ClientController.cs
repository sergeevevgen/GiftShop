﻿using GiftShopContracts.BindingModels;
using GiftShopContracts.BusinessLogicsContracts;
using GiftShopContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GiftShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientLogic _logic;
        private readonly IMessageInfoLogic _messageLogic;

        public ClientController(IClientLogic logic, IMessageInfoLogic messageInfoLogic)
        {
            _logic = logic;
            _messageLogic = messageInfoLogic;
        }

        [HttpGet]
        public ClientViewModel Login(string login, string password)
        {
            var list = _logic.Read(new ClientBindingModel
            {
                Email = login,
                Password = password
            });
            return (list != null && list.Count > 0) ? list[0] : null;
        }

        [HttpPost]
        public void Register(ClientBindingModel model) =>
            _logic.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateData(ClientBindingModel model) =>
            _logic.CreateOrUpdate(model);

        [HttpGet]
        public List<MessageInfoViewModel> GetClientsMessages(int clientid) =>
            _messageLogic.Read(new MessageInfoBindingModel { ClientId = clientid });
    }
}
