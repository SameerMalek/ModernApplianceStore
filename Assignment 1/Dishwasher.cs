using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Dishwasher : Appliance
    {
        private string feature;
        private string soundRating;

        public Dishwasher(long itemNumber, string brand, int quantity, double wattage, string color, double price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            Feature = feature;
            SoundRating = soundRating;
        }

        public override string ToString()
        {
            return $"Item_Number:{ItemNumber}\n" + $"Brand:{Brand}\n" + $"Quantity:{Quantity}\n" + $"Wattage:{Wattage}\n" + $"Color:{Color}\n" + $"Price:{Price}\n" + $"Feature:{Feature}\n" + $"SoundRating:{SoundRating}\n";
        }
        public string Feature { get => feature; set => feature = value; }
        public string SoundRating
        {
            get => soundRating; set
            {
                if (value == "Qt")
                {
                    soundRating = "Quietest";
                }
                else if (value == "Qr")
                {
                    soundRating = "Quieter";
                }
                else if (value == "Qu")
                {
                    soundRating = "Quiet";
                }
                else if (value == "M")
                {
                    soundRating = "Moderate";
                }
            }

        }
        public override string Formatforfile()
        {
            if (soundRating == "Quietest")
            {
                soundRating = "Qt";
            }
            else if (soundRating == "Quieter")
            {
                soundRating = "Qr";
            }
            else if (soundRating == "Quiet")
            {
                soundRating = "Qu";
            }
            else
            {
                soundRating = "M";
            }
            string[] args =
            {
                base.Formatforfile(),feature,soundRating
            };
            return string.Join(";", args);
        }
    }
}
