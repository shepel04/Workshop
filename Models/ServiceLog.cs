using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Models
{
    public class ServiceLog
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceDescription{ get; set; }
        public decimal ServiceCost { get; set; }
    }
}
