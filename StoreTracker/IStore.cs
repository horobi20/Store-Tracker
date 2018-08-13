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
    //Interface for common methods between stores.
    public interface IStore
    {

        bool IsOccupied(); //return true/false if the store is occupied or not
        string Category(); //return category name of the store
        string ShowName(); // return name for printing
        string OccupiedStatus(); // return stores occupied status as a string for printing
        string ShowStoreType(); //return store type as a string for printing

    }
}
