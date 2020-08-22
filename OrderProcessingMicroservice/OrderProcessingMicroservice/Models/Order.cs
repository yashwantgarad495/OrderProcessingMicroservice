using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessingMicroservice.Models
{
    public class Order
    {

        /// <summary>
        ///     Unique Id of order
        /// </summary>
        [Required]
        public int OrderId { get; set; }

        /// <summary>
        ///     Client information who has placed the order
        /// </summary>
        [Required]
        [Display(Name = "Client")]
        public int ClientId { get; set; }

        /// <summary>
        ///     Order's current stage
        /// </summary>
        [Required]
        [Display(Name = "Order Stage")]
        public int OrderStageId { get; set; }

        /// <summary>
        ///     Item id whose order is placed.
        ///     Limitation: Each order can contain only 1 item
        /// </summary>
        [Required]
        public int ItemId { get; set; }

        /// <summary>
        /// Order Date and Time
        /// </summary>
        [Required]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        /// <summary>
        ///     Shipping Address : -
        ///     Mailing Address of Client
        ///     Billing Address of Client
        /// </summary>
        [Required]
        public string ShippingAddress { get; set; }

        /// <summary>
        ///     PaymentType : -
        ///     PaymentType to process per business Rule
        ///     Billing Address of Client
        /// </summary>
        [Required]
        public string PaymentType { get; set; }
        /// <summary>
        ///     Special Instruction if Any
        /// </summary>
        [MaxLength(255)]
        public string SpecialOrderInstructions { get; set; }

        /// <summary>
        ///     Additional Notes if any
        /// </summary>
        [MaxLength(255)]
        public string AdditionalNotes { get; set; }

        /// <summary>
        /// Last updated date time of order
        /// </summary>
        public DateTime LastUpdatedDTTM { get; set; } = DateTime.UtcNow;
    }
}
