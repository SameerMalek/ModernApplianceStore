using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
        public class Refrigerator : Appliance
        {
            private String numofDoors;
            private int height;
            private int width;
            public Refrigerator(long itemNumber, string brand, int quantity, double wattage, string color, double price, String numofdoor, int height, int width) : base(itemNumber, brand, quantity, wattage, color, price)
            {
                NumofDoors = numofdoor;
                Height = height;
                Width = width;
            }
            public override string ToString()
            {
                return $"Item_Number:{ItemNumber}\n" + $"Brand:{Brand}\n" + $"Quantity:{Quantity}\n" + $"Wattage:{Wattage}\n" + $"Color:{Color}\n" + $"Price:{Price}\n" + $"NumberOfDoors:{NumofDoors}\n" + $"Height:{Height}\n" + $"Width:{Width}\n";
            }
            public String NumofDoors { get => numofDoors; set { if (value == "2") { numofDoors = "double doors"; } else if (value == "3") { numofDoors = "three doors"; } else { numofDoors = "four doors"; } } }
            public int Height { get => height; set => height = value; }
            public int Width { get => width; set => width = value; }
            public override string Formatforfile()
            {
                if (numofDoors == "double doors")
                {
                    numofDoors = "2";
                }
                else if (numofDoors == "three doors")
                {
                    numofDoors = "3";
                }
                else
                {
                    numofDoors = "4";
                }
                string[] args =
                {
                base.Formatforfile(),numofDoors.ToString(),height.ToString(),width.ToString(),
            };
                return string.Join(";", args);
            }
        }
    }


