using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    
        public enum MenuContents
        {
            CafeAmericano = 1,
            CafeMocha,
            Cortado,
            SingleEspresso,
            DoubleEspresso,
            BreakfastSandwich,
            Muffin,
            FruitCup
        }

        // POCO
        public class KC_Poco
        {
            //Empty Constructor
            public KC_Poco(KC_Poco newItems) { }
            public KC_Poco() { }


            //Full Constructor
            public KC_Poco(string name, int number, string description, string ingredients, double price)
            {
                Name = name;
                Number = number;
                Description = description;
                Ingredients = ingredients;
                Price = price;
            }

            public string Name { get; set; }
            public int Number { get; set; }
            public string Description { get; set; }
            public string Ingredients { get; set; }
            public double Price { get; set; }

        }
    }

