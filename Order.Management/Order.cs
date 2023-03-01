using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class Order
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string DueDate { get; set; } // Could be stored as a DateTime value, incase date manipulation is expected later.
        public int OrderNumber { get; set; } // Order Number is never set. It should be a unique identifier, ideally sequentially. If there was a database connection, that could be used.
        public List<Shape> OrderedBlocks { get; set; }

        //public abstract void GenerateReport();

        /* This function needs to be overidden, as object.ToString is already inherited.
           This also is hard coded, and does not take into account any future attributes that may be added.
         * Realistically, its bad naming convention to name a function like this. It would hurt readability for code down the line.         
         */
        public override string ToString() 
        {
            return "\nName: " + CustomerName + " Address: " + Address + " Due Date: " + DueDate + " Order #: " + OrderNumber; //OrderNumber is not set.
        }
    }
}
