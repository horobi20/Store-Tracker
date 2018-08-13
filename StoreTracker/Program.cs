using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Course: CSC10210 - Object Oriented Program Development
 * Project: Store Tracker (Part 2)
 * Author: Harry Robinson (227870039)
 * Date: 26/12/2017 
 */
namespace StoreTracker
{
    class Program
    {

        /*This interface provides the common Property name to all classes, and the calculator
         * method. 
         */ 
        public interface IProperty
        {
            string Name { get; set;}
            double CalculateMonthlyMaintenanceFee();

        }

        //provides common properties between the store types and allows override of 
        //the area calculator method.
        abstract class Store
        {
            public double Length { get; set; }
            public double Width { get; set; }
            public double FeeRate { get; set; }
            public bool Occupied { get; set; }


            public abstract double GetArea();

        }

        class PermanentStore : Store, IProperty
        {
            public string Name { get; set; }
            public double Height { get; set; }

            //default
            public PermanentStore()
            {

            }

            //full Property initialisation constructor.
            public PermanentStore(string n, double h, double l, double w, double f, bool o)
            {
                Name = n;
                Height = h;
                Length = l;
                Width = w;
                FeeRate = f;
                Occupied = o;
            }

            public override double GetArea()
            {
                return Length * Width * Height;
            }

            public double CalculateMonthlyMaintenanceFee()
            {
                return GetArea() * FeeRate;
            }
        }

        class NonPermanentStore : Store, IProperty
        {
            public string ExpirationDate { get; set; }
            public string Name { get; set; }

            //default constructor
            public NonPermanentStore()
            {

            }

            //full Property initialisation constructor.
            public NonPermanentStore(string n, double l, double w, double f, string e, bool o)
            {
                Name = n;
                Length = l;
                Width = w;
                FeeRate = f;
                ExpirationDate = e;
                Occupied = o;
            }
           
            public override double GetArea()
            {
                return Length * Width;
            }

            public double CalculateMonthlyMaintenanceFee()
            {
               return GetArea() * FeeRate;
            }
        }

        /*The mall class contains arrays of each store type. Enables user input to add
         * new stores to the arrays, edit or delete the details of existing stores, and
         * facilitates console information display and user input.
         */
        class Mall : IProperty
        {
            private const int MAX_PSTORES = 6;
            private const int MAX_NONPSTORES = 10;

            PermanentStore[] PStoreArray = new PermanentStore[MAX_PSTORES];
            NonPermanentStore[] NonPStoreArray = new NonPermanentStore[MAX_NONPSTORES];

            public string Name { get; set; }

            public Mall()
            {

            }

            public Mall(string n)
            {
                Name = n;
            }

