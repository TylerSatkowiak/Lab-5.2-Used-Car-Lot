using System;
using System.Collections.Generic;

namespace Lab_5._2_Used_Car_Lot
{   class Car
    {
        //Member Functions
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        //No Argument constructor
        public Car()
        {
            Make = "Sold";
            Model = "Sold";
            Year = 0000;
            Price = 0000;
            CarLot.AddCar(this);
        }

        //Base Constructor
        public Car(string make, string model, int year, double price)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            CarLot.AddCar(this);
        }

        public override string ToString()
        {
            //return String.Format("{0,-14} {1,-10} {2,-5} {3,-8} {4,-10} {5,-10}", "Make", "Model", "Year", "Price", "New/Used", "Mileage");
            return String.Format("{0,-14} {1,-10} {2,-5} {3,-8}", $". {Make}", $"{Model}", $"{Year}", $"{Price}");
        }
    }



    class CarLot
    {
        //List
        public static List<Car> Cars = new List<Car>();
      
        //Printout of Cars in Lot
        public static void CarInventory()
        {
            for (int i = 0; i < Cars.Count; i++)
            {
                Console.WriteLine($"{i+1}{Cars[i]}");
            }
        }

        //AddCar function to use in constructor
        public static void AddCar(Car car)
        {
            Cars.Add(car);
        }

        public static void AddNewCar()
        {
            Console.WriteLine("Enter the manufacturer of the car: ");
            string manufacturer = Console.ReadLine();
            Console.WriteLine("Enter the make of the car: ");
            string group = Console.ReadLine();
            Console.WriteLine("Enter the year the car was made (ex. 2014): ");
            string modelYear = Console.ReadLine();
            int carYear = int.Parse(modelYear);

            Console.WriteLine("Enter the price for the car: ");
            string newPrice = Console.ReadLine();
            double carPrice = double.Parse(newPrice);

            Car newAddition = new Car(manufacturer, group, carYear, carPrice);
        }

        //Remove function
        public static void RemoveCar(int car)
        {
            Cars.RemoveAt(car);
        }
    }




    //Used Car class
    class UsedCar : Car
    {
        //\Member function
        public double Mileage { get; set; }

        //Used Car constructor, inheriting from 'Car' class.
        public UsedCar (string make, string model, int year, double price, double mileage) :  base(make, model, year, price)
        {
            Mileage = mileage;
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("{0,-10} {1,-10}", "(USED)", $"{Mileage}");
        }
        public static void AddUsedCar()
        {
            Console.WriteLine("Enter the manufacturer of the car: ");
            string manufacturer = Console.ReadLine();
            Console.WriteLine("Enter the make of the car: ");
            string group = Console.ReadLine();
            Console.WriteLine("Enter the year the car was made (ex. 2014): ");
            string modelYear = Console.ReadLine();
            int model_Year = int.Parse(modelYear);

            Console.WriteLine("Enter the price for the car: ");
            string newPrice = Console.ReadLine();
            double new_Price = double.Parse(newPrice);

            Console.WriteLine("Enter the car's mileage: ");
            string miles = Console.ReadLine();
            double miles_ = double.Parse(miles);

            UsedCar usedAddition = new UsedCar(manufacturer, group, model_Year, new_Price, miles_);
        }

    }




    class Program
    {
        //Method to quit program.
        static bool Quit()
        {
            //Method called to quit or restart.
            Console.WriteLine("");
            Console.WriteLine("Quit?. 'Y' to quit, any other key to continue.");
            string y = Console.ReadLine().ToLower();
            if (y == "y")
            {
                return false;
            }
            else
            {
                Console.Clear();
                return true;
            }
        }
        static void Main()
        {
            Car tesla = new Car("Tesla", "Cybertruck", 2020, 35000);
            Car bronco = new Car("Ford", "Bronco", 2020, 50000);
            Car viper = new Car("Dodge", "Viper", 2020, 45000);
            UsedCar ford = new UsedCar("Ford", "Focus RS", 2016, 25000, 75000);
            UsedCar toyota = new UsedCar("Toyota", "Prius", 2012, 15000, 10000);
            UsedCar koeniggsegg = new UsedCar("Koeniggsegg", "Agera", 2016, 100000, 75000);

            int number = 0;
            Console.WriteLine("Welcome to the Car Lot!");

            do
            {
                CarLot.CarInventory();
                Console.WriteLine($"{CarLot.Cars.Count + 1}. Add a car");
                Console.WriteLine($"{CarLot.Cars.Count + 2}. Quit");
                Console.WriteLine("");
                Console.WriteLine("Which car would you like to purchase?");

                string entry = Console.ReadLine();
                if (!int.TryParse(entry, out number))
                {
                    Console.WriteLine("Please have a valid input next time.");
                }

                if (number < CarLot.Cars.Count+1)
                {
                    Console.WriteLine(CarLot.Cars[number - 1].Make);
                    Console.WriteLine("Confirm purchase? 'Y' to confirm, else any other value to cancel.");
                    string yn = Console.ReadLine().ToLower();
                    if (yn == "y")
                    {
                        Console.WriteLine("You have succesfully purchased the " + CarLot.Cars[number - 1].Make);
                        CarLot.RemoveCar(number - 1);
                    }
                }
                else if(number == CarLot.Cars.Count+1)
                {
                    Console.WriteLine("Is this a new or used car?");
                    while (true)
                    {
                        string NewUsed = Console.ReadLine().ToLower();
                        if (NewUsed == "new")
                        {
                            //Call seperate Method to Add New Car to list.
                            CarLot.AddNewCar();
                            break;
                        }
                        else if (NewUsed == "used")
                        {
                            //Call seperate Method to Add Used Car to list.
                            UsedCar.AddUsedCar();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter new or used.");
                        }
                    }
                    
                }
                else if (number == CarLot.Cars.Count + 2)
                {
                    Quit();
                }
                else
                {
                    Console.WriteLine("Not a valid input.");
                }
            }

            while (Quit());
        }
    }
}