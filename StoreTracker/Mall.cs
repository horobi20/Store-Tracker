using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Course: CSC10210 - Object Oriented Program Development
 * Project: Store Tracker (assignment 2, Part 1)
 * Author: Harry Robinson (22787039)
 * Date: 03/01/2018 
 */
namespace StoreTracker
{
    class Mall
    {

        private const int maxStores = 4;

        IStore[] StoreArray = new IStore[maxStores];


        public string Name { get; set; }

        public Mall()
        {

        }

        public Mall(string n)
        {

            Name = n;

        }

        // Instantiates a small array of test stores, and assigns them to the appropriate array of objects.
        public void InitializeStores()
        {
            int storeIndex = 0;

            PermanentStore store1 = new PermanentStore("Coles Supermarket", "Supermarket", true);
            StoreArray[storeIndex] = store1;
            storeIndex++;

            PermanentStore store2 = new PermanentStore("Rebel Sport", "Sportsgoods", true);
            StoreArray[storeIndex] = store2;
            storeIndex++;

            NonPermanentStore store3 = new NonPermanentStore("Custom Candy", "Food", false);
            StoreArray[storeIndex] = store3;
            storeIndex++;

            NonPermanentStore store4 = new NonPermanentStore("Byron Bay Beef Jerky", "Food", false);
            StoreArray[storeIndex] = store4;
            storeIndex++;

        }

        //Prints a welcome message, name of mall and a list of all stores held in array.
        public void Print()
        {

            Console.WriteLine("Welcome to Harry's Mall Manager!");
            Console.WriteLine();
            Console.WriteLine("Viewing: " + this.Name);
            Console.WriteLine();

            foreach (IStore element in StoreArray)
            {
                Console.Write(element.ShowName() + ", " + element.Category() + ", " + element.OccupiedStatus() +
                    ", " + element.ShowStoreType());
                Console.WriteLine();
            }

        }

        public bool Check(IStore store, string category)
        {

            if (store.Category() == category)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //runs the check method on a user-defined value.
        //Prints the names of the stores in given category, or reports no stores found.
        public void RunCheck(string category)
        {
            int i = 0;

            foreach (IStore store in StoreArray)
            {
                if (Check(store, category))
                {
                    Console.WriteLine();
                    Console.WriteLine(store.ShowName());
                    i++;
                }

            }

            if (i == 0)
            {
                Console.WriteLine("No " + category + " stores are currently in this mall.");
            }

        }

        //Prints the prompt for user to enter query value for category, then runs the RunCheck method.
        public void PromptCheckInput()
        {

            Console.WriteLine("To check for a specific type of store, type the category below and hit 'Enter':");
            RunCheck(Console.ReadLine());

        }
    }
}
