using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinutiaeExtraction
{
    class Minutiae
    {
        public static Image<Bgr, Byte> detectingMinutiae(Image<Gray, Byte> img)
        {
            Image<Bgr, Byte> newImg = img.Convert<Bgr, Byte>();

            var points = CrossingNumberAlgorithm.Perform(img);

            var singlePoint = points[MinutiaeType.SINGLE_POINT];
            var edgeEnd = points[MinutiaeType.EDGE_END];
            var fork = points[MinutiaeType.FORK];
            var crossing = points[MinutiaeType.CROSSING];

            foreach (var point in points)
            {
                foreach (var value in point.Value)
                {
                    Console.WriteLine("Type: " + point.Key.ToString() + " X: " + value.X + " Y: " + value.Y);
                }
            }
            return newImg;
        }
    }
}
