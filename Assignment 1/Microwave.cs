using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Microwave : Appliance
    {
        private double capacity;
        private string roomtype;

        public Microwave(long itemNumber, string brand, int quantity, double wattage, string color, double price, double capacity, string roomtype) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            Capacity = capacity;
            Roomtype = roomtype;
        }
        public override string ToString()
        {
            return $"Item_Number:{ItemNumber}\n" + $"Brand:{Brand}\n" + $"Quantity:{Quantity}\n" + $"Wattage:{Wattage}\n" + $"Color:{Color}\n" + $"Price:{Price}\n" + $"Capacity:{Capacity}\n" + $"RoomType:{Roomtype}\n";
        }
        public double Capacity { get => capacity; set => capacity = value; }
        public string Roomtype
        {
            get => roomtype; set
            {
                {
                    if (value == "K")
                    {
                        roomtype = "Kitchen";
                    }
                    else
                    {
                        roomtype = "work site";
                    }
                }
            }
        }
        public override string Formatforfile()
        {
            if (roomtype == "Kitchen")
            {
                roomtype = "K";
            }
            else
            {
                roomtype = "W";
            }
            string[] args =
            {
                base.Formatforfile(),capacity.ToString(),roomtype
            };
            return string.Join(";", args);
        }
    }
}
