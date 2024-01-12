using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Core.Entities.Users
{
    public class Person : AppUser
    {
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string State { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string SNN { get; set; }
        public required string Phone { get; set; }
        public required string ImageId { get; set; }
        public required string ImageUrl { get; set; }
    }
}
