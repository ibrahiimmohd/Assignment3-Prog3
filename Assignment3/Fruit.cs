using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Fruit
    {
        private static int _ID = 0;

        public int ID { get { return _ID; } }

        public string Name { get; }

        public string Color { get; }

        public Fruit(string name, string color)
        {
            _ID++;
            this.Name = name;
            this.Color = color;
        }

        public static List<string> GetItems()
        {
            List<string> items = new List<string>();
            items.Add("Pick a fruit");

            items.Add(new Fruit("Kiwi", "Red").ToString());
            items.Add(new Fruit("Grape", "Blue").ToString());
            items.Add(new Fruit("Dates", "Red").ToString());
            items.Add(new Fruit("Pear", "Blue").ToString());

            return items;
        }

        public override string ToString()
        {    
           return $"{Name,-8}{Color,5}";
        }
    }
}
