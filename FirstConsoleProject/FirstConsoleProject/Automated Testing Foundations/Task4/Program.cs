﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Create a "Coordinate" structure that defines the 3D coordinates of some object (positive numbers).
//Define an IFlyable interface with the FlyTo (new point), GetFlyTime (new point) methods.
//Create classes "Bird", "Airplane", "Drone", which implement this interface and contain at least the field "Current position".

//Use the following assumptions: the bird flies the entire distance at a constant speed in the range of 0-20 km/h (set randomly),
//the aircraft increases speed by 10 km/h every 10 km of flight from an initial speed of 200 km/h,
//the drone hovers in the air every 10 minutes of flight for 1 minute. Based on the task,
//introduce additional restrictions (for example, the impossibility of flying a drone at a distance of more than 1000 km).
//Describe the methods and restrictions imposed in the comments.

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Drone drone = new Drone(10, "stay");
            //drone.MyProperty = 102;
            //drone.MySecondProperty = 99;
        }
    }
}
