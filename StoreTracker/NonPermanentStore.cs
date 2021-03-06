﻿using System;
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
    class NonPermanentStore : Store, IStore
    {
        public int storetype = 2;
        string category;


        //default
        public NonPermanentStore()
        {

        }

        //full Property initialisation constructor.
        public NonPermanentStore(string n, string c, bool o)
        {

            Name = n;
            category = c;
            Occupied = o;

        }

        public bool IsOccupied()
        {

            return Occupied;

        }

        public string OccupiedStatus()
        {

            switch (IsOccupied())
            {
                case true:
                    return "Occupied";

                default:
                    return "Vacant";
                    
            }

        }

        public string Category()
        {
            return category;
        }

        public string ShowStoreType()
        {

            switch (storetype)
            {
                case 1:
                    return "Permanent";

                default:
                    return "Non - Permanent";

            }
        }

        public string ShowName()
        {

            return Name;

        }
    }
}
