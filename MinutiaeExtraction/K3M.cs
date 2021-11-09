using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutiaeExtraction
{
    class K3M : ThinningAlgorithm
    {
        public K3M(){ }

        public override Bitmap Thin(Bitmap b)
        {
            b = CreateNonIndexedImage((Image)b);

            int[] A0 = new int[] { 3, 6, 7, 12, 14, 15, 24, 28, 30, 31, 48, 56, 60,
                                    62, 63, 96, 112, 120, 124, 126, 127, 129, 131, 135,
                                    143, 159, 191, 192, 193, 195, 199, 207, 223, 224,
                                    225, 227, 231, 239, 240, 241, 243, 247, 248, 249,
                                    251, 252, 253, 254 };
            int[] A1 = new int[] { 7, 14, 28, 56, 112, 131, 193, 224 };
            int[] A2 = new int[] { 7, 14, 15, 28, 30, 56, 60, 112, 120, 131, 135,
                                    193, 195, 224, 225, 240 };
            int[] A3 = new int[] { 7, 14, 15, 28, 30, 31, 56, 60, 62, 112, 120,
                                    124, 131, 135, 143, 193, 195, 199, 224, 225, 227,
                                    240, 241, 248 };
            int[] A4 = new int[] { 7, 14, 15, 28, 30, 31, 56, 60, 62, 63, 112, 120,
                                    124, 126, 131, 135, 143, 159, 193, 195, 199, 207,
                                    224, 225, 227, 231, 240, 241, 243, 248, 249, 252 };
            int[] A5 = new int[] { 7, 14, 15, 28, 30, 31, 56, 60, 62, 63, 112, 120,
                                    124, 126, 131, 135, 143, 159, 191, 193, 195, 199,
                                    207, 224, 225, 227, 231, 239, 240, 241, 243, 248,
                                    249, 251, 252, 254 };
            int[] A1px = new int[] { 3, 6, 7, 12, 14, 15, 24, 28, 30, 31, 48, 56,
                                    60, 62, 63, 96, 112, 120, 124, 126, 127, 129, 131,
                                    135, 143, 159, 191, 192, 193, 195, 199, 207, 223,
                                    224, 225, 227, 231, 239, 240, 241, 243, 247, 248,
                                    249, 251, 252, 253, 254 };

            int weight;
            bool change;
            List<(int, int)> marked = new List<(int, int)>();
            List<(int, int)> changed = new List<(int, int)>();
            do
            {
                change = false;
                for (int i = 0; i < b.Width; i++) //Phase 0 - Mark
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        if (b.GetPixel(i, j).ToArgb() == Color.Black.ToArgb())
                        {
                            weight = CalculateWeight(i, j, b);
                            if (A0.Contains(weight))
                                marked.Add((i, j));
                        }
                    }
                }
                foreach ((int, int) p in marked) //Phase 1 - Delete 3
                {
                    weight = CalculateWeight(p.Item1, p.Item2, b);
                    if (A1.Contains(weight))
                    {
                        b.SetPixel(p.Item1, p.Item2, Color.White);
                        changed.Add(p);
                        change = true;
                    }
                }
                foreach ((int, int) p in changed)
                {
                    marked.Remove(p);
                }
                changed.Clear();

                foreach ((int, int) p in marked) //Phase 2 - Delete 3/4
                {
                    weight = CalculateWeight(p.Item1, p.Item2, b);
                    if (A2.Contains(weight))
                    {
                        b.SetPixel(p.Item1, p.Item2, Color.White);
                        changed.Add(p);
                        change = true;
                    }
                }
                foreach ((int, int) p in changed)
                {
                    marked.Remove(p);
                }
                changed.Clear();

                foreach ((int, int) p in marked) //Phase 3 - Delete 3/4/5
                {
                    weight = CalculateWeight(p.Item1, p.Item2, b);
                    if (A3.Contains(weight))
                    {
                        b.SetPixel(p.Item1, p.Item2, Color.White);
                        changed.Add(p);
                        change = true;
                    }
                }
                foreach ((int, int) p in changed)
                {
                    marked.Remove(p);
                }
                changed.Clear();

                foreach ((int, int) p in marked) //Phase 4 - Delete 3/4/5/6
                {
                    weight = CalculateWeight(p.Item1, p.Item2, b);
                    if (A4.Contains(weight))
                    {
                        b.SetPixel(p.Item1, p.Item2, Color.White);
                        changed.Add(p);
                        change = true;
                    }
                }
                foreach ((int, int) p in changed)
                {
                    marked.Remove(p);
                }
                changed.Clear();

                foreach ((int, int) p in marked) //Phase 5 - Delete 3/4/5/6/7
                {
                    weight = CalculateWeight(p.Item1, p.Item2, b);
                    if (A5.Contains(weight))
                    {
                        b.SetPixel(p.Item1, p.Item2, Color.White);
                        changed.Add(p);
                        change = true;
                    }
                }
                foreach ((int, int) p in changed)
                {
                    marked.Remove(p);
                }
                changed.Clear();

                marked.Clear(); //Phase 6 - Unmark
            } while (change);
            for (int i = 0; i < b.Width; i++) //1 pixel Phase
            {
                for (int j = 0; j < b.Height; j++)
                {
                    weight = CalculateWeight(i, j, b);
                    if (A1px.Contains(weight))
                    {
                        b.SetPixel(i, j, Color.White);
                    }
                }
            }

            return b;
        }

        public Bitmap CreateNonIndexedImage(Image src)
        {
            Bitmap newBmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics gfx = Graphics.FromImage(newBmp))
            {
                gfx.DrawImage(src, 0, 0);
            }

            return newBmp;
        }
    }
}
