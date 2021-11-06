using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutiaeExtraction
{
    public abstract class ThinningAlgorithm
    {
        public int SaveValue { get; set; }

        public ThinningAlgorithm()
        {
            SaveValue = 0;
        }

        public abstract Bitmap Thin(Bitmap b);

        public int CalculateWeight(int i, int j, Bitmap b)
        {
            int[] N = new int[] { 128, 1, 2, 64, 0, 4, 32, 16, 8 };
            int weight = 0;
            if (i - 1 > 0 && j - 1 > 0 && b.GetPixel(i - 1, j - 1).ToArgb() == Color.Black.ToArgb())
                weight += N[0];
            if (j - 1 > 0 && b.GetPixel(i, j - 1).ToArgb() == Color.Black.ToArgb())
                weight += N[1];
            if (i + 1 < b.Width && j - 1 > 0 && b.GetPixel(i + 1, j - 1).ToArgb() == Color.Black.ToArgb())
                weight += N[2];
            if (i - 1 > 0 && b.GetPixel(i - 1, j).ToArgb() == Color.Black.ToArgb())
                weight += N[3];
            if (i + 1 < b.Width && b.GetPixel(i + 1, j).ToArgb() == Color.Black.ToArgb())
                weight += N[5];
            if (i - 1 > 0 && j + 1 < b.Height && b.GetPixel(i - 1, j + 1).ToArgb() == Color.Black.ToArgb())
                weight += N[6];
            if (j + 1 < b.Height && b.GetPixel(i, j + 1).ToArgb() == Color.Black.ToArgb())
                weight += N[7];
            if (i + 1 < b.Width && j + 1 < b.Height && b.GetPixel(i + 1, j + 1).ToArgb() == Color.Black.ToArgb())
                weight += N[8];
            return weight;
        }
    }
}
