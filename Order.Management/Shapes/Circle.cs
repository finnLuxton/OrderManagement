using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{

    /* * I will collate all shape based comments here, since they are all nearly identical.
       * Base is not required, instead references inside the Circle class outside of the constructor should reference this. instance instead.
       * All three shape functions share the nearly exact same functions. This is not ideal for readability, but also we should ensure single responsibility for a function
         such as counting the total number of shapes, and the total number of individual colours. If we were to make a change to one function, we would also need to change all other
         existing functions.
       * The colour names and shape names are hard coded. If we were to add green one day, we would have to write a brand new function, and if we were to create a Star shape, we would need
         a brand new class. We should ensure the functions are not dependent on hard-coded values, and are open to any number of scalable items.
    */

    class Circle : Shape
    {
        public int circlePrice = 3;
        public Circle(int red, int blue, int yellow)
        {
            Name = "Circle";
            base.Price = circlePrice;
            AdditionalCharge = 1;
            base.NumberOfRedShape = red;
            base.NumberOfBlueShape = blue;
            base.NumberOfYellowShape = yellow;
        }
        public override int Total() // These three functions that all perform nearly the same task, so they should be condensed. They are also hard coded colour values, we should clear the dependencies here.
        {
            return RedCirclesTotal() + BlueCirclesTotal() + YellowCirclesTotal();
        }

        // The below three functions should be condensed into one 
        public int RedCirclesTotal()
        {
            return (base.NumberOfRedShape * Price);
        }
        public int BlueCirclesTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        public int YellowCirclesTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }
    }
}
