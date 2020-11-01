using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length,double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
             get
            {
                return this.length;
            }


           private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }


            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }


            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            double surfaceArea=0;
            surfaceArea = 2 * this.height * this.length + 2 * this.length * this.width + 2 * this.height * this.width;
            return surfaceArea;
       

        }
        public double CalculateLateralSurfaceArea()
        {
            double lateralSurfaceArea = 0;
            lateralSurfaceArea = 2 * this.height *( this.length + this.width);
            return lateralSurfaceArea;


        }

        public double CalculateVolume()
        {
            double Volume = 0;
            Volume =  this.height * this.length * this.width;
            return Volume;


        }
    }
}
