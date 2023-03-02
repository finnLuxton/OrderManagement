using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    // Please check Painting Report for more comments on this report as a whole.

    class CuttingListReport : Report
    {
        public CuttingListReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            base.CustomerName = customerName;
            base.Address = customerAddress;
            base.DueDate = dueDate;
            base.OrderedBlocks = shapes;
            tableWidth = 20;
        }

        public void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(base.ToString()); //
                                                // we update the class to inherit report, ensure that a relevant ToString method is called.
            generateTable();
        }

        /* Similar to my comment for the OrderShapeDetail functions below, these are all hardcoded to accept only the current list of strings and objects. 
         * These should instead iterate through the OrderedBlocks list and its flagged attributes to ensure that it prints all appropriate values, regardless of what else is added in the future.
         */
        public void generateTable()
        {
            var printLine = PrintLine(tableWidth);
            Console.WriteLine(printLine);
            PrintRow("        ", "   Qty   ");
            Console.WriteLine(printLine);
            PrintRow("Square",base.OrderedBlocks[0].TotalQuantityOfShape().ToString());
            PrintRow("Triangle", base.OrderedBlocks[1].TotalQuantityOfShape().ToString());
            PrintRow("Circle", base.OrderedBlocks[2].TotalQuantityOfShape().ToString());
            Console.WriteLine(printLine);
        }

    }
}
