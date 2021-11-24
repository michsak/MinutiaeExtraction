using Accord.Imaging.Filters;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinutiaeExtraction
{
    public partial class Form1 : Form
    {
        private Image<Gray, Byte> picture;
        private Image scannedBitmap = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Files|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picture = new Image<Gray, Byte>(openFileDialog.FileName);
                imageBox1.Image = picture;
                imageBox1.SetZoomScale(1, new Point(0, 0));

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //AHE
            if (picture != null)
            {
                Bitmap afterSharpening = SharpenFilter.Sharpen(picture.ToBitmap());

                Image<Gray, Byte> finalEqualizedImage = Normalization.AHE(new Image<Gray,Byte> (afterSharpening));

                //Gabor filter with Otsu binarization
                Image<Gray, Byte> finalGaborFiltering = GaborFilter.PerformFiltering(finalEqualizedImage);
                Normalization.RemoveBorder(ref finalGaborFiltering);

                //KMM
                KMMAlgorithm kMMAlgorithm = new KMMAlgorithm();
                Image<Gray,Byte> afterThinning = kMMAlgorithm.Perform(finalGaborFiltering);
                picture = afterThinning;
            }

            imageBox2.Image = picture;
            imageBox2.SetZoomScale(1, new Point(0, 0));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CNN, Remove false minutiae
            if (picture != null)
            {
                Image<Bgr, Byte> afterMinutiaeDetection = Minutiae.detectingMinutiae(picture);
                imageBox3.Image = afterMinutiaeDetection;
                imageBox3.SetZoomScale(1, new Point(0, 0));
            }
        }
        
        //scanning using Futronic.ConsoleDemo
        private void button4_Click(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"../../../Futronic.ConsoleDemo/bin/Debug/");
            string finalScannerPath = Path.Combine(Directory.GetCurrentDirectory().ToString(), "Futronic.ConsoleDemo.exe");
            Process.Start(finalScannerPath);
            String currentPath = "";

            while (true)
            {
                if (Directory.GetFiles(Directory.GetCurrentDirectory(), "*.bmp").Length != 0)
                {
                    currentPath = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.bmp")[0].ToString();
                    Process[] runningProcesses = Process.GetProcesses();
                    foreach (Process process in runningProcesses)
                    {
                        if (process.ProcessName == "Futronic.ConsoleDemo")
                        {
                            Thread.Sleep(500);
                            process.CloseMainWindow();
                            process.Kill();
                        }
                    }
                    break;
                }
            }

            Thread.Sleep(700);
            ReadImage(currentPath);
            DeleteAllBmpFilesInCurrentDir();
        }

        private static void DeleteAllBmpFilesInCurrentDir()
        {
            foreach (string file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.bmp"))
            {
                File.Delete(file);
            }
        }

        private void ReadImage(string currentPath)
        {
            using (FileStream fs = new FileStream(currentPath, FileMode.Open, FileAccess.Read))
            {
                using (Image original = Image.FromStream(fs))
                {
                    scannedBitmap = new Bitmap(currentPath);
                    picture = new Image<Gray, Byte>((Bitmap)scannedBitmap);
                    imageBox1.Image = picture;
                    scannedBitmap.Dispose();
                }
            }
        }
    }
}
