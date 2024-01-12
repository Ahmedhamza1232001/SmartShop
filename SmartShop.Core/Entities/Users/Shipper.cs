using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Core.Entities.Users
{
    public class Shipper : Person
    {
        public required string ShipCost { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