            // Instantiates a number of test stores, and assigns them to the appropriate array of objects.
            public void InitializeStores()
            {
                CreatePStores();
                CreateNonPStores();
                
                void CreateNonPStores()
                {
                    int nonPStoreIndex = 0;

                    NonPermanentStore nonPStore1 = new NonPermanentStore("NP1: Byron Bay Beef Jerky", 5.00, 1.50, 70.00, "01/03/2018", true);
                    NonPStoreArray[nonPStoreIndex] = nonPStore1;
                    nonPStoreIndex++;

                    NonPermanentStore nonPStore2 = new NonPermanentStore("NP2: Sally's Socks", 4.00, 3.00, 70.00, "01/06/2018", true);
                    NonPStoreArray[nonPStoreIndex] = nonPStore2;
                    nonPStoreIndex++;

                    NonPermanentStore nonPStore3 = new NonPermanentStore("NP3: Janky Jewels", 2.00, 4.00, 70.00, "01/01/2018", true);
                    NonPStoreArray[nonPStoreIndex] = nonPStore3;
                    nonPStoreIndex++;

                    NonPermanentStore nonPStore4 = new NonPermanentStore("NP4: VACANCY", 4.00, 8.00, 70.00, "--/--/----", false);
                    NonPStoreArray[nonPStoreIndex] = nonPStore4;
                    nonPStoreIndex++;

                    NonPermanentStore nonPStore5 = new NonPermanentStore("NP5: Lucky Magic Healing Water", 1.30, 3.60, 70.00, "01/09/2018", true);
                    NonPStoreArray[nonPStoreIndex] = nonPStore5;
                    nonPStoreIndex++;

                    NonPermanentStore nonPStore6 = new NonPermanentStore("NP6: VACANCY", 4.00, 8.00, 70.00, "--/--/----", false);
                    NonPStoreArray[nonPStoreIndex] = nonPStore6;
                    nonPStoreIndex++;

                    NonPermanentStore nonPStore7 = new NonPermanentStore("NP7: VACANCY", 4.00, 8.00, 70.00, "--/--/----", false);
                    NonPStoreArray[nonPStoreIndex] = nonPStore7;
                    nonPStoreIndex++;

                    NonPermanentStore nonPStore8 = new NonPermanentStore("NP8: Bamboo Massage", 6.00, 4.00, 70.00, "01/03/2018", true);
                    NonPStoreArray[nonPStoreIndex] = nonPStore8;
                    nonPStoreIndex++;

                    NonPermanentStore nonPStore9 = new NonPermanentStore("NP9: Super Souvenirs", 2.00, 6.50, 70.00, "01/01/2018", true);
                    NonPStoreArray[nonPStoreIndex] = nonPStore9;
                    nonPStoreIndex++;

                    NonPermanentStore nonPStore10 = new NonPermanentStore("NP10: Handmade Toys", 1.50, 2.50, 70.00, "01/13/2018", true);
                    NonPStoreArray[nonPStoreIndex] = nonPStore10;

                }

                void CreatePStores()
                {
                    int pStoreIndex = 0;

                    PermanentStore pStore1 = new PermanentStore("P1: IGA Supermarket", 3.00, 42.00, 33.70, 150.00, true);
                    PStoreArray[pStoreIndex] = pStore1;
                    pStoreIndex++;

                    PermanentStore pStore2 = new PermanentStore("P2: Organic Health Food", 3.00, 28.00, 18.20, 150.00, true);
                    PStoreArray[pStoreIndex] = pStore2;
                    pStoreIndex++;

                    PermanentStore pStore3 = new PermanentStore("P3: French Patisserie", 3.00, 20.00, 15.00, 150.00, true);
                    PStoreArray[pStoreIndex] = pStore3;
                    pStoreIndex++;

                    PermanentStore pStore4 = new PermanentStore("P4: Rebel Sport", 3.00, 26.00, 36.00, 150.00, true);
                    PStoreArray[pStoreIndex] = pStore4;
                    pStoreIndex++;

                    PermanentStore pStore5 = new PermanentStore("P5: All Ages Hair Salon & Barber", 3.00, 12.00, 14.60, 150.00, true);
                    PStoreArray[pStoreIndex] = pStore5;
                    pStoreIndex++;

                    PermanentStore pStore6 = new PermanentStore("P6: BWS Liquor Store", 3.00, 18.00, 12.00, 150.00, true);
                    PStoreArray[pStoreIndex] = pStore6;

                }
            }

            public void HandleMenuInput()
            {
                PromptMenuInput();
                ProcessMenuInput();

                void PromptMenuInput()
                {
                    Console.WriteLine("Options: ");
                    Console.WriteLine();
                    Console.WriteLine("1: Calculate the total maintenance fees from all occupied" +
                        " stores");
                    Console.WriteLine("2: Select a store to view and edit details");
                    Console.WriteLine("3: Add a new store");
                    Console.WriteLine();

                }

                void ProcessMenuInput()
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:

                            Console.WriteLine("Total mall maintenance fees are " +
                                CalculateMonthlyMaintenanceFee().ToString("C") +
                                " per month");
                            break;

                        case ConsoleKey.D2:

                            Console.Clear();
                            HandleStoreSelect();

                            break;

                        case ConsoleKey.D3:

                            Console.Clear();
                            AddNewStore();
                            break;

                        default:

                            Console.WriteLine("Wrong Key, try again!");
                            break;
                    }
                }
            }

            public void DisplayAllStores()
            {
                Console.WriteLine("Welcome to Harry's Mall Manager!");
                Console.WriteLine();
                Console.WriteLine("Viewing: " + this.Name);
                Console.WriteLine();

                DisplayPStores();
                Console.WriteLine();
                DisplayNonPStores();
                Console.WriteLine();

            }

            //Displays all permanent stores by iterating through the array.
            //Can override for non-permanent store type.
            public void DisplayPStores()
            {

                Console.WriteLine("Permanent Stores: ");
                foreach (PermanentStore element in PStoreArray)
                {
                    if (element.Occupied)
                    {
                        Console.WriteLine(element.Name + ": Occupied " + " |Store Maintenance: " +
                            element.CalculateMonthlyMaintenanceFee().ToString("C"));
                    }
                    else
                    {
                        Console.WriteLine("P" + Array.IndexOf(PStoreArray, element) + ": VACANCY");
                    }
                }
            }

