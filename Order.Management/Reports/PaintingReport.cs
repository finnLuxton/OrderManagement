using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    /* The Painting Report, Cutting Report and Invoice Report share the same issue as the 3 shapes,
       where all 3 are very similar to eachother, and should be condensed to a single Report class.
     * References to Base are not required, as the inherited Order class doesn't have any required references. All references to base within this class outside of the 
       constructor can be replaced with this. to deal with the required instances. 
     */

    class PaintingReport : Report // After creating a report class, this should inherit from Report instead.
    {

        // Base is not required, should be changed to this for the current instance.
        public PaintingReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            base.CustomerName = customerName;
            base.Address = customerAddress;
            base.DueDate = dueDate;
            base.OrderedBlocks = shapes;
            tableWidth = 73;
        }

        // Base is not required, should be changed to this for the current instance.
        public void GenerateReport()
        {
            Console.WriteLine("\nYour painting report has been generated: ");
            Console.WriteLine(base.ToString());
            generateTable();
        }

        // Base is not required, should be changed to this for the current instance.
        // Inconsistent naming convention. Should be changed to GenerateTable.
        public void generateTable() 
        {
            var printLine = PrintLine(tableWidth);
            Console.WriteLine(printLine);
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            Console.WriteLine(printLine);
            PrintRow("Square", base.OrderedBlocks[0].NumberOfRedShape.ToString(), OrderedBlocks[0].NumberOfBlueShape.ToString(), OrderedBlocks[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", base.OrderedBlocks[1].NumberOfRedShape.ToString(), OrderedBlocks[1].NumberOfBlueShape.ToString(), OrderedBlocks[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", base.OrderedBlocks[2].NumberOfRedShape.ToString(), OrderedBlocks[2].NumberOfBlueShape.ToString(), OrderedBlocks[2].NumberOfYellowShape.ToString());
            Console.WriteLine(printLine);
        }
       
    }
}
