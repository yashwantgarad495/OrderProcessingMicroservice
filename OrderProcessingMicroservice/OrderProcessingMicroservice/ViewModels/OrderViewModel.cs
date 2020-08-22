using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessingMicroservice.ViewModels
{
    public class OrderViewModel
    {

        public string ClientName { get; set; }
        public int OrderStage { get; set; }
        public int ItemName { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentType { get; set; }
        public string SpecialOrderInstructions { get; set; }
        public string AdditionalNotes { get; set; }
        public DateTime LastUpdatedDTTM { get; set; } = DateTime.Now;
    }
}
