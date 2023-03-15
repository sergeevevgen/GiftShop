using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopDatabaseImplement.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string ClientFIO { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Внешний ключ (связь один ко многим)
        /// </summary>
        [ForeignKey("ClientId")]
        public virtual List<Order> Orders { get; set; }
    }
}
