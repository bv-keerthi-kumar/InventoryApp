using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Inventory.Data.Models
{
    public partial class Inventory
    {        
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public decimal? Price { get; set; }
        public DateTime CreatedOn { get; set; }

        [JsonIgnore]
        public DateTime? ModifiedOn { get; set; }
    }
}
