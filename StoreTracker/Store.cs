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
    //abstract class that provides common properties between store types
    abstract class Store
    {
       
        public bool Occupied { get; set; }
        public string Name { get; set; }

    }
}
