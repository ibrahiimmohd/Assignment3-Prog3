using System;
using System.Collections.Generic;

namespace Assignment3.Models
{
    public partial class Planet
    {
        public Planet() 
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public Planet(string name, string color) 
        {
            Name = name;
            Color = color;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public int PlanetId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
