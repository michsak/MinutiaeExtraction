using System;

namespace Futronic.Scanners.FS26X80
{
    public class DeviceAccessor
    {
        public FingerprintDevice AccessFingerprintDevice()
        {
            var handle = LibScanApi.ftrScanOpenDevice();

            if (handle != IntPtr.Zero)
            {
                return new FingerprintDevice(handle);
            }

            return null;
        }

        public CardReader AccessCardReader()
        {
            var handle = LibMifareApi.ftrMFOpenDevice();

            if (handle != IntPtr.Zero)
            {
                return new CardReader(handle);
            }

            return null;
        }
    }
}