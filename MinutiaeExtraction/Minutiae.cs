using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutiaeExtraction
{
    public static class Minutiae
    {
        public static Image<Bgr, Byte> detectingMinutiae(Image<Gray, Byte> img)
        {
            Image<Bgr, Byte> newImg = img.Convert<Bgr, Byte>();

            var points = CrossingNumberAlgorithm.Perform(img);

            var singlePoint = points[MinutiaeType.SINGLE_POINT];
            var edgeEnd = points[MinutiaeType.EDGE_END];
            var fork = points[MinutiaeType.BIFURCATION];
            var crossing = points[MinutiaeType.CROSSING];

            var color = new MCvScalar(255, 9, 9);
            DrawCircleForMinutiae(newImg, edgeEnd, new MCvScalar(255, 9, 9)); // end - blue
            DrawCircleForMinutiae(newImg, fork, new MCvScalar(0, 0, 255)); // bifurcation - red
            DrawCircleForMinutiae(newImg, crossing, new MCvScalar(0, 255, 0)); // crossing - green
            DrawCircleForMinutiae(newImg, singlePoint, new MCvScalar(255, 102, 255)); // single point - pink

            return newImg;
        }

        private static void DrawCircleForMinutiae(Image<Bgr, byte> newImg, IList<MCvPoint2D64f> fork, MCvScalar color)
        {
            int x, y;
            foreach (MCvPoint2D64f element in fork)
            {
                x = Convert.ToInt16(element.X);
                y = Convert.ToInt16(element.Y);
                CvInvoke.Circle(newImg, new System.Drawing.Point(x, y), 3, color);
            }
        }
    }
}
