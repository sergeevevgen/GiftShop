using System.ComponentModel.DataAnnotations;

namespace GiftShopDatabaseImplement.Models
{
    public class GiftComponent
    {
        /// <summary>
        /// Сколько компонентов, требуется при изготовлении подарков
        /// </summary>
        public int Id { get; set; }

        public int GiftId { get; set; }

        public int ComponentId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Component Component { get; set; }

        public virtual Gift Gift { get; set; }
    }
}
