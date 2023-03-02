using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Square : Shape
    {
        // Please refer to Circle comments.

        public int SquarePrice = 1;

        public Square(int numberOfRedSquares, int numberOfBlueSquares, int numberOfYellowSquares)
        {
            Name = "Square";
            base.Price = SquarePrice;
            AdditionalCharge = 1;
            base.NumberOfRedShape = numberOfRedSquares;
            base.NumberOfBlueShape = numberOfBlueSquares;
            base.NumberOfYellowShape = numberOfYellowSquares;
        }

        public override decimal Total()
        {
            return RedSquaresTotal() + BlueSquaresTotal() + YellowSquaresTotal();
        }

        public decimal RedSquaresTotal()
        {
            return (base.NumberOfRedShape * Price);
        }
        public decimal BlueSquaresTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        public decimal YellowSquaresTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }
    }
} 
