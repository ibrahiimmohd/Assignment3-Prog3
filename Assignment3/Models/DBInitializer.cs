using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Models
{

    public class DBInitializer : DropCreateDatabaseAlways<DBHelperContext>
    {
        protected override void Seed(DBHelperContext context)
        {
            IList<Fruit> defaultFruits = new List<Fruit>();
            IList<Planet> defaultPlanets = new List<Planet>();

            defaultFruits.Add(new Fruit("Banana", "Yellow"));
            defaultFruits.Add(new Fruit("Mango", "White"));
            defaultFruits.Add(new Fruit("Apple", "Red"));
            defaultFruits.Add(new Fruit("Watermelon", "Blue"));
            defaultFruits.Add(new Fruit("Durian", "Green"));
            defaultFruits.Add(new Fruit("Lychee", "Black"));

            defaultPlanets.Add(new Planet("Earth", "Green"));
            defaultPlanets.Add(new Planet("Moon", "White"));
            defaultPlanets.Add(new Planet("Mercury", "Blue"));
            defaultPlanets.Add(new Planet("Venus", "Yellow"));
            defaultPlanets.Add(new Planet("Mar", "Black"));
            defaultPlanets.Add(new Planet("Sun", "Red"));

            context.Fruits.AddRange(defaultFruits);
            context.Planets.AddRange(defaultPlanets);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
