using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Vacuum : Appliance
    {
        private string grade;
        private string batteryVoltage;
        public Vacuum(long itemNumber, string brand, int quantity, double wattage, string color, double price, string grade, string batteryVoltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            Grade = grade;
            BatteryVoltage = batteryVoltage;
        }
        public override string ToString()
        {
            return $"Item_Number:{ItemNumber}\n" + $"Brand:{Brand}\n" + $"Quantity:{Quantity}\n" + $"Wattage:{Wattage}\n" + $"Color:{Color}\n" + $"Price:{Price}\n" + $"Grade:{Grade}\n" + $"BatteryVoltage:{BatteryVoltage}\n";
        }
        public string Grade { get => grade; set => grade = value; }
        public string BatteryVoltage
        {
            get => batteryVoltage; set
            {
                if (value == "18")
                { batteryVoltage = "Low"; }
                else
                {
                    batteryVoltage = "High";
                }

            }

        }
        public override string Formatforfile()
        {
            if (batteryVoltage == "Low")
            {
                batteryVoltage = "18";
            }
            else
            {
                batteryVoltage = "24";
            }
            string[] args =
            {
                base.Formatforfile(),grade,batteryVoltage
            };
            return string.Join(";", args);
        }
    }
}
