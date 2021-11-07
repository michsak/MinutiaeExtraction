﻿using Accord.Imaging.Filters;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinutiaeExtraction
{
    public partial class Form1 : Form
    {
        private Image<Gray, Byte> picture;

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
                imageBox1.SetZoomScale(0.75, new Point(0, 0));

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //AHE
            if (picture != null)
            {
                Image<Gray, Byte> finalEqualizedImage = Normalization.AHE(picture);

                //Gabor filter
                Image<Gray, Byte> finalGaborFiltering = GaborFilter.PerformFiltering(finalEqualizedImage);

                //Otsu binarization
                Image<Gray, Byte> afterBinarization = Normalization.Otsu(finalGaborFiltering);
                Normalization.RemoveBorder(ref afterBinarization);

                //K3M
                K3M K3M = new K3M();
                Bitmap afterThinning = K3M.Thin(afterBinarization.ToBitmap());
                picture = new Image<Gray, Byte>(afterThinning);
            }

            imageBox2.Image = picture;
            imageBox2.SetZoomScale(0.75, new Point(0, 0));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CN, Remove false minutiae
            if (picture != null)
            {
                Image<Bgr, Byte> afterMinutiaeDetection = Minutiae.detectingMinutiae(picture);
                imageBox3.Image = afterMinutiaeDetection;
                imageBox3.SetZoomScale(0.75, new Point(0, 0));
            }
        }
    }
}
