using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public OrderDetail OrderDetails { get; set; }
        public Finance Finance { get; set; }

        [NotMapped]
        public decimal TotalPrice
        {
            get
            {
                if (OrderDetails != null)
                {
                    return OrderDetails.UnitPrice;
                }
                return 0;
            }
        }
    }
}
