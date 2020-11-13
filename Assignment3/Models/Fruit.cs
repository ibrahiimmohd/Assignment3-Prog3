using System;
using System.Collections.Generic;

namespace Assignment3.Models
{
    public partial class Fruit
    {
        public int FruitId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
