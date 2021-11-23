using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Futronic.Scanners.FS26X80;

namespace Futronic.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting reader...");

            var accessor = new DeviceAccessor();

            using (var device = accessor.AccessFingerprintDevice())
            {
                device.SwitchLedState(false, false);

                device.FingerDetected += (sender, eventArgs) =>
                {
                    Console.WriteLine("Finger Detected!");

                    device.SwitchLedState(true, false);

                    // Save fingerprint to temporary folder
                    var fingerprint = device.ReadFingerprint();
                    var tempFile = Guid.NewGuid().ToString();
                    var tmpBmpFile = Path.ChangeExtension(tempFile, "bmp");
                    fingerprint.Save(tmpBmpFile);

                    Console.WriteLine("Saving file " + tmpBmpFile);

                };

                device.FingerReleased += (sender, eventArgs) =>
                {
                    Console.WriteLine("Finger Released!");

                    device.SwitchLedState(false, true);
                };

                Console.WriteLine("Fingerprint Device Opened");

                device.StartFingerDetection();
                device.SwitchLedState(false, true);

                Console.ReadLine();

                Console.WriteLine("Exiting...");

                device.SwitchLedState(false, false);
            }
        }
    }
}