            public void DisplayNonPStores()
            {

                Console.WriteLine("Non-Permanent Stores: ");
                foreach (NonPermanentStore element in NonPStoreArray)
                {
                    if (element.Occupied)
                    {
                        Console.WriteLine(element.Name + ": Occupied until: " +
                            element.ExpirationDate +
                            " |Store Maintenance: " +
                            element.CalculateMonthlyMaintenanceFee().ToString("C"));
                    }
                    else
                    {
                        Console.WriteLine("NP" + Array.IndexOf(NonPStoreArray, element) + ": VACANCY");
                    }
                }
            }
            //allows changing of existing store properties, uses overloading to handle
            //the different store types
            public void EditStore(PermanentStore store)
            {
                Console.WriteLine("Write a new name for the store and press 'Enter'.");
                Console.WriteLine();

                store.Name = "P" + (Array.IndexOf(PStoreArray, store) + 1) + 
                    ": " + Console.ReadLine();
                Console.WriteLine("Write new store dimensions in numerals below and press 'Enter'.");
                Console.WriteLine();
                Console.WriteLine("Length: ");
                store.Length = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Width: ");
                store.Width = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Height: ");
                store.Height = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Set the store occupancy below by typing 'true' or 'false'" +
                    "for a vacancy. Press 'Enter' to confirm ");
                store.Occupied = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine();

