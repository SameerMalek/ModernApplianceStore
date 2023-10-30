using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Appliance
    {
        // Private variables: 
        private long itemNumber;
        private string brand;
        private int quantity;
        private double wattage;
        private string color;
        private double price;

        // Constructors and GETTER AND SETTERS: 
        public Appliance(long itemNumber, string brand, int quantity, double wattage, string color, double price)
        {
            ItemNumber = itemNumber;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Color = color;
            Price = price;
        }
        public long ItemNumber { get => itemNumber; set => itemNumber = value; }
        public string Brand { get => brand; set => brand = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Wattage { get => wattage; set => wattage = value; }
        public string Color { get => color; set => color = value; }
        public double Price { get => price; set => price = value; }

        // Boolean Method for checking availibilty of a product:
        public bool isAvaliable()
        {
            return Quantity > 0;
        }
        public void checkout(long number)
        {
            if (isAvaliable())
            {
                Quantity--;
                Console.WriteLine("Appliance " + itemNumber + " has been checked out.");
            }
            else
            {
                Console.WriteLine("The appliance is not available to be checked out.");
            }
        }
        public virtual string Formatforfile()
        {
            string[] args =
            {
                itemNumber.ToString(),brand,quantity.ToString(),wattage.ToString(),color,price.ToString()
            };
            return string.Join(";", args);
        }
        // Tostring method :
        public override string ToString()
        {
            return $"Item_Number:{ItemNumber}\n" + $"Brand:{Brand}\n" + $"Quantity:{Quantity}\n" + $"Wattage:{Wattage}\n" + $"Color:{Color}\n" + $"Price:{Price}\n";
        }
    }
}

