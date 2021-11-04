using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.IO;

namespace MinutiaeExtraction
{
    class Program
    {
        private static Image<Gray, Byte> currentImage;
        private static string filename = "\\micha2.jpg";

        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"C:\Users\micha\Downloads\fingerprint images");
            string curFile = Directory.GetCurrentDirectory() + filename;

            currentImage = new Image<Gray, Byte>(curFile);
            currentImage = KMMAlgorithm.Perform(currentImage);
            Image <Bgr,Byte> detecedMinutiae = Minutiae.detectingMinutiae(currentImage);

            Console.ReadKey();


            //Image image1 = Image.FromFile("‪‪Users\\micha\\Downloads\\123.jpg");
            //Console.WriteLine(image1.ToString());

        }
    }
}
