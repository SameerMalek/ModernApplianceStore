using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Driver
    {
        List<Appliance> appliances = new List<Appliance>();
        public static void Main()
        {

            Driver d = new Driver();
            //File Handling:
            d.fileHandling();
            int no = 6;
            while (no != 5)
            {
                Console.WriteLine("Welcome to Modern Appliances!\nHow may we assist you?\n1 – Check out appliance\n2 – Find appliances by brand\n3 – Display appliances by type\n4 – Produce random appliance list\n5 – Save & exit\nEnter option:");
                no = Convert.ToInt32(Console.ReadLine());
                if (no == 1)
                {
                    d.checkout(d.appliances);
                }
                else if (no == 2)
                {
                    d.getApplianceByName();
                }
                else if (no == 3)
                {
                    d.getApplianceByType();
                }
                else if (no == 4)
                {
                    d.getRandomAppliance();
                }
                else if (no == 5)
                {
                    d.saveToFile("..\\..\\Res\\appliances.txt");
                }
                else
                {
                    Console.WriteLine("The output you entered is not correct, please try again!");
                }
            }
        }
        //Reading the application.txt file:
        public void fileHandling()
        {
            string[] path = File.ReadAllLines("..\\..\\Res\\appliances.txt");
            foreach (string line in path)
            {
                string[] field = line.Split(';');
                string s = field[0];
                char firstchar = s[0];
                switch (firstchar)
                {
                    case '1':
                        Refrigerator refrigerator = new Refrigerator(long.Parse(field[0]), field[1], int.Parse(field[2]), Convert.ToDouble(field[3]), field[4], Convert.ToDouble(field[5]), field[6], int.Parse(field[7]), int.Parse(field[8]));
                        appliances.Add(refrigerator);
                        break;
                    case '2':
                        Vacuum vacuum = new Vacuum(long.Parse(field[0]), field[1], Convert.ToInt32(field[2]), Convert.ToDouble(field[3]), field[4], Convert.ToDouble(field[5]), field[6], field[7]);
                        appliances.Add(vacuum);
                        break;
                    case '3':
                        Microwave microwave = new Microwave(long.Parse(field[0]), field[1], Convert.ToInt32(field[2]), Convert.ToDouble(field[3]), field[4], Convert.ToDouble(field[5]), Convert.ToDouble(field[6]), field[7]);
                        appliances.Add(microwave);
                        break;
                    case '4':
                    case '5':
                        Dishwasher dishwasher = new Dishwasher(long.Parse(field[0]), field[1], Convert.ToInt32(field[2]), Convert.ToDouble(field[3]), field[4], Convert.ToDouble(field[5]), field[6], field[7]);
                        appliances.Add(dishwasher);
                        break;
                    default: break;
                }
            }

        }
        private void checkout(List<Appliance> appliances)
        {
            Console.WriteLine("Enter the item number of an appliance:");
            long numb = Convert.ToInt64(Console.ReadLine());
            var item = appliances.FirstOrDefault(it => it.ItemNumber.Equals(numb));
            if (item != null)
            {
                item.checkout(numb);
            }
            else
            {
                Console.WriteLine("There are no appliances with this particular number.");
            }
        }
        private void getApplianceByName()
        {
            Console.WriteLine("Enter brand to search for an appliance:");
            string nameofbrand = Console.ReadLine();
            Console.WriteLine("\nMatching Appliances are as following:\n");
            bool flag = false;
            foreach (Appliance app in appliances)
            {
                if (app.Brand == nameofbrand)
                {
                    Console.WriteLine(app);
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("There are no appliances with such brand name.");
            }

        }
        private void getRandomAppliance()
        {
            Console.WriteLine("Enter number of appliances:");
            int x = Convert.ToInt32(Console.ReadLine());
            Random rnd = new Random();
            for (int i = 0; i < x; i++)
            {
                int b = rnd.Next(appliances.Count);
                Console.WriteLine(appliances[b]);
            }
        }
        private void getApplianceByType()
        {
            Console.WriteLine("Appliance Types\n1 – Refrigerators\n2 – Vacuums\n3 – Microwaves\n4 – Dishwashers\nEnter type of appliance:");
            int x = Convert.ToInt32(Console.ReadLine());
            if (x == 1)
            {
                Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                string num = Console.ReadLine();
                if (num == "2")
                {
                    num = "double doors";
                }
                else if (num == "3")
                {
                    num = "three doors";
                }
                else { num = "four doors"; }
                Console.WriteLine("Matching Refrigerator:");
                foreach (Appliance appliance in appliances)
                {
                    if (appliance is Refrigerator)
                    {
                        Refrigerator refrigerator = (Refrigerator)appliance;
                        if (refrigerator.NumofDoors == num)
                        {
                            Console.WriteLine(refrigerator);
                        }
                    }
                }
            }
            else if (x == 2)
            {
                Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");
                string y = Console.ReadLine();
                if (y == "18")
                {
                    y = "Low";
                }
                else
                {
                    y = "High";
                }
                Console.WriteLine("Matching Vacuum:");
                foreach (Appliance appliance in appliances)
                {
                    if (appliance is Vacuum)
                    {
                        Vacuum vaccum = (Vacuum)appliance;
                        if (vaccum.BatteryVoltage == y)
                        {
                            Console.WriteLine(vaccum);
                        }
                    }
                }
            }
            else if (x == 3)
            {
                Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");
                string z = Console.ReadLine();
                if (z == "K")
                {
                    z = "Kitchen";
                }
                else
                {
                    z = "work site";
                }
                Console.WriteLine("Matching microwaves:");
                foreach (Appliance appliance in appliances)
                {
                    if (appliance is Microwave)
                    {
                        Microwave microwave = (Microwave)appliance;
                        if (microwave.Roomtype == z)
                        {
                            Console.WriteLine(microwave);
                        }
                    }
                }
            }
            else if (x == 4)
            {
                Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                string a = Console.ReadLine();
                if (a == "Qt")
                {
                    a = "Quietest";
                }
                else if (a == "Qr")
                {
                    a = "Quieter";
                }
                else if (a == "Qu")
                {
                    a = "Quiet";
                }
                else if (a == "M")
                {
                    a = "Moderate";
                }
                Console.WriteLine("Matching dishwashers:");
                foreach (Appliance appliance in appliances)
                {
                    if (appliance is Dishwasher)
                    {
                        Dishwasher dishwasher = (Dishwasher)appliance;
                        if (dishwasher.SoundRating == a)
                        {
                            Console.WriteLine(dishwasher);
                        }
                    }
                }
            }
        }
        private void saveToFile(string fName)
        {
            using (TextWriter savetxt = new StreamWriter(fName))
            {
                foreach (Appliance appliance in appliances)
                {
                    string format = appliance.Formatforfile();
                    savetxt.WriteLine(format + ";");
                }
            }
        }
    }
}
