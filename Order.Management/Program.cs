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
            int redCircle = GetUserInput<int>("Please input the number of Red Circles");
            int blueCircle = GetUserInput<int>("Please input the number of Blue Circles");
            int yellowCircle = GetUserInput<int>("Please input the number of Yellow Circles");

            Circle circle = new Circle(redCircle, blueCircle, yellowCircle);
            return circle;
        }
        
        // Order Squares Input
        public static Square OrderSquaresInput()
        {
            int redSquare = GetUserInput<int>("Please input the number of Red Squares");
            int blueSquare = GetUserInput<int>("Please input the number of Blue Squares");
            int yellowSquare = GetUserInput<int>("Please input the number of Yellow Squares");

            Square square = new Square(redSquare, blueSquare, yellowSquare);
            return square;
        }

        // Order Triangles Input
        public static Triangle OrderTrianglesInput()
        {
            int redTriangle = GetUserInput<int>("Please input the number of Red Triangles");
            int blueTriangle = GetUserInput<int>("Please input the number of Blue Triangles");
            int yellowTriangle = GetUserInput<int>("Please input the number of Yellow Triangles");

            Triangle triangle = new Triangle(redTriangle, blueTriangle, yellowTriangle);
            return triangle;
        }

        // User Console Input
        public static T GetUserInput<T>(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + ": ");
                string input = Console.ReadLine();
                try
                {
                    // Convert input to the requested data type
                    return (T)Convert.ChangeType(input, typeof(T));
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }
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
            string customerName = GetUserInput<string>("Please input your Name");
            string address = GetUserInput<string>("Please input your Address");
            string dueDate = GetUserInput<string>("Please input your Due Date");
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
