using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MinutiaeExtraction
{
    public class KMMAlgorithm
    {
        //tablica usunięc dla możliwych do uzyskania sum przez sąsiadów na podstawie macierzy wag
        private static readonly int[] deletionArray = {
            3,   5 ,  7,   12,  13,  14,  15,  20,
            21,  22,  23,  28,  29,  30,  31,  48,
            52,  53,  54,  55,  56,  60,  61,  62,
            63,  65,  67,  69,  71,  77,  79,  80,
            81,  83,  84,  85,  86,  87,  88,  89,
            91,  92,  93,  94,  95,  97,  99,  101,
            103, 109, 111, 112, 113, 115, 116, 117,
            118, 119, 120, 121, 123, 124, 125, 126,
            127, 131, 133, 135, 141, 143, 149, 151,
            157, 159, 181, 183, 189, 191, 192, 193,
            195, 197, 199, 205, 207, 208, 209, 211,
            212, 213, 214, 215, 216, 217, 219, 220,
            221, 222, 223, 224, 225, 227, 229, 231,
            237, 239, 240, 241, 243, 244, 245, 246,
            247, 248, 249, 251, 252, 253, 254, 255,
        };

        //mozliwosci sum dla piksela zamienianego na 4 (2-3-4 sąsiedzi wokoł) CIĄGIEM OBOK SIEBIE
        private static readonly int[] arrayOfSumsForFours = {
        3,   7,   15,  6,
        14,  30,  12,  28,
        60,  24,  56,  120,
        48,  112, 240, 96,
        224, 225, 192, 193,
        195, 129, 131, 135
    };

        private readonly HashSet<int> deletionSet = new HashSet<int>(deletionArray);
        private readonly HashSet<int> deletionSetForFours = new HashSet<int>(arrayOfSumsForFours);

        //macierz wag wokół piksela x
        private readonly int[,] weightBoard = {
            {128, 1,  2},
            {64,  0,  4},
            {32,  16, 8}
        };

        private bool KmmIteration(ref int[,] input) // jako parametr dostaje macierz 0 i 1 naszego obrazu
        {
            bool anyChanges = false;
            // phase 1-2
            FindOutLines(ref input); // krok 2 - zamiana jedynek na dwojki i trojki

            // phase 3
            // krok 3 - zamiana pikseli, ktore maja 2/3/4 przylegajacych do siebie sasiadow i zamiana na czworki
            ChangePixelsWithNeighboursToFours(ref input);

            // phase 4
            // krok 4 - usuniecie czworek
            anyChanges |= RemoveAllTargets(ref input, 4);

            // phase 5
            // krok 5 - sprawdzenie czy 2 i 3 sa potrzebne do utrzymania ciaglosci obrazu
            anyChanges |= RemoveUnnecessaryPixels(ref input);

            // jezeli sa potrzebne zamieniamy je na jedynki
            ChangePixelsToOne(ref input, 2);
            ChangePixelsToOne(ref input, 3);

            return anyChanges;
        }

        private void FindOutLines(ref int[,] input)
        {
            int targetHeight = input.GetLength(0) - 1;
            int targetWidth = input.GetLength(1) - 1;
            int tmp;
            for (int y = 1; y < targetHeight; y++)
            {
                for (int x = 1; x < targetWidth; x++)
                {
                    tmp = input[y, x];
                    if (tmp != 0)
                    {
                        input[y, x] = ChangePixelsToOneOrThree(ref input, x, y);
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int ChangePixelsToOneOrThree(ref int[,] input, int x, int y)
        {
            // 1) jedynki konturu, ktore dotykaja tla (zer) zamieniane sa na dwojki
            if (input[y, x - 1] == 0)
                return 2;
            if (input[y, x + 1] == 0)
                return 2;
            if (input[y - 1, x] == 0)
                return 2;
            if (input[y + 1, x] == 0)
                return 2;

            // 2) naroznik, jedynki konturu, ktore znajduja sie w katach zamieniane na trojki //te ktore nie sa otoczone tłem, ale rogiem stykaja sie z 0
            for (int yy = y - 1; yy < y + 1; yy += 2)
            {
                for (int xx = x - 1; xx < x + 1; xx += 2)
                {
                    if (input[yy, xx] == 0)
                        return 3;
                }
            }
            return 1;
        }

        private void ChangePixelsWithNeighboursToFours(ref int[,] input)
        {
            int targetHeight = input.GetLength(0) - 1;
            int targetWidth = input.GetLength(1) - 1;
            for (int y = 1; y < targetHeight; y++)
            {
                for (int x = 1; x < targetWidth; x++)
                {
                    if (input[y, x] == 3 || input[y, x] == 2)
                        if (deletionSetForFours.Contains(CalculatePixelWeight(ref input, x, y)))
                            input[y, x] = 4; // zamiana piksela na 4
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int CalculatePixelWeight(ref int[,] input, int x, int y)
        {
            x -= 1;
            y -= 1;
            int sum = 0;
            for (int yy = 0; yy < 3; yy++)
            {
                for (int xx = 0; xx < 3; xx++)
                {
                    if (input[y + yy, x + xx] != 0)
                        sum += weightBoard[yy, xx];
                }
            }
            return sum;
        }

        private bool RemoveAllTargets(ref int[,] input, int target)
        {
            bool anyChanges = false;
            int height = input.GetLength(0);
            int width = input.GetLength(1);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (input[y, x] == target)
                    {
                        input[y, x] = 0;
                        anyChanges = true;
                    }
                }
            }
            return anyChanges;
        }

        private void ChangePixelsToOne(ref int[,] input, int target)
        {
            int height = input.GetLength(0);
            int width = input.GetLength(1);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (input[y, x] == target)
                        input[y, x] = 1;
                }
            }
        }


        private bool MarkRedundantContourPixels(ref int[,] input, int target, int marker)
        {
            bool anyChanges = false;
            int targetHeight = input.GetLength(0) - 1;
            int targetWidth = input.GetLength(1) - 1;
            for (int y = 1; y < targetHeight; y++)
            {
                for (int x = 1; x < targetWidth; x++)
                {
                    if (input[y, x] == target)
                        if (deletionSet.Contains(CalculatePixelWeight(ref input, x, y)))
                        {
                            input[y, x] = marker;
                            anyChanges = true;
                        }
                }
            }
            return anyChanges;
        }

        private bool RemoveUnnecessaryPixels(ref int[,] input)
        {
            bool anyChanges = false;
            int targetHeight = input.GetLength(0) - 1;
            int targetWidth = input.GetLength(1) - 1;
            for (int y = 1; y < targetHeight; y++)
            {
                for (int x = 1; x < targetWidth; x++)
                {
                    if (input[y, x] == 2 || input[y, x] == 3)
                        if (deletionSet.Contains(CalculatePixelWeight(ref input, x, y)))
                        {
                            input[y, x] = 0;
                            anyChanges = true;
                        }
                }
            }
            return anyChanges;
        }


        public Image<Gray, Byte> Perform(Image<Gray, Byte> img)
        {
            int[,] result = ConvertImageMatrix.GrayImageToMatrix(img); // krok 1 - zamiana obrazu na macierz zer i jedynek

            while (KmmIteration(ref result)) ; // iteracja

            //Odcisk palca po KMM
            Image<Gray, Byte> newImage = ConvertImageMatrix.MatrixToGrayImage(result);

            return newImage;
        }
    }
}
