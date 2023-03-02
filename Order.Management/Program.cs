using System;
using System.Collections.Generic;

namespace Order.Management
{
    class Program
    {
        // Main entry
        static void Main(string[] args)
        {

            // We could import a json or header file here for the different colours, shapes and their prices here.

            var (customerName, address, dueDate) = CustomerInfoInput(); // We should have a data structure for the returned parameters here. What if customer wants additional info, should support more parameters

            var orderedShapes = CustomerOrderInput();

            GenerateReports(customerName, address, dueDate, orderedShapes);
            
            // Wait for user to press a key before finishing.
            Console.ReadKey();
        }

        // The below 3 functions can all be refactored into a single function that takes in a parameter of item type. It could also take in a list of both shapes and colours to create the appropriate output. 
        // This would ensure scalability into the future. The return types would need to differ based on function, or instead it can return a list of List<shape> objects.
        // TODO Finn make function here
        
        //public static Shape OrderInput(string shapeType, string shapeColour)
        //{
        //    // This function here should care about the automatically generated list of shape/colours from Json, and ask for an input for each individual combination.
        //    // So, before writing this, ensure the json entry is fixed.
        //    //Console.Write("\nPlease input the number of ")
        //}

        // Order Circle Input
        public static Circle OrderCirclesInput()
        {
            Console.Write("\nPlease input the number of Red Circle: ");
            int redCircle = Convert.ToInt32(userInput());
            Console.Write("Please input the number of Blue Circle: ");
            int blueCircle = Convert.ToInt32(userInput());
            Console.Write("Please input the number of Yellow Circle: ");
            int yellowCircle = Convert.ToInt32(userInput());

            Circle circle = new Circle(redCircle, blueCircle, yellowCircle);
            return circle;
        }
        
        // Order Squares Input
        public static Square OrderSquaresInput()
        {
            Console.Write("\nPlease input the number of Red Squares: ");
            int redSquare = Convert.ToInt32(userInput());
            Console.Write("Please input the number of Blue Squares: ");
            int blueSquare = Convert.ToInt32(userInput());
            Console.Write("Please input the number of Yellow Squares: ");
            int yellowSquare = Convert.ToInt32(userInput());

            Square square = new Square(redSquare, blueSquare, yellowSquare);
            return square;
        }

        // Order Triangles Input
        public static Triangle OrderTrianglesInput()
        {
            Console.Write("\nPlease input the number of Red Triangles: ");
            int redTriangle = Convert.ToInt32(userInput());
            Console.Write("Please input the number of Blue Triangles: ");
            int blueTriangle = Convert.ToInt32(userInput());
            Console.Write("Please input the number of Yellow Triangles: ");
            int yellowTriangle = Convert.ToInt32(userInput());

            Triangle triangle = new Triangle(redTriangle, blueTriangle, yellowTriangle);
            return triangle;
        }

        // User Console Input
        public static string userInput() // This functions converts dates into strings, which can cause issues later if we need to interpert a DateTime variable.
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details"); // There is no error catching, handling or logging here apart from empty line.
                input = Console.ReadLine();

            }
            return input;
        }

        private static void GenerateReports(string customerName, string address, string dueDate, List<Shape> orderedShapes)
        {
            PaintingReport paintingReport = new PaintingReport(customerName, address, dueDate, orderedShapes);
            CuttingListReport cuttingListReport = new CuttingListReport(customerName, address, dueDate, orderedShapes);
            InvoiceReport invoiceReport = new InvoiceReport(customerName, address, dueDate, orderedShapes);

            invoiceReport.GenerateReport();
            cuttingListReport.GenerateReport();
            paintingReport.GenerateReport();
        }

        // Get customer Info
        private static (string customerName, string address, string dueDate) CustomerInfoInput()
        {
            Console.Write("Please input your Name: ");
            string customerName = userInput();
            Console.Write("Please input your Address: ");
            string address = userInput();
            Console.Write("Please input your Due Date: ");
            string dueDate = userInput();
            return (customerName, address, dueDate);
        }

        // Get order input
        private static List<Shape> CustomerOrderInput()
        {
            Square square = OrderSquaresInput();
            Triangle triangle = OrderTrianglesInput();
            Circle circle = OrderCirclesInput();

            // If you have the OrderInput functions above return List<Shape>, you could append the output to this List, making the next 3 lines redundant.
            var orderedShapes = new List<Shape>(); 
            orderedShapes.Add(square);
            orderedShapes.Add(triangle);
            orderedShapes.Add(circle);
            return orderedShapes;
        }
    }
}
