using Futronic.SDKHelper;
using SourceAFIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutronicFingerPrint
{
   public static class BiometricVerification
   {
        public static Task<(bool, double)> Verify(Image fingerprint1, Image fingerprint2)
        {
            var verificationOptions = new FingerprintImageOptions
            {
                Dpi = 500
            };

            var probe = new FingerprintTemplate(new FingerprintImage(fingerprint1.Width, fingerprint1.Height,
                new byte[8]));

            var candidate = new FingerprintTemplate(new FingerprintImage(fingerprint2.Width, fingerprint2.Height,
                new byte[8]));

            double score = new FingerprintMatcher(probe).Match(candidate);

            double threshold = 40;
            bool match = score >= threshold;
            return Task.FromResult((match, score));
        }
   }
}
