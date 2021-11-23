using Accord.Imaging.Filters;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutiaeExtraction
{
    public static class GaborFilter
    {
        private static int counter = 0;
        private static int finalImageWidth = 320;
        private static int finalImageHeight = 480;


        public static Image<Gray, Byte> PerformFiltering(Image<Gray, Byte> oldImg)
        {
            int width = oldImg.Width;
            int height = oldImg.Height;
            int ROI = 80;

            List<Image> imgarray = new List<Image>();
            List<Bitmap> imgArrayBitmap = new List<Bitmap>();
            GaborFilter.counter = 0;
            Image newImage = (Image)oldImg.ToBitmap();

            for (int i = 0; i < width / ROI; i++)
            {
                for (int j = 0; j < height / ROI; j++)
                {
                    Console.WriteLine("Cords = I: " + i + " J: " + j);

                    if (i == 0 && j > 0 && j < height / ROI - 1)
                    {
                        imgarray.Add(cropImage(newImage, new Rectangle(i * ROI, j * ROI - ROI / 2, ROI + ROI / 2, ROI + ROI)));
                    }
                    else if (i > 0 && i < width / ROI - 1 && j > 0 && j < height / ROI - 1)
                    {
                        imgarray.Add(cropImage(newImage, new Rectangle(i * ROI - ROI / 2, j * ROI - ROI / 2, ROI + ROI, ROI + ROI)));
                    }
                    else if (i == (width / ROI) - 1 && j > 0 && j < height / ROI - 1)
                    {
                        imgarray.Add(cropImage(newImage, new Rectangle(i * ROI - ROI / 2, j * ROI - ROI / 2, ROI + ROI / 2, ROI + ROI)));
                    }
                    else if (i == 0 && j == 0)
                    {
                        imgarray.Add(cropImage(newImage, new Rectangle(i * ROI, j * ROI, ROI + ROI / 2, ROI + ROI / 2)));
                    }
                    else if (i < width / ROI - 1 && i > 0 && j == 0)
                    {
                        imgarray.Add(cropImage(newImage, new Rectangle(i * ROI - ROI / 2, j * ROI, ROI + ROI, ROI + ROI / 2)));
                    }
                    else if (i == width / ROI - 1 && j == 0)
                    {
                        imgarray.Add(cropImage(newImage, new Rectangle(i * ROI - ROI / 2, j * ROI, ROI + ROI / 2, ROI + ROI / 2)));
                    }
                    else if (i == 0 && j == height / ROI - 1)
                    {
                        imgarray.Add(cropImage(newImage, new Rectangle(i * ROI, j * ROI - ROI / 2, ROI + ROI / 2, ROI + ROI / 2)));
                    }
                    else if (i < width / ROI - 1 && i > 0 && j == height / ROI - 1)
                    {
                        imgarray.Add(cropImage(newImage, new Rectangle(i * ROI - ROI / 2, j * ROI - ROI / 2, ROI + ROI, ROI + ROI / 2)));
                    }
                    else if (i == width / ROI - 1 && j == height / ROI - 1)
                    {
                        imgarray.Add(cropImage(newImage, new Rectangle(i * ROI - ROI / 2, j * ROI - ROI / 2, ROI + ROI / 2, ROI + ROI / 2)));
                    }
                    else
                    {
                        imgarray.Add(cropImage(newImage, new Rectangle(i * ROI, j * ROI, ROI, ROI)));
                    }

                    Accord.Imaging.Filters.GaborFilter gaborFilter = new Accord.Imaging.Filters.GaborFilter();

                    Bitmap currentImage = new Bitmap(imgarray[GaborFilter.counter]);

                    Bitmap newBitmap = Grayscale.CommonAlgorithms.BT709.Apply(currentImage);
                    Accord.Imaging.Image.SetGrayscalePalette(newBitmap);
                    gaborFilter.Sigma = 2;
                    gaborFilter.Size = 1;
                    gaborFilter.Lambda = Math.PI / 4;
                    gaborFilter.Psi = 0.5;

                    List<Bitmap> filteredBitmaps = new List<Bitmap>();

                    for (float k = 0.1f; k <= 3.14f; k = k + 0.08f)
                    {
                        gaborFilter.Theta = k;
                        filteredBitmaps.Add(gaborFilter.Apply(newBitmap));
                    }

                    double lastSTD = 0;
                    int index = 0;

                    for (int k = 0; k < filteredBitmaps.Count; k++)
                    {
                        double mean = Accord.Imaging.Tools.Mean(filteredBitmaps[k]);
                        double std = Accord.Imaging.Tools.StandardDeviation(filteredBitmaps[k], mean);
                        if (std > lastSTD)
                        {
                            lastSTD = std;
                            index = k;
                        }
                    }

                    Image<Gray, Byte> oldImg1 = new Image<Gray, byte>(filteredBitmaps[index]);

                    filteredBitmaps.Clear();

                    Image croppedGaborFilteredImage = cropSmallerImage(oldImg1.ToBitmap(), i, j, ROI);

                    Image<Gray, Byte> oldImg2 = new Image<Gray, byte>(new Bitmap(croppedGaborFilteredImage));

                    Image<Gray, Byte> afterBinarization = Normalization.Otsu(oldImg2);

                    int value_counter = 0;
                    for (int l = 0; l < afterBinarization.Width; l++)
                    {
                        for (int m = 0; m < afterBinarization.Height; m++)
                        {
                            value_counter += (int)afterBinarization[l, m].Intensity;
                        }
                    }

                    if (value_counter < ROI*ROI*255/3)
                    {
                        int iterationCounter = 0;

                        while(value_counter < ROI*ROI*255/3 && iterationCounter < 4)
                        {
                            iterationCounter += 1;

                            if (Normalization.GetThreshold() - 30 <= 0 || iterationCounter == 4)
                            {
                                afterBinarization = new Image<Gray, Byte>(ROI, ROI, new Gray(255));
                                break;
                            }

                            afterBinarization = Normalization.ManualThreshold(Normalization.GetThreshold() - 30, oldImg2);

                            value_counter = 0;
                            for (int l = 0; l < afterBinarization.Width; l++)
                            {
                                for (int m = 0; m < afterBinarization.Height; m++)
                                {
                                    value_counter += (int)afterBinarization[l, m].Intensity;
                                }
                            }

                            Console.WriteLine("doing");
                        }
                    }

                    //}

                    imgArrayBitmap.Add(afterBinarization.ToBitmap());


                    GaborFilter.counter += 1;
                }
            }
            GaborFilter.counter = 0;
            Bitmap finalImage = Merge(imgArrayBitmap, ROI);
            Image<Gray, Byte> finalTypeImage = new Image<Gray, Byte>(finalImage);

            return finalTypeImage;
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap newBitmap = new Bitmap(img);
            Bitmap bmpImage = new Bitmap(img, new Size(img.Width, img.Height));
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);

            return (Image)(bmpCrop);
        }

        private static Image cropSmallerImage(Image img, int i, int j, int ROI)
        {
            Bitmap newBitmap = new Bitmap(img);
            Bitmap bmpImage = new Bitmap(img, new Size(img.Width, img.Height));
            Rectangle rectangle = new Rectangle(0, 0, ROI, ROI);

            if (i == 0 && j > 0 && j < finalImageHeight / ROI - 1)
            {
                rectangle = new Rectangle(i, ROI / 2, ROI, ROI);
            }
            else if (i > 0 && i < finalImageWidth / ROI - 1 && j > 0 && j < finalImageHeight / ROI - 1)
            {
                rectangle = new Rectangle(ROI / 2, ROI / 2, ROI, ROI);
            }
            else if (i == (finalImageWidth / ROI) - 1 && j > 0 && j < finalImageHeight / ROI - 1)
            {
                rectangle = new Rectangle(ROI / 2, ROI / 2, ROI, ROI);
            }
            else if (i < finalImageWidth / ROI - 1 && i > 0 && j == 0)
            {
                rectangle = new Rectangle(ROI / 2, 0, ROI, ROI);
            }
            else if (i == 0 && j == 0)
            {
                rectangle = new Rectangle(0, 0, ROI, ROI);
            }
            else if (i == finalImageWidth / ROI - 1 && j == 0)
            {
                rectangle = new Rectangle(ROI / 2, 0, ROI, ROI);
            }
            else if (i == 0 && j == finalImageHeight / ROI - 1)
            {
                rectangle = new Rectangle(0, ROI / 2, ROI, ROI);
            }
            else if (i < finalImageWidth / ROI - 1 && i > 0 && j == finalImageHeight / ROI - 1)
            {
                rectangle = new Rectangle(ROI / 2, ROI / 2, ROI, ROI);
            }
            else if (i == finalImageWidth / ROI - 1 && j == finalImageHeight / ROI - 1)
            {
                rectangle = new Rectangle(ROI / 2, ROI / 2, ROI, ROI);
            }

            Bitmap bmpCrop = bmpImage.Clone(rectangle, bmpImage.PixelFormat);

            return (Image)(bmpCrop);
        }

        private static Bitmap Merge(List<Bitmap> bitmaps, int NWW)
        {
            Bitmap fullBmp = new Bitmap(finalImageWidth, finalImageHeight);
            Graphics gr = Graphics.FromImage(fullBmp);

            for (int i = 0; i < finalImageWidth / NWW; i++)
            {
                for (int j = 0; j < finalImageHeight / NWW; j++)
                {
                    gr.DrawImage(bitmaps[GaborFilter.counter], i * NWW, j * NWW, NWW, NWW);
                    GaborFilter.counter += 1;
                }
            }

            return fullBmp;
        }
    }
}
