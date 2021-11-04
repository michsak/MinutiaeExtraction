using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinutiaeExtraction
{
    public static class ConvertImageMatrix
    {
        public static Image<Gray, Byte> MatrixToGrayImage(int[,] matrix)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            Image<Gray, Byte> resultImage = new Image<Gray, Byte>(width, height);

            Gray g = new Gray();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (matrix[y, x] != 1)
                    {
                        g.Intensity = 255;
                        resultImage[y, x] = g;
                        continue;
                    }
                    else
                    {
                        g.Intensity = 0;
                        resultImage[y, x] = g;
                    }
                }
            }
            return resultImage;
        }

        public static int[,] GrayImageToMatrix(Image<Gray, Byte> img)
        {
            int[,] resultMatrix = new int[img.Height, img.Width];
            Gray pixel;

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    pixel = img[y, x];
                    if (pixel.Intensity == 255) // bialy piksel
                        resultMatrix[y, x] = 0;
                    else // czarny piksel
                        resultMatrix[y, x] = 1;
                }
            }
            return resultMatrix;
        }
    }
}
