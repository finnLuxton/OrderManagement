using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    public class Triangle : Shape
    {
        // Please refer to Circle comments.
        public int TrianglePrice = 2;
        public Triangle(int numberOfRedTriangles, int numberOfBlueTriangles, int numberOfYellowTriangles)
        {
            Name = "Triangle";
            base.Price = TrianglePrice;
            AdditionalCharge = 1;
            base.NumberOfRedShape = numberOfRedTriangles;
            base.NumberOfBlueShape = numberOfBlueTriangles;
            base.NumberOfYellowShape = numberOfYellowTriangles;
        }

        public override decimal Total()
        {
            return RedTrianglesTotal() + BlueTrianglesTotal() + YellowTrianglesTotal();
        }

        public decimal RedTrianglesTotal()
        {
            return (base.NumberOfRedShape * Price);
        }
        public decimal BlueTrianglesTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        public decimal YellowTrianglesTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }
    
}
}
