using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Planet
    {
        private static int _ID = 0;

        public int ID { get { return _ID; } }

        public string Name { get; }

        public string Color { get; }

        public Planet(string name, string color)
        {
            _ID++;
            this.Name = name;
            this.Color = color;
        }

        public static List<string> GetItems()
        {
            List<string> items = new List<string>();
            items.Add("Pick a planet");

            items.Add(new Planet("Earth", "Red").ToString());
            items.Add(new Planet("Jupiter", "Blue").ToString());
  
            return items;
        }

        public override string ToString()
        {
            return $"{Name,-8}{Color,5}";
        }
    }
}
