using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    // Please check Painting Report for more comments on this report as a whole.

    class InvoiceReport : Report // After creating a report class, this should inherit from Report instead.
    {
        public InvoiceReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            // Base namespace not required, as Order has no declarations for any of these values. Can leave as they are.
            base.CustomerName = customerName;
            base.Address = customerAddress;
            base.DueDate = dueDate; // Should we store the date values as a DateTime object, incase future code requires date manipulation
            base.OrderedBlocks = shapes;
            tableWidth = 73;
        }

        public void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(base.ToString());
            GenerateTable();
            OrderSquareDetails();   // These three detail rows should be collated into one for scalability. More on that at function declaration.
            OrderTriangleDetails();
            OrderCircleDetails();
            RedPaintSurcharge();
        }

        // We should replace this red paint surchage function with a generic surcharge function. What if prices change in the future for better or worse for multiple products?
        // The Shape class already has an attribute of AdditionalCharge, so just base the function over which has a value that is not the default of $0.
        // Base is not required, should be changed to this for the current instance.
        public void RedPaintSurcharge()
        {
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + base.OrderedBlocks[0].AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        // Base is not required, should be changed to this for the current instance.
        public int TotalAmountOfRedShapes()
        {
            return base.OrderedBlocks[0].NumberOfRedShape + base.OrderedBlocks[1].NumberOfRedShape +
                   base.OrderedBlocks[2].NumberOfRedShape;
        }

        // Base is not required, should be changed to this for the current instance.
        public int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * base.OrderedBlocks[0].AdditionalCharge;
        }
        public void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow "); // This does not support any future colours. This line should be printing all colours generated in the OrderedBlocks list.
            PrintLine();
            /* Similar to my comment for the OrderShapeDetail functions below, these are all hardcoded to accept only the current list of strings and objects. 
             * These should instead iterate through the OrderedBlocks list and its flagged attributes to ensure that it prints all appropriate values, regardless of what else is added in the future.
             */
            PrintRow("Square", OrderedBlocks[0].NumberOfRedShape.ToString(), OrderedBlocks[0].NumberOfBlueShape.ToString(), OrderedBlocks[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", OrderedBlocks[1].NumberOfRedShape.ToString(), OrderedBlocks[1].NumberOfBlueShape.ToString(), OrderedBlocks[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", OrderedBlocks[2].NumberOfRedShape.ToString(), OrderedBlocks[2].NumberOfBlueShape.ToString(), OrderedBlocks[2].NumberOfYellowShape.ToString());
            PrintLine();
        }

        /* These three functions all share the following issues. 
         *  1) They are all named after their shapes, but the code does not reference this, only by list location. This can cause errors if the ordering of shapes is changed in the code in later stages.
         *  2) They are strict on their shapes. If new shapes are added in the future, the code will not support this. 
         *  3) If new attributes are added to the shapes, they will also not show as intended. The attributes could have denoted flags based on which report they should appear on
         *  4) It is limited to only dollar values. Future currencys may be implemented for the business.
         *  5) All 3 functions share the exact same purpose. All 3 could be refactored into a single function.
         *  6) Base is not required, should be changed to this for the current instance.
         */
        public void OrderSquareDetails()
        {
            Console.WriteLine("\nSquares 		  " + base.OrderedBlocks[0].TotalQuantityOfShape() + " @ $" + base.OrderedBlocks[0].Price + " ppi = $" + base.OrderedBlocks[0].Total());
        }
        public void OrderTriangleDetails()
        {
            Console.WriteLine("Triangles 		  " + base.OrderedBlocks[1].TotalQuantityOfShape() + " @ $" + base.OrderedBlocks[1].Price + " ppi = $" + base.OrderedBlocks[1].Total());
        }
        public void OrderCircleDetails()
        {
            Console.WriteLine("Circles 		  " + base.OrderedBlocks[2].TotalQuantityOfShape() + " @ $" + base.OrderedBlocks[2].Price + " ppi = $" + base.OrderedBlocks[2].Total());
        }

    }
}
