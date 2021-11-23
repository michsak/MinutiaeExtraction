using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutiaeExtraction
{
    public static class CrossingNumberAlgorithm
    {
        private static int maxX = 0;
        private static int minX = 320;
        private static int maxY = 0;
        private static int minY = 480;
        private static int boundary = 25;  //30 is optimal maximum

        //x-from left
        //y-from up

        public static Dictionary<MinutiaeType, IList<MCvPoint2D64f>> Perform(Image<Gray, Byte> img)
        {
            var matrix = ConvertImageMatrix.GrayImageToMatrix(img);

            var singlePointList = new List<MCvPoint2D64f>();
            var forkList = new List<MCvPoint2D64f>();
            var edgeEndList = new List<MCvPoint2D64f>();
            var crossingList = new List<MCvPoint2D64f>();

            int targetHeight = matrix.GetLength(0) - 1;  //HEIGHT
            int targetWidth = matrix.GetLength(1) - 1;  //WIDTH

            for (int y = 1; y < targetHeight; y++)
            {
                for (int x = 1; x < targetWidth; x++)
                {
                    if (matrix[y, x] == 0)
                        continue;

                    switch ((MinutiaeType)CheckPixel(ref matrix, x, y))
                    {
                        case MinutiaeType.SINGLE_POINT:
                            singlePointList.Add(new MCvPoint2D64f(x, y));
                            break;

                        case MinutiaeType.EDGE_END:
                            edgeEndList.Add(new MCvPoint2D64f(x, y));
                            break;

                        case MinutiaeType.BIFURCATION:
                            forkList.Add(new MCvPoint2D64f(x, y));
                            break;

                        case MinutiaeType.CROSSING:
                            crossingList.Add(new MCvPoint2D64f(x, y));
                            break;
                    }
                }
            }

            List<MCvPoint2D64f> updatedEdgeList = RemoveAllWrongMinutiae(matrix, edgeEndList, 12);
            List<MCvPoint2D64f> updatedSinglePointList = RemoveAllWrongMinutiae(matrix, singlePointList, 20);
            //List<MCvPoint2D64f> updatedForkList = RemoveAllWrongMinutiae(matrix, forkList, 20);
            //List<MCvPoint2D64f> updatedCrossingList = RemoveAllWrongMinutiae(matrix, crossingList, 20);

            var result = new Dictionary<MinutiaeType, IList<MCvPoint2D64f>>
            {
                { MinutiaeType.SINGLE_POINT, updatedSinglePointList },
                { MinutiaeType.EDGE_END, updatedEdgeList },
                { MinutiaeType.BIFURCATION, forkList },
                { MinutiaeType.CROSSING, crossingList }
            };

            using (StreamWriter sw = new StreamWriter(string.Format(@"..\..\..\ExtractedParams\{0}.txt",
                       DateTime.Now.ToString()).Trim(' ').Replace("-", "").Replace(":", "")))
            {
                foreach (var minutiae in result)
                {
                    foreach (var cord in minutiae.Value)
                    {
                        sw.WriteLine("Type: " + minutiae.Key.ToString() + " X: " + cord.X + " Y: " + cord.Y);
                    }
                }
            }

            return result;
        }

        private static List<MCvPoint2D64f> RemoveAllWrongMinutiae(int[,] matrix, List<MCvPoint2D64f> edgeEndList, int height)
        {
            List<MCvPoint2D64f> updatedEdgeList = edgeEndList.GetRange(0, edgeEndList.Count);

            foreach (var edge in edgeEndList)
            {
                int colorSum = 1;

                if (edge.X > maxX - boundary)
                {
                    colorSum = 0;
                    goto Check;
                }
                else if (edge.X < minX + boundary)
                {
                    colorSum = 0;
                    goto Check;
                }
                if (edge.Y > maxY - boundary)
                {
                    colorSum = 0;
                    goto Check;
                }
                else if (edge.Y < minY + boundary)
                {
                    colorSum = 0;
                    goto Check;
                }

                if (!(edge.X > 80 && edge.X < 240 && edge.Y > 90 && edge.Y < 390))
                {
                    colorSum = RemoveWrongMinutiaeOnCurve(matrix, edge, colorSum, height);
                }

            Check:
                if (colorSum <= 0)
                {
                    updatedEdgeList.Remove(edge);
                }
            }

            return updatedEdgeList;
        }

        private static int RemoveWrongMinutiaeOnCurve(int[,] matrix, MCvPoint2D64f edge, int colorSum, int height)
        {
            if (edge.Y <= 160)
            {
                for (int j = 1; j <= height; j++)
                {
                    int matrixSum = 0;
                    try
                    {
                        matrixSum += matrix[Convert.ToInt16(edge.Y - j), Convert.ToInt16(edge.X)];
                        if (matrixSum == 0)
                        {
                            colorSum = 0;
                            continue;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        colorSum = 0;
                        continue;
                    }
                }
            }

            else if (edge.Y >= 320)
            {
                int matrixSum = 0;
                for (int j = 1; j <= height; j++)
                {
                    try
                    {
                        matrixSum += matrix[Convert.ToInt16(edge.Y + j), Convert.ToInt16(edge.X)];

                        if (matrixSum == 0)
                        {
                            colorSum = 0;
                            continue;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        colorSum = 0;
                        continue;
                    }
                }
            }

            return colorSum;
        }

        private static int CheckPixel(ref int[,] matrix, int x, int y)
        {
            var P = new int[9];
            P[0] = P[8] = matrix[y - 1, x - 1];
            P[1] = matrix[y - 1, x];
            P[2] = matrix[y - 1, x + 1];
            P[3] = matrix[y, x + 1];
            P[4] = matrix[y + 1, x + 1];
            P[5] = matrix[y + 1, x];
            P[6] = matrix[y + 1, x - 1];
            P[7] = matrix[y, x - 1];

            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                sum += Math.Abs(P[i] - P[i + 1]);
            }

            int result = (int)(0.5 * sum);

            SettleMaxMin(x, y, result);

            return result;
        }

        private static void SettleMaxMin(int x, int y, int result)
        {
            if (result > 0)
            {
                if (x > maxX)
                {
                    maxX = x;
                }
                if (x < minX)
                {
                    minX = x;
                }
                if (y > maxY)
                {
                    maxY = y;
                }
                if (y < minY)
                {
                    minY = y;
                }
            }
        }
    }
}
