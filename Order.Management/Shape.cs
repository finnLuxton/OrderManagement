using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class Shape
    {
        public string Name { get; set; }
        public int Price { get; set; } // This should be a decimal for currency values.
        public int AdditionalCharge { get; set; }
        public int NumberOfRedShape { get; set; } // These are hard coded values for shapes. We should rewrite this class to support multiple colours.
        public int NumberOfBlueShape { get; set; }
        public int NumberOfYellowShape { get; set; } 
        public int TotalQuantityOfShape() // This function should iterate through the entire instance, instead of hard coded colours.
        {
            return NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;
        }

        public int AdditionalChargeTotal() // Remove colour based hardcoding. Refactor by iterating through all cases of AdditionalCharge not being the default value.
        {
            return NumberOfRedShape * AdditionalCharge;
        }
        public abstract int Total();

    }
}