                DisplayStoreDetails(store);
            }

            //Allows user to overwrite Properties of selected store.
            public void EditStore(NonPermanentStore store)
            {
                Console.WriteLine("Write a new name for the store and press 'Enter'.");
                Console.WriteLine();

                store.Name = "NP" + (Array.IndexOf(NonPStoreArray, store) + 1) +
                    ": " + Console.ReadLine();
                Console.WriteLine("Write new store dimensions in numerals below and press 'Enter'.");
                Console.WriteLine();
                Console.WriteLine("Length: ");
                store.Length = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Width: ");
                store.Width = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Set the lease expiry date by typing numerals in the DD/MM/YYYY format.");
                store.ExpirationDate = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Set the store occupancy below by typing 'true' or 'false'" +
                    "for a store vacancy. ");
                store.Occupied = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine();

                DisplayStoreDetails(store);
            }

            //lets the user select the array, then a single store from that array
            //via StoreSelect();
            public void HandleStoreSelect()
            {
                Console.WriteLine("Select store type: ");
                Console.WriteLine("1: Permanent Store");
                Console.WriteLine("2: Non-Permanent Store");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:

                        ChooseStore(PStoreArray);
                        break;

                    case ConsoleKey.D2:

                        ChooseStore(NonPStoreArray);
                        break;

                    default:

                        Console.WriteLine("incorrect option selected. Try Again.");
                        break;

                }
            }

            //user can input a store number from the selected array to view its details
            //and then choose to edit them. Overrides for store[] type.
            public void ChooseStore(NonPermanentStore[] array)
            {
                int input;
                Console.Clear();
                Console.WriteLine("Choose a non-permanent store from the list below"
                    + " by typing in the store number and pressing 'Enter'.");
                Console.WriteLine();
                DisplayNonPStores();
                Console.WriteLine();

                input = Convert.ToInt32(Console.ReadLine());
                DisplayStoreDetails(array[(input - 1)]);
                Console.WriteLine();
                Console.WriteLine("1: Edit details");
                Console.WriteLine("2: Return to Menu");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:

                        EditStore(array[(input - 1)]);
                        PromptMainMenu();
                        break;

                    case ConsoleKey.D2:

                        MainMenu();
                        break;

                    default:

                        Console.WriteLine("incorrect option selected. Try Again.");
                        break;

                }
            }
 
            public void ChooseStore(PermanentStore[] array)
            {
                int input;
                Console.Clear();
                Console.WriteLine("Choose a permanent store from the list below"
                    + " by typing in the store number and pressing 'Enter'.");
                Console.WriteLine();
                DisplayPStores();
                Console.WriteLine();

                input = Convert.ToInt32(Console.ReadLine());
                DisplayStoreDetails(array[(input - 1)]);
                Console.WriteLine();
                Console.WriteLine("1: Edit details");
                Console.WriteLine("2: Return to Menu");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:

                        EditStore(array[(input - 1)]);
                        PromptMainMenu();
                        break;

                    case ConsoleKey.D2:

                        MainMenu();
                        break;

                    default:

                        Console.WriteLine("incorrect option selected. Try Again.");
                        break;

                }
            }

            //displays the details of the selected store.
            public void DisplayStoreDetails(NonPermanentStore nPStore)
            {
                Console.Clear();
                Console.WriteLine("Name: " + nPStore.Name);
                Console.WriteLine();
                Console.WriteLine("Length: " + nPStore.Length);
                Console.WriteLine();
                Console.WriteLine("Width: " + nPStore.Width);
                Console.WriteLine();
                Console.WriteLine("Expires on: " + nPStore.ExpirationDate);
                Console.WriteLine();
                Console.WriteLine("Fee Rate: " + nPStore.FeeRate);
                Console.WriteLine();
                Console.WriteLine("Occupied: " + nPStore.Occupied);

            }

            public void DisplayStoreDetails(PermanentStore pStore)
            {
                Console.Clear();
                Console.WriteLine("Name: " + pStore.Name);
                Console.WriteLine();
                Console.WriteLine("Length: " + pStore.Length);
                Console.WriteLine();
                Console.WriteLine("Width: " + pStore.Width);
                Console.WriteLine();
                Console.WriteLine("Height: " + pStore.Height);
                Console.WriteLine();
                Console.WriteLine("Fee Rate: " + pStore.FeeRate);
                Console.WriteLine();
                Console.WriteLine("Occupied: " + pStore.Occupied);

            }

            //clears the console and displays the main menu screen with options
            public void MainMenu()
            {
                Console.Clear();
                DisplayAllStores();
                HandleMenuInput();
            }

            //provides a return to menu
            public void PromptMainMenu()
            {
                Console.WriteLine("Press Escape to return to the main menu.");

                switch (Console.ReadKey(true).Key)
                {
                    case (ConsoleKey.Escape):

                        MainMenu();
                        break;

                    default:

                        PromptMainMenu();
                        break;

                }
            }

            // takes user input to create a new store instance and adds it to
            // the appropriate array after resizing it.
            public void AddNewStore()
            {
                string name;
                double length;
                double width;
                double height;
                double feeRate;
                string expirationDate;
                bool occupied;

                NewStoreInstructions();
                Console.Write("Name: ");
                FormatInstructions("Type in the name of the store, or leave blank if store is vacant.");
                GenerateExceptionLabel:
                Console.SetCursorPosition(10, 3);

                name = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop + 4);

                Console.Write("Length: ");
                FormatInstructions("Enter the length of the store in numerals.");
                Console.SetCursorPosition(10, Console.CursorTop);

                LengthExceptionLabel:

                try
                {
                    length = Convert.ToDouble(Console.ReadLine());
                    Console.SetCursorPosition(0, Console.CursorTop + 4);
                }
                catch (Exception)
                {
                    Console.WriteLine("Length value did not meet expected format." +
                        " Retype the desired value and press 'Enter'.");
                    goto LengthExceptionLabel;
                    throw;
                }

                Console.Write("Width: ");
                FormatInstructions("Enter the width of the store in numerals.");
                Console.SetCursorPosition(10, Console.CursorTop);

                WidthExceptionLabel:

                try
                {
                    width = Convert.ToDouble(Console.ReadLine());
                    Console.SetCursorPosition(0, Console.CursorTop + 4);
                }
                catch (Exception)
                {
                    Console.WriteLine("Width value did not meet expected format." +
                        " Retype the desired value and press 'Enter'.");
                    goto WidthExceptionLabel;
                    throw;
                }

                Console.Write("Height: ");
                FormatInstructions("Enter the height of the store in numerals. Set to '0' if store is non-permanent.");
                Console.SetCursorPosition(10, Console.CursorTop);

                HeightExceptionLabel:

                try
                {
                   
                    height = Convert.ToDouble(Console.ReadLine());

                    Console.SetCursorPosition(0, Console.CursorTop + 4);
                }
                catch (Exception)
                {
                    Console.WriteLine("Height value did not meet expected format." +
                        " Retype the desired value and press 'Enter'.");
                    goto HeightExceptionLabel;
                    throw;
                }

                Console.Write("Fee Rate: ");
                FormatInstructions("Enter the maintenance fee rate of the store in numerals.");
                Console.SetCursorPosition(10, Console.CursorTop);

                FeeExceptionLabel:

                try
                {
                    feeRate = Convert.ToDouble(Console.ReadLine());
                    Console.SetCursorPosition(0, Console.CursorTop + 4);
                }
                catch (Exception)
                {
                    Console.WriteLine("Fee Rate value did not meet expected format." +
                        " Retype the desired value and press 'Enter'.");
                    goto FeeExceptionLabel;
                    throw;
                }

                Console.Write("Expires: ");
                FormatInstructions("Enter the expiry date of the current store lease as DD/MM/YYYY."
                    + "Leave blank if store is permanent, or a vacant non-permanent store.");
                Console.SetCursorPosition(10, Console.CursorTop -1);

                ExpiryExceptionLabel:

                expirationDate = Console.ReadLine();

                switch (String.IsNullOrWhiteSpace(expirationDate))
                {
                    case true:
                        expirationDate = "--/--/----";
                        break;


                    default:

                        break;
                }

                try
                {
                    string.Format("{0:d}", expirationDate);
                    Console.SetCursorPosition(0, Console.CursorTop + 4);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Expiration Date value did not meet expected format." +
                        " Retype the desired value and press 'Enter'.");
                    goto ExpiryExceptionLabel;
                    throw;
                }

                Console.Write("Occupied: ");
                FormatInstructions("Write 'true' if store will be occupied, false if" +
                    " vacant.");

                Console.SetCursorPosition(10, Console.CursorTop);


                OccupiedExceptionLabel:

                try
                {
                    occupied = Convert.ToBoolean(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Occupied value did not meet expected format." +
                        " Retype the desired value and press 'Enter'.");
                    goto OccupiedExceptionLabel;
                    throw;
                }

                UserConfirmation();

                try
                {
                    GenerateStore(name, length, width, height, feeRate, expirationDate, occupied);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("New store values are incomplete. Please start again.");
                    goto GenerateExceptionLabel;
                    throw;
                }

                void UserConfirmation()
                {

                    Console.SetCursorPosition(0, Console.CursorTop + 3);
                    Console.WriteLine("Please review store details above." +
                        Environment.NewLine + "1: Generate a new store from these details"
                        + Environment.NewLine + "2: Restart store generation");

                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:

                            return;

                        case ConsoleKey.D2:

                            Console.Clear();
                            AddNewStore();
                            break;

                        default:

                            Console.WriteLine("incorrect option selected. Try Again.");
                            UserConfirmation();
                            break;

                    }
                }

                void FormatInstructions(string i)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                    Console.WriteLine();
                    Console.WriteLine(i);
                    Console.WriteLine();
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 4);
                }

                //handles the creation/insertion of a new store object and resizing of array.
                void GenerateStore(string n, double l, double w, double h, double f, string e, bool o)
                {
                    if(height == 0)
                    {
                    NonPermanentStore newNonPStore = new NonPermanentStore(n,l,w,f,e,o);
                    if (!occupied)
                    {
                        newNonPStore.Name = "VACANCY";
                        newNonPStore.ExpirationDate = "--/--/----";
                    }

                    Array.Resize(ref NonPStoreArray, NonPStoreArray.Length + 1);
                    newNonPStore.Name = "NP" + NonPStoreArray.Length + ": " + newNonPStore.Name;
                    NonPStoreArray[(NonPStoreArray.GetUpperBound(0))] = newNonPStore;
                    MainMenu();

                    }
                    else
                    {
                    PermanentStore newPStore = new PermanentStore(n,l,w,h,f,o);

                    Array.Resize(ref PStoreArray, PStoreArray.Length + 1);
                    newPStore.Name = "P" + PStoreArray.Length + ": " + newPStore.Name;
                    PStoreArray[(PStoreArray.GetUpperBound(0))] = newPStore;
                    MainMenu();

                    }
                }

                void NewStoreInstructions()
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(" To create a new store, enter the store details" +
                        " below using only the indicated format." + Environment.NewLine +
                        " Press 'Enter' to confirm your input.");
                    Console.WriteLine();

                }
            }

            //Calls the calculation of fees for each store by looping through the arrays.
            //Totals the amount.
            public double CalculateMonthlyMaintenanceFee()
            {
                double totalFee = 0;

                foreach(PermanentStore element in PStoreArray)
                {
                    if(element.Occupied == true)
                    {
                        totalFee += element.CalculateMonthlyMaintenanceFee();
                    }

                }

                foreach (NonPermanentStore element in NonPStoreArray)
                {

                    if (element.Occupied == true)
                    {
                        totalFee += element.CalculateMonthlyMaintenanceFee();
                    }
                }

                return totalFee;
            }
        }

        static void Main(string[] args)
        {
            Mall mall = new Mall("Oasis Shopping Mall");

            Console.SetWindowSize(120, 36);

            mall.InitializeStores();
            mall.MainMenu();
            Console.ReadLine();
        }
    }
}
