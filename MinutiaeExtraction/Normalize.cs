﻿using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutiaeExtraction
{
    public static class Normalization
    {
        public static Image<Gray, byte> AHE(Emgu.CV.Image<Gray, byte> image)
        {
            Accord.Imaging.Filters.HistogramEqualization histogramEqualization = new Accord.Imaging.Filters.HistogramEqualization();
            Accord.Imaging.Filters.AdaptiveSmoothing adaptiveSmoothing = new Accord.Imaging.Filters.AdaptiveSmoothing();
            Bitmap equalizedImage = adaptiveSmoothing.Apply(image.ToBitmap());
            Image<Gray, Byte> finalEqualizedImage = new Image<Gray, Byte>(equalizedImage);

            return finalEqualizedImage;
        }

        public static Image<Gray, byte> Otsu(Image<Gray, byte> image)
        {
            Image<Gray, byte> outputImage = new Image<Gray, byte>(image.Width, image.Height, new Gray(0));
            double threshold = CvInvoke.Threshold(image, outputImage, 500, 255, Emgu.CV.CvEnum.ThresholdType.Otsu);

            return outputImage;
        }

        public static Image<Gray, byte> ManualThreshold(int threshold, Image<Gray, byte> image)
        {
            Image<Gray, byte> newImage = image;
            int w = image.Width;
            int h = image.Height;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    Gray a = newImage[i, j];
                    double intensity = a.Intensity;
                    if (intensity > threshold)
                    {
                        Gray n = new Gray(255);
                        newImage[i, j] = n;
                    }
                    else
                    {
                        Gray n = new Gray(0);
                        newImage[i, j] = n;
                    }
                }
            }

            return newImage;
        }
    }
}