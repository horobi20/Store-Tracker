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
    class Program
    {

        static void Main(string[] args)
        {

            Mall mall = new Mall("Small Town Shopping Mall");

            Console.SetWindowSize(120, 36);

            mall.InitializeStores();
            mall.Print();
            Console.WriteLine();
            mall.PromptCheckInput();
            Console.ReadLine();

        }
    }
}
