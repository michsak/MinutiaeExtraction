using System;
using System.Runtime.InteropServices;

namespace Futronic.Scanners.FS26X80
{
    class LibScanApi
    {
        /// <summary>
        /// Opens the device for reading
        /// </summary>
        /// <returns></returns>
        [DllImport("ftrScanAPI.dll")]
        internal static extern IntPtr ftrScanOpenDevice();

        /// <summary>
        /// Returns the last error encountered reading from the device
        /// </summary>
        /// <returns></returns>
        [DllImport("ftrScanAPI.dll")]
        internal static extern long GetLastError();

        /// <summary>
        /// Disposed the memory handle used to access the device
        /// </summary>
        /// <param name="ftrHandle"></param>
        [DllImport("ftrScanAPI.dll")]
        internal static extern void ftrScanCloseDevice(IntPtr ftrHandle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ftrHandle"></param>
        /// <param name="pFrameParameters"></param>
        /// <returns>Returns true if a finger has been placed on the device</returns>
        [DllImport("ftrScanAPI.dll")]
        internal static extern bool ftrScanIsFingerPresent(IntPtr ftrHandle, out _FTRSCAN_FRAME_PARAMETERS pFrameParameters);

        [DllImport("ftrScanAPI.dll")]
        internal static extern bool ftrScanSetDiodesStatus(IntPtr ftrHandle, byte byGreenDiodeStatus, byte byRedDiodeStatus);

        [DllImport("ftrScanAPI.dll")]
        internal static extern bool ftrScanGetDiodesStatus(IntPtr ftrHandle, out bool pbIsGreenDiodeOn, out bool pbIsRedDiodeOn);

        [DllImport("ftrScanAPI.dll")]
        internal static extern bool ftrScanGetImageSize(IntPtr ftrHandle, out _FTRSCAN_IMAGE_SIZE pImageSize);

        /// <summary>
        /// Reads the stream of data from the device and writes the output into the <paramref name="pBuffer"/>
        /// </summary>
        /// <param name="ftrHandle"></param>
        /// <param name="nDose"></param>
        /// <param name="pBuffer">The byte array which the image is to be written to</param>
        /// <returns></returns>
        [DllImport("ftrScanAPI.dll")]
        internal static extern bool ftrScanGetImage(IntPtr ftrHandle, int nDose, byte[] pBuffer);


        internal struct _FTRSCAN_FAKE_REPLICA_PARAMETERS
        {
            public bool bCalculated;
            public int nCalculatedSum1;
            public int nCalculatedSumFuzzy;
            public int nCalculatedSumEmpty;
            public int nCalculatedSum2;
            public double dblCalculatedTremor;
            public double dblCalculatedValue;
        }

        internal struct _FTRSCAN_FRAME_PARAMETERS
        {
            public int nContrastOnDose2;
            public int nContrastOnDose4;
            public int nDose;
            public int nBrightnessOnDose1;
            public int nBrightnessOnDose2;
            public int nBrightnessOnDose3;
            public int nBrightnessOnDose4;
            public _FTRSCAN_FAKE_REPLICA_PARAMETERS FakeReplicaParams;
            public _FTRSCAN_FAKE_REPLICA_PARAMETERS Reserved;
        }

        internal struct _FTRSCAN_IMAGE_SIZE
        {
            public int nWidth;
            public int nHeight;
            public int nImageSize;
        }

    }
}